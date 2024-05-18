using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void SubjectEntryFormButton_Click(object sender, EventArgs e)
        {
            SubjectEntry subjectEntry = new SubjectEntry();
            this.Hide();
            subjectEntry.ShowDialog();
            this.Close();
        }

        private void SubjectScheduleEntryFormButton_Click(object sender, EventArgs e)
        {
            SubjectSchedule subjectSchedule = new SubjectSchedule();
            this.Hide();
            subjectSchedule.ShowDialog();
            this.Close();
        }

        private void EnrollmentEntryFormButton_Click(object sender, EventArgs e)
        {
            EnrollmentEntryForm enrollmentEntryForm = new EnrollmentEntryForm();
            this.Hide();
            enrollmentEntryForm.ShowDialog();
            this.Close();
        }
    }
}
