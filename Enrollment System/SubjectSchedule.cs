using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class SubjectSchedule : Form
    {
        public SubjectSchedule()
        {
            InitializeComponent();
        }
        private void GoToSubjectEntry_Click(object sender, EventArgs e)
        {
            SubjectEntry subjectEntry = new SubjectEntry();
            this.Hide();
            subjectEntry.ShowDialog();
            this.Close();
        }

        private void SubjectSchedule_Load(object sender, EventArgs e)
        {
            this.TimeStart.CustomFormat = "hh:mm tt";
            this.TimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimeStart.ShowUpDown = true;
            this.TimeEnd.CustomFormat = "hh:mm tt";
            this.TimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimeEnd.ShowUpDown = true;

            //Initializing Combobox
            SectionComboBox.SelectedIndex = 0;
            SchoolYearComboBox.SelectedIndex = 0;
        }
        string connectionString = SubjectEntry.connectionString;
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Checking if they selected combo box
            if (SectionComboBox.SelectedIndex == 0 || SchoolYearComboBox.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Section and School Year!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int a = 0;
            //Error Trapping
            if (int.TryParse(SubjectEDPCodeTextBox.Text, out a) == false || int.TryParse(RoomTextBox.Text, out a) == false)
            {
                MessageBox.Show("Subject EDP Code & Room Number must be in numbers!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!checkAtleastOneDays(DaysGroupBox))
            {
                MessageBox.Show("Please select the subject's schedule.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Check if subject exists
            bool subjectExists = false;
            using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
            {
                thisConnection.Open();
                using (OleDbCommand thisCommand = thisConnection.CreateCommand())
                {
                    thisCommand.CommandText = "SELECT * FROM SUBJECTFILE";
                    using (OleDbDataReader thisDataReader = thisCommand.ExecuteReader())
                    {
                        while (thisDataReader.Read())
                        {
                            if (thisDataReader["SFSUBJCODE"].ToString().Trim().ToUpper() == SubjectCodeTextBox.Text.Trim().ToUpper())
                            {
                                subjectExists = true;
                                DescriptionTextBox.Text = thisDataReader["SFSUBJDESC"].ToString().Trim();
                                break;
                            }
                        }
                    }
                }
            }

            //If subject does not exist
            if (!subjectExists)
            {
                MessageBox.Show("Subject Does Not Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Save Days Selected
            string daysSelected = "";
            if (MondayCheckBox.Checked) daysSelected += "M";
            if (TuesdayCheckBox.Checked) daysSelected += "T";
            if (WednesdayCheckBox.Checked) daysSelected += "W";
            if (ThursdayCheckBox.Checked) daysSelected += "H";
            if (FridayCheckBox.Checked) daysSelected += "F";
            if (SaturdayCheckBox.Checked) daysSelected += "S";

            using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
            {
                thisConnection.Open();
                string sql = "SELECT * FROM SubjectSchedFile";
                using (OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection))
                {
                    OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);
                    DataSet thisDataSet = new DataSet();
                    thisAdapter.Fill(thisDataSet, "SubjectSchedFile");

                    DataRow thisRow = thisDataSet.Tables["SubjectSchedFile"].NewRow();
                    thisRow["SSFEDPCODE"] = SubjectEDPCodeTextBox.Text;
                    thisRow["SSFSUBJCODE"] = SubjectCodeTextBox.Text.ToUpper();
                    DateTime startTime;
                    DateTime endTime;

                    if (DateTime.TryParse(TimeStart.Text, out startTime) && DateTime.TryParse(TimeEnd.Text, out endTime))
                    {
                        thisRow["SSFSTARTTIME"] = startTime.ToString("hh:mm:ss tt").ToUpper(); // Format time only
                        thisRow["SSFENDTIME"] = endTime.ToString("hh:mm:ss tt").ToUpper();     // Format time only
                    }
                    else
                    {
                        MessageBox.Show("Invalid time format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    thisRow["SSFDAYS"] = daysSelected;
                    thisRow["SSFSECTION"] = SectionComboBox.Text;
                    thisRow["SSFROOM"] = RoomTextBox.Text;
                    thisRow["SSFSCHOOLYEAR"] = SchoolYearComboBox.Text;

                    thisDataSet.Tables["SubjectSchedFile"].Rows.Add(thisRow);

                    try
                    {
                        thisAdapter.Update(thisDataSet, "SubjectSchedFile");
                        MessageBox.Show("Entries Recorded.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Error saving data: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            //Clear Inputs
            clearInput();
        }
        public void clearInput()
        {
            SubjectEDPCodeTextBox.Text = "";
            SubjectCodeTextBox.Text = "";
            DescriptionTextBox.Text = "";
            TimeStart.Value = DateTime.Now;
            TimeEnd.Value = DateTime.Now;
            MondayCheckBox.Checked = false;
            TuesdayCheckBox.Checked = false;
            WednesdayCheckBox.Checked = false;
            ThursdayCheckBox.Checked = false;
            FridayCheckBox.Checked = false;
            SaturdayCheckBox.Checked = false;
            SectionComboBox.SelectedIndex = 0;
            SchoolYearComboBox.SelectedIndex = 0;
            RoomTextBox.Text = "";
        }
        bool checkAtleastOneDays(Control DaysGroupBox)
        {
            foreach (Control control in DaysGroupBox.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    return true;
                }
            }
            return false;
        }
        private void BackToMenuButton_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            clearInput();
        }
    }
}
