using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Enrollment_System
{
    public partial class SubjectEntry : Form
    {
        public SubjectEntry()
        {
            InitializeComponent();
        }
        //home conncectionstring
        public static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\JohnR\OneDrive\Desktop\Final\Enrollment System\Enrollment System\Gomez.accdb";
        //lab conncetionstring 
        //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\Server2\second semester 2023-2024\LAB802\79960_CC_APPSDEV22_0500_0630_PM_MW\79960-23246366\Desktop\Enrollment-System-master\Enrollment System\Gomez.accdb";

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Error Trapping
             if (String.IsNullOrEmpty(SubjectCodeTextBox.Text) || String.IsNullOrEmpty(DescriptionTextBox.Text))
            {
                MessageBox.Show("Please input your subject code and it's description!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Checking if they selected combo box
            if (UnitsComboBox.SelectedIndex == 0 || OfferingComboBox.SelectedIndex == 0 || CategoryComboBox.SelectedIndex == 0 || CurriculumYearComboBox.SelectedIndex == 0 || CourseCodeComboBox.SelectedIndex == 0)
            {
                MessageBox.Show("Please fill up all of the combo boxes!","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
            {
                string sql = "SELECT * FROM SUBJECTFILE";
                OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection);
                OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);

                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "SubjectFile");

                DataRow thisRow = thisDataSet.Tables[0].NewRow();
                thisRow["SFSUBJCODE"] = SubjectCodeTextBox.Text;
                thisRow["SFSUBJDESC"] = DescriptionTextBox.Text;
                thisRow["SFSUBJUNITS"] = UnitsComboBox.Text;
                thisRow["SFSUBJREGOFRNG"] = OfferingComboBox.Text.Substring(0, 1);
                thisRow["SFSUBJCATEGORY"] = CategoryComboBox.Text.Substring(0, 3);
                thisRow["SFSUBJCOURSECODE"] = CourseCodeComboBox.Text;
                thisRow["SFSUBJCURRCODE"] = CurriculumYearComboBox.Text.Substring(0,3);

                thisDataSet.Tables["SubjectFile"].Rows.Add(thisRow);
                try
                {
                    thisAdapter.Update(thisDataSet, "SubjectFile");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Duplicate Subject");
                    return;
                }
            }
            MessageBox.Show("Entries Recorded.",
                            "INFORMATION",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            //Requisite Save
            if (!String.IsNullOrEmpty(RequisiteSubjectCodeTextBox.Text))
            {
                using (OleDbConnection requisiteConnection = new OleDbConnection(connectionString))
                {
                    requisiteConnection.Open();
                    string reqSql = "SELECT * FROM SUBJECTPREQFILE";
                    OleDbDataAdapter requisiteAdapter = new OleDbDataAdapter(reqSql, requisiteConnection);
                    OleDbCommandBuilder requisiteBuilder = new OleDbCommandBuilder(requisiteAdapter);

                    DataSet requisiteDataSet = new DataSet();
                    requisiteAdapter.Fill(requisiteDataSet, "SubjectPreqFile");

                    foreach (DataGridViewRow dataGridViewRow in SubjectDataGridView.Rows)
                    {
                        DataRow requisiteRow = requisiteDataSet.Tables[0].NewRow();
                        requisiteRow["SUBJCODE"] = SubjectCodeTextBox.Text;
                        requisiteRow["SUBJPRECODE"] = dataGridViewRow.Cells["SubjectCodeColumn"].Value;
                        requisiteRow["SUBJCATEGORY"] = dataGridViewRow.Cells["UnitsColumn"].Value ?? "";
                        requisiteRow["SUBJCOPRE"] = dataGridViewRow.Cells["CoPreColumn"].Value ?? "";

                        requisiteDataSet.Tables["SubjectPreqFile"].Rows.Add(requisiteRow);
                    }

                    try
                    {
                        requisiteAdapter.Update(requisiteDataSet, "SubjectPreqFile");
                        MessageBox.Show("Requisite Subjects Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            //Clear Inputs
            clearInputs();
        }

        private void RequisiteSubjectCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();

                string sql = "SELECT * FROM SUBJECTFILE";
                thisCommand.CommandText = sql;

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();
                bool found = false;
                string subjectCode = "";
                string description = "";
                string units = "";
                string CoPrerequisite = "";

                //Checking if duplicate
                bool uniqueRequisiteSubject = true;
                foreach (DataGridViewRow dataGridViewRow in SubjectDataGridView.Rows)
                {
                    string existingSubjectCode = dataGridViewRow.Cells["SubjectCodeColumn"].Value?.ToString().ToUpper();
                    string inputSubjectCode = RequisiteSubjectCodeTextBox.Text.ToUpper();
                    if (existingSubjectCode == inputSubjectCode)
                    {
                        uniqueRequisiteSubject = false;
                        break;
                    }
                }
                if (!uniqueRequisiteSubject)
                {
                    MessageBox.Show("Duplicate Requisite Subject","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                //Checking if Co or Prerequisite
                if (CorequisiteRadioButton.Checked)
                {
                    CoPrerequisite = "Co-Requisite";
                }
                else if (PrerequisiteRadioButton.Checked)
                {
                    CoPrerequisite = "Pre-Requisite";
                }
                else
                {
                    MessageBox.Show("Please select if it's Co-requisite or Pre-requisite.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //Check if req subject exists
                while (thisDataReader.Read())
                {
                    if (thisDataReader["SFSUBJCODE"].ToString().Trim().ToUpper() == RequisiteSubjectCodeTextBox.Text.Trim().ToUpper())
                    {
                        found = true;
                        subjectCode = thisDataReader["SFSUBJCODE"].ToString();
                        description = thisDataReader["SFSUBJDESC"].ToString();
                        units = thisDataReader["SFSUBJUNITS"].ToString();
                        break;
                    }
                }

                int index;
                if (found == false)
                {
                    MessageBox.Show("Subject Code Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    index = SubjectDataGridView.Rows.Add();
                    SubjectDataGridView.Rows[index].Cells["SubjectCodeColumn"].Value = subjectCode;
                    SubjectDataGridView.Rows[index].Cells["DescriptionColumn"].Value = description;
                    SubjectDataGridView.Rows[index].Cells["UnitsColumn"].Value = units;
                    SubjectDataGridView.Rows[index].Cells["CoPreColumn"].Value = CoPrerequisite;
                }
                thisConnection.Close();
                thisDataReader.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initializing Combobox
            UnitsComboBox.SelectedIndex = 0;
            OfferingComboBox.SelectedIndex = 0;
            CategoryComboBox.SelectedIndex = 0;
            CourseCodeComboBox.SelectedIndex = 0;
            CurriculumYearComboBox.SelectedIndex = 0;
        }

        private void GoToSubjectSchedule_Click(object sender, EventArgs e)
        {
            SubjectSchedule subjectSchedule = new SubjectSchedule();
            this.Hide();
            subjectSchedule.ShowDialog();
            this.Close();
        }

        private void GoToEnrollmentEntryButton_Click(object sender, EventArgs e)
        {
            EnrollmentEntryForm enrollmentEntryForm = new EnrollmentEntryForm();
            this.Hide();
            enrollmentEntryForm.ShowDialog();
            this.Close();
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
            SubjectCodeTextBox.Text = "";
            DescriptionTextBox.Text = "";
            UnitsComboBox.SelectedIndex = 0;
            OfferingComboBox.SelectedIndex = 0;
            CategoryComboBox.SelectedIndex = 0;
            OfferingComboBox.SelectedIndex = 0;
            CourseCodeComboBox.SelectedIndex = 0;
            CurriculumYearComboBox.SelectedIndex = 0;
            RequisiteSubjectCodeTextBox.Text = "";
            SubjectDataGridView.Rows.Clear();
        }
    }
}
