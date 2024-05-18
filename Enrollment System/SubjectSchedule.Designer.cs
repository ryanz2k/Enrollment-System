namespace Enrollment_System
{
    partial class SubjectSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubjectSchedule));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SchoolYearComboBox = new System.Windows.Forms.ComboBox();
            this.SectionComboBox = new System.Windows.Forms.ComboBox();
            this.BackToMenuButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.DaysGroupBox = new System.Windows.Forms.GroupBox();
            this.SaturdayCheckBox = new System.Windows.Forms.CheckBox();
            this.FridayCheckBox = new System.Windows.Forms.CheckBox();
            this.ThursdayCheckBox = new System.Windows.Forms.CheckBox();
            this.WednesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.TuesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.MondayCheckBox = new System.Windows.Forms.CheckBox();
            this.TimeEnd = new System.Windows.Forms.DateTimePicker();
            this.TimeStart = new System.Windows.Forms.DateTimePicker();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.RoomTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SubjectEDPCodeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SubjectCodeTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.DaysGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SchoolYearComboBox);
            this.groupBox1.Controls.Add(this.SectionComboBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.DaysGroupBox);
            this.groupBox1.Controls.Add(this.TimeEnd);
            this.groupBox1.Controls.Add(this.TimeStart);
            this.groupBox1.Controls.Add(this.DescriptionTextBox);
            this.groupBox1.Controls.Add(this.RoomTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.SubjectEDPCodeTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.SubjectCodeTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 273);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // SchoolYearComboBox
            // 
            this.SchoolYearComboBox.BackColor = System.Drawing.Color.AliceBlue;
            this.SchoolYearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SchoolYearComboBox.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.SchoolYearComboBox.FormattingEnabled = true;
            this.SchoolYearComboBox.Items.AddRange(new object[] {
            "-Select School Year-",
            "1",
            "2",
            "3",
            "4"});
            this.SchoolYearComboBox.Location = new System.Drawing.Point(429, 93);
            this.SchoolYearComboBox.Name = "SchoolYearComboBox";
            this.SchoolYearComboBox.Size = new System.Drawing.Size(153, 27);
            this.SchoolYearComboBox.TabIndex = 30;
            // 
            // SectionComboBox
            // 
            this.SectionComboBox.BackColor = System.Drawing.Color.AliceBlue;
            this.SectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SectionComboBox.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.SectionComboBox.FormattingEnabled = true;
            this.SectionComboBox.Items.AddRange(new object[] {
            "-Select Section-",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H"});
            this.SectionComboBox.Location = new System.Drawing.Point(429, 60);
            this.SectionComboBox.Name = "SectionComboBox";
            this.SectionComboBox.Size = new System.Drawing.Size(153, 27);
            this.SectionComboBox.TabIndex = 29;
            // 
            // BackToMenuButton
            // 
            this.BackToMenuButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.BackToMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackToMenuButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackToMenuButton.Location = new System.Drawing.Point(12, 382);
            this.BackToMenuButton.Name = "BackToMenuButton";
            this.BackToMenuButton.Size = new System.Drawing.Size(127, 30);
            this.BackToMenuButton.TabIndex = 28;
            this.BackToMenuButton.Text = "Back to Menu";
            this.BackToMenuButton.UseVisualStyleBackColor = false;
            this.BackToMenuButton.Click += new System.EventHandler(this.BackToMenuButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.Location = new System.Drawing.Point(404, 382);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(89, 30);
            this.ClearButton.TabIndex = 27;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(518, 382);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(89, 30);
            this.SaveButton.TabIndex = 26;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(310, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 23);
            this.label9.TabIndex = 24;
            this.label9.Text = "School Year:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DaysGroupBox
            // 
            this.DaysGroupBox.Controls.Add(this.SaturdayCheckBox);
            this.DaysGroupBox.Controls.Add(this.FridayCheckBox);
            this.DaysGroupBox.Controls.Add(this.ThursdayCheckBox);
            this.DaysGroupBox.Controls.Add(this.WednesdayCheckBox);
            this.DaysGroupBox.Controls.Add(this.TuesdayCheckBox);
            this.DaysGroupBox.Controls.Add(this.MondayCheckBox);
            this.DaysGroupBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DaysGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DaysGroupBox.Location = new System.Drawing.Point(363, 128);
            this.DaysGroupBox.Name = "DaysGroupBox";
            this.DaysGroupBox.Size = new System.Drawing.Size(219, 122);
            this.DaysGroupBox.TabIndex = 23;
            this.DaysGroupBox.TabStop = false;
            this.DaysGroupBox.Text = "Days";
            // 
            // SaturdayCheckBox
            // 
            this.SaturdayCheckBox.AutoSize = true;
            this.SaturdayCheckBox.Location = new System.Drawing.Point(119, 83);
            this.SaturdayCheckBox.Name = "SaturdayCheckBox";
            this.SaturdayCheckBox.Size = new System.Drawing.Size(88, 23);
            this.SaturdayCheckBox.TabIndex = 5;
            this.SaturdayCheckBox.Text = "Saturday";
            this.SaturdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // FridayCheckBox
            // 
            this.FridayCheckBox.AutoSize = true;
            this.FridayCheckBox.Location = new System.Drawing.Point(119, 54);
            this.FridayCheckBox.Name = "FridayCheckBox";
            this.FridayCheckBox.Size = new System.Drawing.Size(71, 23);
            this.FridayCheckBox.TabIndex = 4;
            this.FridayCheckBox.Text = "Friday";
            this.FridayCheckBox.UseVisualStyleBackColor = true;
            // 
            // ThursdayCheckBox
            // 
            this.ThursdayCheckBox.AutoSize = true;
            this.ThursdayCheckBox.Location = new System.Drawing.Point(119, 25);
            this.ThursdayCheckBox.Name = "ThursdayCheckBox";
            this.ThursdayCheckBox.Size = new System.Drawing.Size(91, 23);
            this.ThursdayCheckBox.TabIndex = 3;
            this.ThursdayCheckBox.Text = "Thursday";
            this.ThursdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // WednesdayCheckBox
            // 
            this.WednesdayCheckBox.AutoSize = true;
            this.WednesdayCheckBox.Location = new System.Drawing.Point(16, 83);
            this.WednesdayCheckBox.Name = "WednesdayCheckBox";
            this.WednesdayCheckBox.Size = new System.Drawing.Size(105, 23);
            this.WednesdayCheckBox.TabIndex = 2;
            this.WednesdayCheckBox.Text = "Wednesday";
            this.WednesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // TuesdayCheckBox
            // 
            this.TuesdayCheckBox.AutoSize = true;
            this.TuesdayCheckBox.Location = new System.Drawing.Point(16, 54);
            this.TuesdayCheckBox.Name = "TuesdayCheckBox";
            this.TuesdayCheckBox.Size = new System.Drawing.Size(84, 23);
            this.TuesdayCheckBox.TabIndex = 1;
            this.TuesdayCheckBox.Text = "Tuesday";
            this.TuesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // MondayCheckBox
            // 
            this.MondayCheckBox.AutoSize = true;
            this.MondayCheckBox.Location = new System.Drawing.Point(16, 25);
            this.MondayCheckBox.Name = "MondayCheckBox";
            this.MondayCheckBox.Size = new System.Drawing.Size(84, 23);
            this.MondayCheckBox.TabIndex = 0;
            this.MondayCheckBox.Text = "Monday";
            this.MondayCheckBox.UseVisualStyleBackColor = true;
            // 
            // TimeEnd
            // 
            this.TimeEnd.CalendarMonthBackground = System.Drawing.Color.CornflowerBlue;
            this.TimeEnd.Location = new System.Drawing.Point(149, 154);
            this.TimeEnd.Name = "TimeEnd";
            this.TimeEnd.Size = new System.Drawing.Size(155, 26);
            this.TimeEnd.TabIndex = 21;
            // 
            // TimeStart
            // 
            this.TimeStart.CalendarMonthBackground = System.Drawing.Color.CornflowerBlue;
            this.TimeStart.Location = new System.Drawing.Point(149, 122);
            this.TimeStart.Name = "TimeStart";
            this.TimeStart.Size = new System.Drawing.Size(155, 26);
            this.TimeStart.TabIndex = 20;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.BackColor = System.Drawing.Color.LightSlateGray;
            this.DescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescriptionTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionTextBox.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.DescriptionTextBox.Location = new System.Drawing.Point(149, 93);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.ReadOnly = true;
            this.DescriptionTextBox.Size = new System.Drawing.Size(155, 26);
            this.DescriptionTextBox.TabIndex = 19;
            // 
            // RoomTextBox
            // 
            this.RoomTextBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.RoomTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RoomTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomTextBox.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.RoomTextBox.Location = new System.Drawing.Point(429, 29);
            this.RoomTextBox.Name = "RoomTextBox";
            this.RoomTextBox.Size = new System.Drawing.Size(155, 26);
            this.RoomTextBox.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(310, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Room:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(308, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Section:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(11, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Time End:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(11, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Time Start:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SubjectEDPCodeTextBox
            // 
            this.SubjectEDPCodeTextBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.SubjectEDPCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SubjectEDPCodeTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectEDPCodeTextBox.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.SubjectEDPCodeTextBox.Location = new System.Drawing.Point(149, 29);
            this.SubjectEDPCodeTextBox.Name = "SubjectEDPCodeTextBox";
            this.SubjectEDPCodeTextBox.Size = new System.Drawing.Size(155, 26);
            this.SubjectEDPCodeTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Subject EDP Code:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(11, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Subject Code:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(11, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "Description:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SubjectCodeTextBox
            // 
            this.SubjectCodeTextBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.SubjectCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SubjectCodeTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectCodeTextBox.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.SubjectCodeTextBox.Location = new System.Drawing.Point(149, 61);
            this.SubjectCodeTextBox.Name = "SubjectCodeTextBox";
            this.SubjectCodeTextBox.Size = new System.Drawing.Size(155, 26);
            this.SubjectCodeTextBox.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DarkBlue;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(-1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(622, 73);
            this.label10.TabIndex = 31;
            this.label10.Text = "Subject Entry";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkBlue;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(-1, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(622, 60);
            this.label1.TabIndex = 32;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // SubjectSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(619, 424);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.BackToMenuButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label1);
            this.Name = "SubjectSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subject Schedule";
            this.Load += new System.EventHandler(this.SubjectSchedule_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.DaysGroupBox.ResumeLayout(false);
            this.DaysGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox RoomTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SubjectEDPCodeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox SubjectCodeTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.DateTimePicker TimeStart;
        private System.Windows.Forms.DateTimePicker TimeEnd;
        private System.Windows.Forms.GroupBox DaysGroupBox;
        private System.Windows.Forms.CheckBox SaturdayCheckBox;
        private System.Windows.Forms.CheckBox FridayCheckBox;
        private System.Windows.Forms.CheckBox ThursdayCheckBox;
        private System.Windows.Forms.CheckBox WednesdayCheckBox;
        private System.Windows.Forms.CheckBox TuesdayCheckBox;
        private System.Windows.Forms.CheckBox MondayCheckBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button BackToMenuButton;
        private System.Windows.Forms.ComboBox SchoolYearComboBox;
        private System.Windows.Forms.ComboBox SectionComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}