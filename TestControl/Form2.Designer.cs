namespace TestControl
{
    partial class Form2
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
            DreamyTools.FarsiTools.WinControls.DrCalendar.FarsiDate farsiDate1 = new DreamyTools.FarsiTools.WinControls.DrCalendar.FarsiDate();
            this.farsiCalendar2 = new DreamyTools.FarsiTools.WinControls.DrCalendar.FarsiCalendar();
            this.SuspendLayout();
            // 
            // farsiCalendar2
            // 
            this.farsiCalendar2.CellsFont = new System.Drawing.Font("Tahoma", 6.5F);
            this.farsiCalendar2.CellsHeaderFont = new System.Drawing.Font("Tahoma", 6.5F);
            this.farsiCalendar2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.farsiCalendar2.Location = new System.Drawing.Point(132, 58);
            this.farsiCalendar2.MultiSelect = false;
            this.farsiCalendar2.Name = "farsiCalendar2";
            this.farsiCalendar2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.farsiCalendar2.Size = new System.Drawing.Size(282, 21);
            this.farsiCalendar2.TabIndex = 4;
            farsiDate1.FarsiSelectedDate = "1398/04/05";
            farsiDate1.GregorianSelectedDate = new System.DateTime(2019, 6, 26, 0, 0, 0, 0);
            this.farsiCalendar2.Value = farsiDate1;
            this.farsiCalendar2.With = 282;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 388);
            this.Controls.Add(this.farsiCalendar2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion
        private DreamyTools.FarsiTools.WinControls.DrCalendar.FarsiCalendar farsiCalendar2;
    }
}