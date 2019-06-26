using System.Drawing;
using DreamyTools.FarsiTools.WinControls.DrCalendar;

namespace TestControl
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            DreamyTools.FarsiTools.WinControls.DrCalendar.FarsiDate farsiDate1 = new DreamyTools.FarsiTools.WinControls.DrCalendar.FarsiDate();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gridPerson = new System.Windows.Forms.DataGridView();
            this.BirthDate = new DreamyTools.FarsiTools.WinControls.DrCalendar.DataGridViewFarsiDatePickerColumn();
            this.Fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewFarsiDatePickerColumn1 = new DreamyTools.FarsiTools.WinControls.DrCalendar.DataGridViewFarsiDatePickerColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.farsiCalendar1 = new DreamyTools.FarsiTools.WinControls.DrCalendar.FarsiCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.gridPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date Picker Mode:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Month Calendar Mode:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Farsi DatePicker Column:";
            // 
            // gridPerson
            // 
            this.gridPerson.AllowUserToAddRows = false;
            this.gridPerson.AllowUserToDeleteRows = false;
            this.gridPerson.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPerson.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridPerson.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPerson.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPerson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BirthDate,
            this.Fullname});
            this.gridPerson.Location = new System.Drawing.Point(128, 288);
            this.gridPerson.Name = "gridPerson";
            this.gridPerson.RowHeadersVisible = false;
            this.gridPerson.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gridPerson.Size = new System.Drawing.Size(280, 295);
            this.gridPerson.TabIndex = 5;
            // 
            // BirthDate
            // 
            this.BirthDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BirthDate.DataPropertyName = "BirthDate";
            this.BirthDate.DateFormat = DreamyTools.FarsiTools.WinControls.DrCalendar.DateFormat.Long;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.BirthDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.BirthDate.HeaderText = "تاریخ تولد";
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.ShowFarsiDigitInCell = true;
            this.BirthDate.Theme = DreamyTools.FarsiTools.WinControls.DrCalendar.CalendarTheme.WhiteSmoke;
            // 
            // Fullname
            // 
            this.Fullname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Fullname.DataPropertyName = "Fullname";
            this.Fullname.HeaderText = "نام";
            this.Fullname.Name = "Fullname";
            this.Fullname.ReadOnly = true;
            this.Fullname.Width = 70;
            // 
            // dataGridViewFarsiDatePickerColumn1
            // 
            this.dataGridViewFarsiDatePickerColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewFarsiDatePickerColumn1.DataPropertyName = "BirthDate";
            this.dataGridViewFarsiDatePickerColumn1.DateFormat = DreamyTools.FarsiTools.WinControls.DrCalendar.DateFormat.Short;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewFarsiDatePickerColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewFarsiDatePickerColumn1.HeaderText = "تاریخ تولد";
            this.dataGridViewFarsiDatePickerColumn1.Name = "dataGridViewFarsiDatePickerColumn1";
            this.dataGridViewFarsiDatePickerColumn1.ShowFarsiDigitInCell = false;
            this.dataGridViewFarsiDatePickerColumn1.Theme = DreamyTools.FarsiTools.WinControls.DrCalendar.CalendarTheme.Gold;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Fullname";
            this.dataGridViewTextBoxColumn1.HeaderText = "نام";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // farsiCalendar1
            // 
            this.farsiCalendar1.CellsFont = new System.Drawing.Font("Tahoma", 6.5F);
            this.farsiCalendar1.CellsHeaderFont = new System.Drawing.Font("Tahoma", 6.5F);
            this.farsiCalendar1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.farsiCalendar1.Location = new System.Drawing.Point(388, 65);
            this.farsiCalendar1.MultiSelect = false;
            this.farsiCalendar1.Name = "farsiCalendar1";
            this.farsiCalendar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.farsiCalendar1.Size = new System.Drawing.Size(282, 210);
            this.farsiCalendar1.TabIndex = 11;
            farsiDate1.FarsiSelectedDate = "1398/04/05";
            farsiDate1.GregorianSelectedDate = new System.DateTime(2019, 6, 26, 0, 0, 0, 0);
            farsiDate1.Mode = DreamyTools.FarsiTools.WinControls.DrCalendar.ControlType.MonthCalendar;
            this.farsiCalendar1.Value = farsiDate1;
            this.farsiCalendar1.With = 282;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 595);
            this.Controls.Add(this.farsiCalendar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridPerson);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPerson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridPerson;
        private System.Windows.Forms.Label label3;
        private DataGridViewFarsiDatePickerColumn dataGridViewFarsiDatePickerColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewFarsiDatePickerColumn BirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fullname;
        private System.Windows.Forms.Button button1;
        private FarsiCalendar farsiCalendar1;
    }
}

