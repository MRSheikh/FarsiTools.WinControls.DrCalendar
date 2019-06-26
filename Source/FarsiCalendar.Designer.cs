using System.Drawing;
using System.Windows.Forms;
using DreamyTools.FarsiTools.WinControls.DrCalendar;
using DreamyTools.FarsiTools.WinControls.DrCalendar.PopupControl;

namespace DreamyTools.FarsiTools.WinControls.DrCalendar
{
    partial class FarsiCalendar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FarsiCalendar));
            this.lblToday = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.numMonth = new System.Windows.Forms.NumericUpDown();
            this.lblEvent = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.btn_nextMonth = new System.Windows.Forms.Button();
            this.btn_prevMonth = new System.Windows.Forms.Button();
            this.lbl_monthName = new System.Windows.Forms.Label();
            this.lbl_yearName = new System.Windows.Forms.Label();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.eventPanel = new System.Windows.Forms.Panel();
            this.btn_prevYear = new System.Windows.Forms.Button();
            this.btn_nextYear = new System.Windows.Forms.Button();
            this.popupDatePicker = new PopupComboBox();
            this.table = new MyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).BeginInit();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // lblToday
            // 
            this.lblToday.BackColor = System.Drawing.Color.Transparent;
            this.lblToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblToday.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.lblToday.Location = new System.Drawing.Point(0, 0);
            this.lblToday.Name = "lblToday";
            this.lblToday.Size = new System.Drawing.Size(185, 14);
            this.lblToday.TabIndex = 0;
            this.lblToday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblToday.Click += new System.EventHandler(this.lblToday_Click);
            // 
            // lblCurrent
            // 
            this.lblCurrent.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCurrent.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.lblCurrent.Location = new System.Drawing.Point(0, 0);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(185, 14);
            this.lblCurrent.TabIndex = 0;
            this.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrent.Click += new System.EventHandler(this.lblCurrent_Click);
            // 
            // numYear
            // 
            this.numYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numYear.Location = new System.Drawing.Point(214, 165);
            this.numYear.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(50, 18);
            this.numYear.TabIndex = 1;
            this.numYear.Tag = "";
            this.numYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numYear.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numYear.Value = new decimal(new int[] {
            1392,
            0,
            0,
            0});
            this.numYear.Visible = false;
            this.numYear.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numMonth
            // 
            this.numMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonth.Location = new System.Drawing.Point(214, 189);
            this.numMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMonth.Name = "numMonth";
            this.numMonth.Size = new System.Drawing.Size(50, 18);
            this.numMonth.TabIndex = 2;
            this.numMonth.Tag = "";
            this.numMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMonth.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMonth.Visible = false;
            this.numMonth.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // lblEvent
            // 
            this.lblEvent.BackColor = System.Drawing.Color.Transparent;
            this.lblEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEvent.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.lblEvent.Location = new System.Drawing.Point(0, 0);
            this.lblEvent.Margin = new System.Windows.Forms.Padding(0);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Padding = new System.Windows.Forms.Padding(2);
            this.lblEvent.Size = new System.Drawing.Size(100, 23);
            this.lblEvent.TabIndex = 0;
            this.lblEvent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contentPanel
            // 
            this.contentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contentPanel.BackColor = System.Drawing.Color.Transparent;
            this.contentPanel.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contentPanel.Size = new System.Drawing.Size(290, 210);
            this.contentPanel.TabIndex = 0;
            // 
            // btn_nextMonth
            // 
            this.btn_nextMonth.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_nextMonth.BackgroundImage")));
            this.btn_nextMonth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_nextMonth.FlatAppearance.BorderSize = 0;
            this.btn_nextMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nextMonth.Location = new System.Drawing.Point(0, 189);
            this.btn_nextMonth.Name = "btn_nextMonth";
            this.btn_nextMonth.Size = new System.Drawing.Size(30, 25);
            this.btn_nextMonth.TabIndex = 0;
            this.btn_nextMonth.UseVisualStyleBackColor = true;
            this.btn_nextMonth.Click += new System.EventHandler(this.btn_nextMonth_Click);
            // 
            // btn_prevMonth
            // 
            this.btn_prevMonth.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_prevMonth.BackgroundImage")));
            this.btn_prevMonth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_prevMonth.FlatAppearance.BorderSize = 0;
            this.btn_prevMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_prevMonth.Location = new System.Drawing.Point(0, 189);
            this.btn_prevMonth.Name = "btn_prevMonth";
            this.btn_prevMonth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_prevMonth.Size = new System.Drawing.Size(30, 25);
            this.btn_prevMonth.TabIndex = 0;
            this.btn_prevMonth.UseVisualStyleBackColor = true;
            this.btn_prevMonth.Click += new System.EventHandler(this.btn_prevMonth_Click);
            // 
            // lbl_monthName
            // 
            this.lbl_monthName.AutoSize = true;
            this.lbl_monthName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_monthName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_monthName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lbl_monthName.Location = new System.Drawing.Point(0, 0);
            this.lbl_monthName.Name = "lbl_monthName";
            this.lbl_monthName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_monthName.Size = new System.Drawing.Size(185, 14);
            this.lbl_monthName.TabIndex = 0;
            this.lbl_monthName.Text = "edfd";
            this.lbl_monthName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_yearName
            // 
            this.lbl_yearName.AutoSize = true;
            this.lbl_yearName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_yearName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_yearName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lbl_yearName.Location = new System.Drawing.Point(0, 0);
            this.lbl_yearName.Name = "lbl_yearName";
            this.lbl_yearName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_yearName.Size = new System.Drawing.Size(185, 14);
            this.lbl_yearName.TabIndex = 0;
            this.lbl_yearName.Text = "edfd";
            this.lbl_yearName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // controlPanel
            // 
            this.controlPanel.AutoSize = true;
            this.controlPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controlPanel.BackgroundImage")));
            this.controlPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.controlPanel.Controls.Add(this.headerPanel);
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.controlPanel.Size = new System.Drawing.Size(270, 10);
            this.controlPanel.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.AutoSize = true;
            this.headerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.headerPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.headerPanel.Size = new System.Drawing.Size(270, 2);
            this.headerPanel.TabIndex = 1;
            // 
            // eventPanel
            // 
            this.eventPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("eventPanel.BackgroundImage")));
            this.eventPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eventPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eventPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.eventPanel.Location = new System.Drawing.Point(0, 0);
            this.eventPanel.Name = "eventPanel";
            this.eventPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.eventPanel.Size = new System.Drawing.Size(280, 41);
            this.eventPanel.TabIndex = 0;
            // 
            // btn_prevYear
            // 
            this.btn_prevYear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_prevYear.BackgroundImage")));
            this.btn_prevYear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_prevYear.FlatAppearance.BorderSize = 0;
            this.btn_prevYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_prevYear.Location = new System.Drawing.Point(0, 189);
            this.btn_prevYear.Name = "btn_prevYear";
            this.btn_prevYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_prevYear.Size = new System.Drawing.Size(30, 25);
            this.btn_prevYear.TabIndex = 0;
            this.btn_prevYear.UseVisualStyleBackColor = true;
            this.btn_prevYear.Click += new System.EventHandler(this.btn_prevYear_Click);
            // 
            // btn_nextYear
            // 
            this.btn_nextYear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_nextYear.BackgroundImage")));
            this.btn_nextYear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_nextYear.FlatAppearance.BorderSize = 0;
            this.btn_nextYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nextYear.Location = new System.Drawing.Point(0, 189);
            this.btn_nextYear.Name = "btn_nextYear";
            this.btn_nextYear.Size = new System.Drawing.Size(30, 25);
            this.btn_nextYear.TabIndex = 0;
            this.btn_nextYear.UseVisualStyleBackColor = true;
            this.btn_nextYear.Click += new System.EventHandler(this.btn_nextYear_Click);
            // 
            // popupDatePicker
            // 
            this.popupDatePicker.DropDownControl = null;
            this.popupDatePicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.popupDatePicker.FormattingEnabled = true;
            this.popupDatePicker.Location = new System.Drawing.Point(0, 0);
            this.popupDatePicker.Name = "popupDatePicker";
            this.popupDatePicker.Size = new System.Drawing.Size(121, 21);
            this.popupDatePicker.TabIndex = 0;
            // 
            // table
            // 
            this.table.AllowUserToAddRows = false;
            this.table.AllowUserToDeleteRows = false;
            this.table.AllowUserToResizeColumns = false;
            this.table.AllowUserToResizeRows = false;
            this.table.AutoGenerateColumns = false;
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.ColorOne = System.Drawing.Color.Lavender;
            this.table.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(197)))), ((int)(((byte)(232)))));
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.MultiSelect = false;
            this.table.Name = "table";
            this.table.ReadOnly = true;
            this.table.RowHeadersVisible = false;
            this.table.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.table.Size = new System.Drawing.Size(280, 115);
            this.table.TabIndex = 0;
            this.table.TabStop = false;
            // 
            // FarsiCalendar
            // 
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(278, 20);
            this.Click += new System.EventHandler(this.FarsiCalendar_Click);
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).EndInit();
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MyGrid table;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Label lblToday;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.NumericUpDown numMonth;
        private System.Windows.Forms.Panel eventPanel;
        private System.Windows.Forms.Label lblEvent;
        private PopupControl.PopupComboBox popupDatePicker;
        private Panel contentPanel;
        private Button btn_nextMonth;
        private Panel headerPanel;
        private Button btn_prevMonth;
        private Label lbl_monthName;
        private Label lbl_yearName;
        private Button btn_prevYear;
        private Button btn_nextYear;
    }
}
