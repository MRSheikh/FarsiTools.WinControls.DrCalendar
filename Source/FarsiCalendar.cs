using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using DreamyTools.FarsiTools.WinControls.DrCalendar.Properties;
using DreamyTools.Utility;

namespace DreamyTools.FarsiTools.WinControls.DrCalendar
{
    public delegate void DateChangedHandler(object sender, FarsiDatePickerEventArgs e);
    [ToolboxBitmap(typeof(DateTimePicker)), Designer(typeof(FarsiCalendarDesigner)), DefaultEvent("DateChanged"), DefaultProperty("Value")]
    public partial class FarsiCalendar : UserControl
    {
        #region Fields
        private readonly string[,] _dayEvents;
        private FarsiDate _value;
        private bool _multiSelect = false;
        #endregion

        /// <summary>
        /// Occurs when the PersianSelectedDate property changes.
        /// </summary>
        public event DateChangedHandler DateChanged;
        protected virtual void OnDateChanged(FarsiDatePickerEventArgs e)
        {
            if (DateChanged != null) DateChanged(this, e);
        }

        public FarsiCalendar()
        {
            InitializeComponent();
            _dayEvents = new string[6, 7];
            InitializeControls();
            Value = new FarsiDate();
            Value.GregorianSelectedDate = DateTime.Now;
        }

        #region Properties

       public IEnumerable<FarsiDate> MultiValues
        {
            get
            {
                foreach (DataGridViewCell cell in table.SelectedCells)
                {
                    var date = new FarsiDate();
                    date.GregorianSelectedDate = (DateTime) cell.Tag;
                    yield return date;
                }
            }
        }

        internal static bool shouldClose = true;

        public FarsiDate Value
        {
            get { return _value; }
            set
            {
                if (value == null) return;
                if (_value == null)
                {
                    _value = value;
                    _value.FarsiSelectedDate = FarsiDateHelper.GetShortFarsiDate(DateTime.Now);
                }
                else
                    _value = value;

                SetDatePickerText();
                SetTheme();
                SetControlMode();
                Value.FormatChanged += () =>
                {
                    SetDatePickerText();
                    this.Invalidate(true);
                };
                Value.ThemeChanged += () =>
                {
                    SetTheme();
                    this.Invalidate(true);
                };
                Value.ModeChanged += () =>
                {
                    SetControlMode();
                    this.Invalidate(true);
                };
                Value.DateChanged += (newFarsiDate, oldFarsiDate) =>
                {
                    if (_multiSelectIndex != null && _multiSelectIndex.Length > 0)
                        return;
                    if (Value.Mode == ControlType.MonthCalendar)
                        CreateCells(Value.GregorianSelectedDate);
                    SetDatePickerText();
                    OnDateChanged(new FarsiDatePickerEventArgs(newFarsiDate, oldFarsiDate));
                    this.Invalidate(true);
                };
                this.Invalidate(true);
            }
        }

        private void SetControlMode()
        {
            if (Value.Mode == ControlType.DatePicker)
            {
                popupDatePicker.DropDownControl = contentPanel;
                popupDatePicker.DropDown += popupDatePicker_DropDown;
                popupDatePicker.DropDownClosed += popupDatePicker_DropDownClosed;
                this.Controls.Remove(contentPanel);
                this.Controls.Add(popupDatePicker);
            }
            else
            {
                lblToday.Text = string.Format("تاریخ امروز: {0}", FarsiDateHelper.ToFarsiDigit(FarsiDateHelper.GetLongFarsiDate(DateTime.Now)));
                lblToday.Tag = DateTime.Now;
                popupDatePicker.DropDown -= popupDatePicker_DropDown;
                popupDatePicker.DropDownClosed -= popupDatePicker_DropDownClosed;
                CreateCells(Value.GregorianSelectedDate);
                this.Controls.Remove(popupDatePicker);
                this.Controls.Add(contentPanel);
            }
            SetControlSize();
        }

