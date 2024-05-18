using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class EnrollmentEntryForm : Form
    {
        public EnrollmentEntryForm()
        {
            InitializeComponent();
        }
        //Global Variables
        string connectionString = SubjectEntry.connectionString;
        int totalUnits = 0;
        bool enteredStudentID = false;
        bool enteredSubjectEDP = false;
        private void IDNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bool studentFound = false;
                using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
                {
                    thisConnection.Open();
                    OleDbCommand thisCommand = thisConnection.CreateCommand();
                    thisCommand.CommandText = "SELECT * FROM StudentFile";
                    OleDbDataReader thisDataReader = thisCommand.ExecuteReader();
                    //Check if ID is in DB
                    while (thisDataReader.Read())
                    {
                        if (thisDataReader["STFSTUDID"].ToString().Trim() == IDNumberTextBox.Text.Trim())
                        {
                            NameTextBox.Text = thisDataReader["STFSTUDFNAME"].ToString() + " " + thisDataReader["STFSTUDLNAME"].ToString();
                            CourseTextBox.Text = thisDataReader["STFSTUDCOURSE"].ToString();
                            YearTextBox.Text = thisDataReader["STFSTUDYEAR"].ToString();

                            studentFound = true;
                            MessageBox.Show("Student ID Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Validate Student ID entered
                            enteredStudentID = true;
                            break;
                        }
                    }

                    if (!studentFound)
                    {
                        MessageBox.Show("Student ID Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private void EDPCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //Checking if duplicate EDP code
                bool uniqueEDPCode = true;
                foreach (DataGridViewRow dataGridViewRow in SubjectDataGridView.Rows)
                {
                    string existingEDPCode = dataGridViewRow.Cells["EDPCodeColumn"].Value?.ToString().ToUpper();
                    string inputEDPCode = EDPCodeTextBox.Text.ToUpper();
                    if (existingEDPCode == inputEDPCode)
                    {
                        uniqueEDPCode = false;
                        break;
                    }
                }
                if (!uniqueEDPCode)
                {
                    MessageBox.Show("Duplicate EDP Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                

                bool edpCodeFound = false;
                string edpCode = "";
                string subjectCode = "";
                DateTime startTime = DateTime.MinValue;
                DateTime endTime = DateTime.MinValue;
                string days = "";
                string room = "";
                string units = "";

                //Checking if EDP Code exists in SubjectSchedFile
                using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
                {
                    thisConnection.Open();
                    string sql = "SELECT * FROM SubjectSchedFile";
                    using (OleDbCommand thisCommand = new OleDbCommand(sql, thisConnection))
                    {
                        using (OleDbDataReader thisDataReader = thisCommand.ExecuteReader())
                        {
                            while (thisDataReader.Read())
                            {
                                if (thisDataReader["SSFEDPCODE"].ToString().Trim() == EDPCodeTextBox.Text.Trim())
                                {
                                    edpCodeFound = true;
                                    edpCode = thisDataReader["SSFEDPCODE"].ToString();
                                    subjectCode = thisDataReader["SSFSUBJCODE"].ToString().ToUpper();
                                    startTime = (DateTime)thisDataReader["SSFSTARTTIME"];
                                    endTime = (DateTime)thisDataReader["SSFENDTIME"];
                                    days = thisDataReader["SSFDAYS"].ToString();
                                    room = thisDataReader["SSFROOM"].ToString();
                                    break;
                                }
                            }
                        }
                    }
                }
                // Check for days conflict
                if (CheckConflict(days, startTime.ToShortTimeString(), endTime.ToShortTimeString(), SubjectDataGridView))
                {
                    MessageBox.Show("There is a conflict with the existing schedule.");
                    return;
                }

                if (edpCodeFound)
                {
                    using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
                    {
                        thisConnection.Open();
                        string unitsQuery = "SELECT SFSUBJUNITS FROM SubjectFile WHERE SFSUBJCODE = ?";
                        using (OleDbCommand unitsCommand = new OleDbCommand(unitsQuery, thisConnection))
                        {
                            unitsCommand.Parameters.AddWithValue("?", subjectCode);
                            units = unitsCommand.ExecuteScalar()?.ToString();
                        }
                    }
                    int index = SubjectDataGridView.Rows.Add();
                    SubjectDataGridView.Rows[index].Cells["EDPCodeColumn"].Value = edpCode;
                    SubjectDataGridView.Rows[index].Cells["SubjectCodeColumn"].Value = subjectCode;
                    SubjectDataGridView.Rows[index].Cells["StartTimeColumn"].Value = startTime.ToShortTimeString();
                    SubjectDataGridView.Rows[index].Cells["EndTimeColumn"].Value = endTime.ToShortTimeString();
                    SubjectDataGridView.Rows[index].Cells["DaysColumn"].Value = days;
                    SubjectDataGridView.Rows[index].Cells["RoomColumn"].Value = room;
                    SubjectDataGridView.Rows[index].Cells["UnitsColumn"].Value = units;

                    //Validate subject entered
                    MessageBox.Show("Subject Added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    enteredSubjectEDP = true;

                    //Add Total Units and display
                    totalUnits += int.Parse(units);
                    TotalUnitsTextBox.Text = totalUnits.ToString();
                }
                else
                {
                    MessageBox.Show("Subject Code Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Clear TextBox
                EDPCodeTextBox.Text = "";
            }
        }
        private bool CheckConflict(string newDays, string newStartTime, string newEndTime, DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["DaysColumn"].Value != null)
                {
                    string existingDays = row.Cells["DaysColumn"].Value.ToString();
                    string existingStartTime = row.Cells["StartTimeColumn"].Value.ToString();
                    string existingEndTime = row.Cells["EndTimeColumn"].Value.ToString();

                    // Check if any of the days in newDays are also in existingDays
                    foreach (char day in newDays)
                    {
                        if (existingDays.Contains(day))
                        {
                            // If there's a day conflict, check start and end times
                            if ((newStartTime.CompareTo(existingEndTime) < 0 && newEndTime.CompareTo(existingStartTime) > 0)
                                || (existingStartTime.CompareTo(newEndTime) < 0 && existingEndTime.CompareTo(newStartTime) > 0))
                            {
                                return true; // Conflict found
                            }
                        }
                    }
                }
            }

            return false; // No conflict found
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Error Trapping
            if (!enteredSubjectEDP || !enteredStudentID)
            {
                MessageBox.Show("Please enter a Student ID or Subject.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(EncodedByTextBox.Text))
            {
                MessageBox.Show("Please enter the Encoder's Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateEnrollDateTimePicker.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date no further than the future.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Variables
            string enrollmentStatus = "Enrolled";
            string activeStatus = "Active";
            int schoolYear = DateEnrollDateTimePicker.Value.Year;
            //Saving to EnrollmentHeaderFile Table
            using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
            {
                string sql = "SELECT * FROM EnrollmentHeaderFile";
                OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection);
                OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);

                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "EnrollmentHeaderFile");

                DataRow thisRow = thisDataSet.Tables[0].NewRow();
                thisRow["ENRHFSTUDID"] = IDNumberTextBox.Text;
                thisRow["ENRHFSTUDDATEENROLL"] = DateEnrollDateTimePicker.Text;
                thisRow["ENRHFSTUDSCHLYR"] = schoolYear.ToString() + " - " + (schoolYear+1).ToString();
                thisRow["ENRHFSTUDENCODER"] = EncodedByTextBox.Text;
                thisRow["ENRHFSTUDTOTALUNITS"] = TotalUnitsTextBox.Text;
                thisRow["ENRHFSTUDSTATUS"] = enrollmentStatus.Substring(0,2);

                thisDataSet.Tables["EnrollmentHeaderFile"].Rows.Add(thisRow);
                try
                {
                    thisAdapter.Update(thisDataSet, "EnrollmentHeaderFile");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("This student is already enrolled.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
            }
            //Setting Student Status to Enrolled
            using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
            {
                thisConnection.Open();
                OleDbCommand updateCommand = thisConnection.CreateCommand();
                updateCommand.CommandText = "UPDATE StudentFile SET STFSTUDSTATUS = ? WHERE STFSTUDID = ?";
                updateCommand.Parameters.AddWithValue("?", activeStatus.Substring(0,2));
                updateCommand.Parameters.AddWithValue("?", IDNumberTextBox.Text.Trim());
                updateCommand.ExecuteNonQuery();
            }
            //Saving to Enrollment Detail File Table
            using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
            {
                string sql = "SELECT * FROM EnrollmentDetailFile";
                OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection);
                OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);

                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "EnrollmentDetailFile");

                foreach (DataGridViewRow dataGridViewRow in SubjectDataGridView.Rows)
                {
                    DataRow thisRow = thisDataSet.Tables[0].NewRow();
                    thisRow["ENRDFSTUDID"] = IDNumberTextBox.Text;
                    thisRow["ENRDFSTUDSUBJCDE"] = dataGridViewRow.Cells["SubjectCodeColumn"].Value;
                    thisRow["ENRDFSTUDEDPCODE"] = dataGridViewRow.Cells["EDPCodeColumn"].Value;
                    thisRow["ENRDFSTUDSTATUS"] = enrollmentStatus.Substring(0,2);

                    thisDataSet.Tables["EnrollmentDetailFile"].Rows.Add(thisRow);
                }
                thisAdapter.Update(thisDataSet, "EnrollmentDetailFile");
                MessageBox.Show("Student Enrolled.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            //Clear Inputs
            clearInputs();
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
            clearInputs();
        }
        public void clearInputs()
        {
            IDNumberTextBox.Text = "";
            NameTextBox.Text = "";
            CourseTextBox.Text = "";
            YearTextBox.Text = "";
            EDPCodeTextBox.Text = "";
            EncodedByTextBox.Text = "";
            TotalUnitsTextBox.Text = "";
            DateEnrollDateTimePicker.Value = DateTime.Now;
            SubjectDataGridView.Rows.Clear();
            totalUnits = 0;
        }

        private void EnrollmentEntryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