        private void SetControlSize()
        {
            if (Value != null && Value.Mode == ControlType.DatePicker)
            {
                this.Height = popupDatePicker.Height;
                popupDatePicker.Width = this.Width;
            }
            else
            {
                this.Width = 282;
                this.Height = 210;
            }
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                popupDatePicker.Font = value;
                SetControlSize();
                base.Font = value;
            }
        }
        #endregion

        #region Hidden Properties
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public bool MultiSelect
        {
            get { return _multiSelect; }
            set { _multiSelect = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Cursor Cursor
        {
            get { return base.Cursor; }
            set { base.Cursor = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Margin
        {
            get { return base.Margin; }
            set { base.Margin = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MaximumSize
        {
            get { return base.MaximumSize; }
            set { base.MaximumSize = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MinimumSize
        {
            get { return base.MinimumSize; }
            set { base.MinimumSize = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get { return string.Empty; }
            set { throw new NotImplementedException(); }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public Font CellsFont
        {
            get
            {
                return _cellsFont;
            }

            set
            {
                _cellsFont = value;
                lblEvent.Font = value;
                _refereshCalendar();
            }
        }

        private Font _cellsFont;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public Font CellsHeaderFont
        {
            get
            {
                return _cellsHeaderFont;
            }

            set
            {
                _cellsHeaderFont = value;
                _refereshCalendar();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public int With
        {
            get { return Size.Width; }
            set
            {
                Size = new Size(value, popupDatePicker.ClientSize.Height);
                _with = Size.Width;
                
            }
        }

     
        private int _with;

        private Font _cellsHeaderFont;

        #endregion

        #region Methods

        //Define visual appearance of controls
        private void InitializeControls()
        {
            Font = new Font("Tahoma", 8.25f, FontStyle.Regular);
            table.ColumnHeadersHeight = 23;
            table.BackColor = Color.White;
            table.RightToLeft = RightToLeft.Yes;
            table.CellClick += table_CellClick;
            table.CellMouseMove += table_CellMouseMove;
            table.MouseLeave += table_MouseLeave;
            if (CellsHeaderFont == null)
                CellsHeaderFont = new Font("Tahoma", 6.5f, FontStyle.Regular);

            table.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = CellsHeaderFont,
                Alignment = DataGridViewContentAlignment.MiddleCenter,
            };
            table.RowTemplate = new DataGridViewRow
            {
                Height = 15
            };
            table.Columns.AddRange(new DataGridViewColumn[]
                                        {
                                            new DataGridViewTextBoxColumn {HeaderText = "شنبه", SortMode = DataGridViewColumnSortMode.NotSortable},
                                            new DataGridViewTextBoxColumn {HeaderText = "١ شنبه", SortMode = DataGridViewColumnSortMode.NotSortable},
                                            new DataGridViewTextBoxColumn {HeaderText = "٢ شنبه", SortMode = DataGridViewColumnSortMode.NotSortable},
                                            new DataGridViewTextBoxColumn {HeaderText = "٣ شنبه", SortMode = DataGridViewColumnSortMode.NotSortable},
                                            new DataGridViewTextBoxColumn {HeaderText = "٤ شنبه", SortMode = DataGridViewColumnSortMode.NotSortable},
                                            new DataGridViewTextBoxColumn {HeaderText = "٥ شنبه", SortMode = DataGridViewColumnSortMode.NotSortable},
                                            new DataGridViewTextBoxColumn {HeaderText = "جمعه", SortMode = DataGridViewColumnSortMode.NotSortable}
                                        });
            numYear.Location = new Point(1, 1);
            numMonth.Location = new Point(1, 20);

            btn_nextMonth.Location = new Point((Int32)((headerPanel.ClientSize.Width - btn_nextMonth.Width) / 2) - 75, 1);
            btn_prevMonth.Location = new Point((Int32)((headerPanel.ClientSize.Width - btn_prevMonth.Width) / 2) + 75, 1);

            btn_nextYear.Location = new Point((Int32)(headerPanel.ClientSize.Width - btn_nextYear.Width) / 2 - 75 - btn_nextMonth.Width - 2, 1);
            btn_prevYear.Location = new Point((Int32)(headerPanel.ClientSize.Width - btn_prevYear.Width) / 2 + 75 + btn_prevMonth.Width + 2, 1);

            lblToday.Location = new Point(90, 1);
            numYear.Location = lblToday.Location;
            numMonth.Location = lblToday.Location;
            lblCurrent.Location = new Point(90, 1);
            lbl_monthName.Location = new Point((Int32)(headerPanel.ClientSize.Width) / 2, 1);
            lbl_yearName.Location = new Point((Int32)(headerPanel.ClientSize.Width) / 2, 15);
            headerPanel.Location = new Point(1, 1);


            controlPanel.Location = new Point(1, 152);

            table.Location = new Point(1, 35);

            headerPanel.Controls.AddRange(new Control[] { btn_nextMonth, lbl_monthName, lbl_yearName, btn_prevMonth, btn_prevYear, btn_nextYear });
            
            eventPanel.Controls.Add(lblEvent);
            
            contentPanel.Controls.Add(headerPanel);
            contentPanel.Controls.Add(table);

            //controlPanel.Location = new Point(controlPanel.Location.X,controlPanel.Location.Y+250);//(contentPanel.Location.X, contentPanel.Location.Y);
            controlPanel.Controls.AddRange(new Control[]
                                               {
                                                   //lblToday,
                                                   lblCurrent
                                                   //add hear button for go to today ????
                                               });
            contentPanel.Controls.AddRange(new Control[]
                                               {
                                                   controlPanel,
                                                   eventPanel
                                               });

            // update holidays and events
            ContextMenu cm= new ContextMenu();
            cm.MenuItems.Add("بروز رسانی تعطیلات و رخدادها");

            contentPanel.ContextMenu = cm;
        }

        private string[] _multiSelectIndex;

        private void CreateCells(DateTime currentDate)
        {
            if (table.SelectedCells.Count > 1)
            {
                _multiSelectIndex = new string[table.SelectedCells.Count];
                for (int i = 0; i < table.SelectedCells.Count; i++)
                {
                    _multiSelectIndex[i] = table.SelectedCells[i].RowIndex + "," + table.SelectedCells[i].ColumnIndex;
                }
            }
            else
            {
                _multiSelectIndex = null;
            }

            table.Rows.Clear();
            numYear.Value = FarsiDateHelper.GetSectionOfDate(currentDate, true, SectionOfDate.Year);
            numMonth.Value = FarsiDateHelper.GetSectionOfDate(currentDate, true, SectionOfDate.Month);
            //lblCurrent.Text = string.Format("تاریخ انتخابی: {0}", FarsiDateHelper.ToFarsiDigit(FarsiDateHelper.GetLongFarsiDate(Value.GregorianSelectedDate)));
            lblCurrent.Tag = Value.GregorianSelectedDate;
            var firstSaturday = currentDate;
            while (firstSaturday.DayOfWeek != DayOfWeek.Saturday ||
                   FarsiDateHelper.GetSectionOfDate(firstSaturday, true, SectionOfDate.Month) ==
                   FarsiDateHelper.GetSectionOfDate(currentDate, true, SectionOfDate.Month))
                firstSaturday = firstSaturday.AddDays(-1);
            var index = 0;
            DataGridViewCell currentCell = null;
            var dayEvents = FarsiDateHelper.CalendarEvents.Where(c =>
                    c.Month >= FarsiDateHelper.GetSectionOfDate(firstSaturday, c.IsPersian, SectionOfDate.Month, (c.IsPersian || FarsiDateHelper.CalendarHijriAdjustment == null ? 0 : FarsiDateHelper.CalendarHijriAdjustment[c.Month])) ||
                    c.Month <= FarsiDateHelper.GetSectionOfDate(firstSaturday.AddDays(42), c.IsPersian, SectionOfDate.Month, (c.IsPersian || FarsiDateHelper.CalendarHijriAdjustment == null ? 0 : FarsiDateHelper.CalendarHijriAdjustment[c.Month]))).ToList();
            for (var i = 0; i < 6; i++)
            {
                table.Rows.Add(1);
                for (var j = 0; j < 7; j++)
                {
                    var newDate = firstSaturday.AddDays(index++);
                    table.Rows[i].Cells[j].Value = FarsiDateHelper.ToFarsiDigit(FarsiDateHelper.GetSectionOfDate(newDate, true, SectionOfDate.Day).ToString("00"));
                    table.Rows[i].Cells[j].Tag = newDate;
                    _dayEvents[i, j] = string.Empty;
                    var todayEvents = dayEvents.Where(c => c.Month == FarsiDateHelper.GetSectionOfDate(newDate, c.IsPersian, SectionOfDate.Month, (c.IsPersian || FarsiDateHelper.CalendarHijriAdjustment == null ? 0 : FarsiDateHelper.CalendarHijriAdjustment[c.Month])) &&
                                                           c.Day == FarsiDateHelper.GetSectionOfDate(newDate, c.IsPersian, SectionOfDate.Day, (c.IsPersian || FarsiDateHelper.CalendarHijriAdjustment == null ? 0 : FarsiDateHelper.CalendarHijriAdjustment[c.Month]))).ToList();
                    if (newDate.DayOfWeek == DayOfWeek.Friday || todayEvents.Any(c => c.IsHoliday))
                        table.Rows[i].Cells[j].Style = new DataGridViewCellStyle { ForeColor = Color.Red };
                    if (todayEvents.Count > 0)
                        _dayEvents[i, j] = todayEvents.Aggregate(string.Empty, (current, tEvent) => current + (!string.IsNullOrEmpty(current) ? " | " : string.Empty) + tEvent.Event);
                    if (FarsiDateHelper.GetSectionOfDate(currentDate, true, SectionOfDate.Year) != FarsiDateHelper.GetSectionOfDate(newDate, true, SectionOfDate.Year) ||
                        FarsiDateHelper.GetSectionOfDate(currentDate, true, SectionOfDate.Month) != FarsiDateHelper.GetSectionOfDate(newDate, true, SectionOfDate.Month))
                        table.Rows[i].Cells[j].Style = table.Rows[i].Cells[j].Style.ForeColor == Color.Red
                                                            ? new DataGridViewCellStyle { ForeColor = Color.FromArgb(255, 150, 150) }
                                                            : new DataGridViewCellStyle { ForeColor = Color.DarkGray };
                    if (currentDate == newDate)
                        currentCell = table.Rows[i].Cells[j];
                }
            }
            table.ClearSelection();
            if (currentCell == null) return;
            table.CurrentCell = currentCell;
            table.Rows[currentCell.RowIndex].Cells[currentCell.ColumnIndex].Selected = true;
            //table.Rows[3].Cells[3].Selected = true;
            table.MultiSelect = _multiSelect;

            if (_multiSelectIndex != null)
                foreach (var s in _multiSelectIndex)
                {
                    var _indexSplit = s.Split(',');
                    table.Rows[Convert.ToInt32(_indexSplit[0])].Cells[Convert.ToInt32(_indexSplit[1])].Selected = true;
                }
                
            _refereshCalendar();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            SetControlSize();
        }

        private void SetDatePickerText()
        {
            var gDate = Value.GregorianSelectedDate;
            var str = Value.Format == DateFormat.Short
                                     ? FarsiDateHelper.ToFarsiDigit(FarsiDateHelper.GetShortFarsiDate(gDate))
                                     : FarsiDateHelper.ToFarsiDigit(FarsiDateHelper.GetLongFarsiDate(gDate));
            popupDatePicker.Items.Clear();
            popupDatePicker.Items.Add(str);
            popupDatePicker.SelectedIndex = 0;
            if (Value.Mode == ControlType.DatePicker)
                popupDatePicker.HideDropDown();
        }

        

        private void SetTheme()
        {
            if (_cellsFont == null)
                _cellsFont = new Font("Tahoma", 6.5f, FontStyle.Regular);
            var cellStyle = new DataGridViewCellStyle
                                {
                                    ForeColor = Color.Black,
                                    Font = _cellsFont,
                                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                                    SelectionForeColor = Color.Yellow
                                };
            switch (Value.Theme)
            {
                case CalendarTheme.Blue:
                    table.ColorOne = Color.Lavender;
                    table.ColorTwo = Color.FromArgb(169, 197, 232);
                    controlPanel.BackgroundImage = eventPanel.BackgroundImage =
                                                   contentPanel.BackgroundImage =  Resources.BlueBack;
                    cellStyle.BackColor = Color.FromArgb(215, 225, 245);
                    cellStyle.SelectionBackColor = Color.FromArgb(150, 185, 220);
                    break;
                case CalendarTheme.Gold:
                    table.ColorOne = Color.Yellow;
                    table.ColorTwo = Color.FromArgb(245, 150, 2);
                    controlPanel.BackgroundImage = eventPanel.BackgroundImage =
                                                   contentPanel.BackgroundImage = Resources.GoldBack;
                    cellStyle.BackColor = Color.Yellow;
                    cellStyle.SelectionBackColor = Color.FromArgb(200, 100, 0);
                    break;
                case CalendarTheme.Green:
                    table.ColorOne = Color.FromArgb(156, 255, 106);
                    table.ColorTwo = Color.FromArgb(40, 140, 4);
                    controlPanel.BackgroundImage = eventPanel.BackgroundImage =
                                                   contentPanel.BackgroundImage = Resources.GreenBack;
                    cellStyle.BackColor = Color.FromArgb(180, 255, 0);
                    cellStyle.SelectionBackColor = Color.FromArgb(70, 105, 0);
                    break;
                default:
                    table.ColorOne = Color.FromArgb(180, 180, 180);
                    table.ColorTwo = Color.WhiteSmoke;
                    controlPanel.BackgroundImage = eventPanel.BackgroundImage =
                                                   contentPanel.BackgroundImage = Resources.WhiteSmokeBack;
                    cellStyle.BackColor = Color.FromArgb(225, 225, 225);
                    cellStyle.SelectionBackColor = Color.DarkGray;
                    break;
            }
            table.DefaultCellStyle = cellStyle;
        }
        #endregion

        #region Events
        void popupDatePicker_DropDownClosed(object sender, EventArgs e)
        {
            table.Rows.Clear();
            lblEvent.Text = lblCurrent.Text = lblToday.Text = string.Empty;
            lblToday.Tag = lblCurrent.Tag = null;
            eventPanel.Visible = false;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (Value.Mode == ControlType.DatePicker)
                popupDatePicker.Focus();
            else
                numYear.Focus();
        }

        void popupDatePicker_DropDown(object sender, EventArgs e)
        {
            lblToday.Text = string.Format("تاریخ امروز: {0}",
                FarsiDateHelper.ToFarsiDigit(FarsiDateHelper.GetLongFarsiDate(DateTime.Now)));
            lblToday.Tag = DateTime.Now;
            CreateCells(Value.GregorianSelectedDate);
        }

        private string _tempEVENT = "";
        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (table.SelectedCells.Count <= 1)
                _multiSelectIndex = null;
            if (e.RowIndex == -1) return;
            var gDate = (DateTime)table.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
            Value.FarsiSelectedDate = FarsiDateHelper.GetShortFarsiDate(gDate);
            popupDatePicker.HideDropDown();

            Value._event  = _dayEvents[e.RowIndex, e.ColumnIndex];
            lblEvent.Text = Value.Event;
        }

        void table_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var str = _dayEvents[e.RowIndex, e.ColumnIndex];
            _tempEVENT = lblEvent.Text;
            lblEvent.Text = str;
            //eventPanel.Visible = !string.IsNullOrEmpty(str);
            //controlPanel.Visible = string.IsNullOrEmpty(str);
        }

        void table_MouseLeave(object sender, EventArgs e)
        {
            if (Value.Event != "" || Value.Event != null)
                lblEvent.Text = Value.Event;
            else
                lblEvent.Text = string.Empty;
            //eventPanel.Visible = false;
            //controlPanel.Visible = true;
        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            var selectedYearAndMonth = FarsiDateHelper.GetGregorianDate(string.Format("{0}/{1}/{2}", numYear.Value, numMonth.Value, 1));
            var gDate = Value.GregorianSelectedDate;
            var isSameMonth = FarsiDateHelper.GetSectionOfDate(gDate, true, SectionOfDate.Year) == numYear.Value &&
                              FarsiDateHelper.GetSectionOfDate(gDate, true, SectionOfDate.Month) == numMonth.Value;
            table.ClearSelection();
            
            CreateCells(isSameMonth ? gDate : selectedYearAndMonth);
            
        }

        private void lblToday_Click(object sender, EventArgs e)
        {
            Value.FarsiSelectedDate = FarsiDateHelper.GetShortFarsiDate((DateTime)lblToday.Tag);
            //popupDatePicker.HideDropDown();
        }

        private void lblCurrent_Click(object sender, EventArgs e)
        {
            var currentDate = (DateTime)lblCurrent.Tag;
            CreateCells(currentDate);
            Value.FarsiSelectedDate = FarsiDateHelper.GetShortFarsiDate(currentDate);
        }
        #endregion


        private void btn_nextMonth_Click(object sender, EventArgs e)
        {
            // always show  dropdown list  --- 97/12/06 
            shouldClose = false;
            //--------------------- ------------------------------

            //table.se

            if (numMonth.Value == 12)
            {
                numYear.Value++;
                numMonth.Value = 1;
            }
            else
            {
                numMonth.Value++;
            }

            _refereshCalendar();

           

        }
        
        private void btn_prevMonth_Click(object sender, EventArgs e)
        {
            // always show  dropdown list  --- 97/12/06 
            shouldClose = false;
            //--------------------- ------------------------------

           // table.SelectedCells.Clear();

            if (numMonth.Value == 1)
            {
                numYear.Value--;
                numMonth.Value = 12;
            }
            else
            {
                numMonth.Value--;
            }
            _refereshCalendar();

        }

        private void _refereshCalendar()
        {
            int selectedRow, selectedCol;
            selectedRow =table.SelectedCells.Count==0? -1: table.SelectedCells[0].RowIndex;
            selectedCol = table.SelectedCells.Count == 0 ? -1 : table.SelectedCells[0].ColumnIndex;

            if (selectedRow == -1) return;
            var gDate = (DateTime)table.Rows[selectedRow].Cells[selectedCol].Tag;
            Value.FarsiSelectedDate = FarsiDateHelper.GetShortFarsiDate(gDate);
            lbl_monthName.Text = FarsiDateHelper.GetFarsiMonthName(gDate);
            lbl_yearName.Text = FarsiDateHelper.GetSectionOfDate(gDate, true, SectionOfDate.Year).ToString();

            // center header lables
            lbl_monthName.Location = new Point((Int32)(headerPanel.ClientSize.Width - lbl_monthName.Width) / 2, 1);
            lbl_yearName.Location = new Point((Int32)(headerPanel.ClientSize.Width - lbl_yearName.Width) / 2, 15);

            lblCurrent.Text = FarsiDateHelper.GetLongFarsiDate(gDate);

            if (selectedRow == -1) return;
            Value._event = _dayEvents[selectedRow, selectedCol];

            lblEvent.Text = Value.Event;

            SetTheme();
            table.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = CellsHeaderFont,
                Alignment = DataGridViewContentAlignment.MiddleCenter,
            };
        }

        private void TableOnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            table[e.ColumnIndex, e.RowIndex].Selected = true;
        }

        private void btn_prevYear_Click(object sender, EventArgs e)
        {
            // always show  dropdown list  --- 97/12/06 
            shouldClose = false;
            //--------------------- ------------------------------
            //table.SelectedCells.Clear();

            numYear.Value--;
            _refereshCalendar();
        }

        private void btn_nextYear_Click(object sender, EventArgs e)
        {
            // always show  dropdown list  --- 97/12/06 
            shouldClose = false;
            //--------------------- ------------------------------

            //table.SelectedCells.Clear();

            numYear.Value++;
            _refereshCalendar();
        }

        private void FarsiCalendar_Click(object sender, EventArgs e)
        {

        }
    }

    internal class DayEvent
    {
        public int Month { get; set; }
        public int Day { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsPersian { get; set; }
        public string Event { get; set; }
    }
}
