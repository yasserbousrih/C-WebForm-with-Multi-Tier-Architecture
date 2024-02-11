using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmpProj
{
    public partial class Enrollments : Form
    {

        internal static Enrollments current;

        public Enrollments()
        {
            current = this;
            InitializeComponent();
        }

        internal enum EnrollmentMode
        {
            INSERT,
            FINALGRADE,
            UPDATE
        }
        private EnrollmentMode mode = EnrollmentMode.INSERT;
        private string[] assignInitial;


        internal void Start(EnrollmentMode m, DataGridViewSelectedRowCollection c)
        {
            mode = m;
            Text = "" + mode;


            StId.DisplayMember = "StId";
            StId.ValueMember = "StId";
            StId.DataSource = Data.Students.GetStudents();
            StId.DropDownStyle = ComboBoxStyle.DropDownList;
            StId.SelectedIndex = 0;

            CId.DisplayMember = "CId";
            CId.ValueMember = "CId";
            CId.DataSource = Data.Courses.GetCourses();
            CId.DropDownStyle = ComboBoxStyle.DropDownList;
            CId.SelectedIndex = 0;

            FinalGrade.ReadOnly = true;


            if (((mode == EnrollmentMode.UPDATE) || (mode == EnrollmentMode.FINALGRADE)) && (c != null))
            {
                StId.SelectedValue = c[0].Cells["StId"].Value;
                CId.SelectedValue = c[0].Cells["CId"].Value;
                FinalGrade.Text = "" + c[0].Cells["FinalGrade"].Value;
                assignInitial = new string[] { (string)c[0].Cells["StId"].Value, (string)c[0].Cells["CId"].Value };
            }

            if (mode == EnrollmentMode.UPDATE)
            {
                FinalGrade.Enabled = false;
                StId.Enabled = true;
                CId.Enabled = true;
            }
            if (mode == EnrollmentMode.FINALGRADE)
            {
                FinalGrade.Enabled = true;
                FinalGrade.ReadOnly = false;
                StId.Enabled = false;
                CId.Enabled = false;
            }

            // Show the form
            ShowDialog();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int r = -1;

            if (mode == EnrollmentMode.INSERT)
            {
                r = Data.Enrollments.InsertEnrollment(new string[] { (string)StId.SelectedValue, (string)CId.SelectedValue });
            }

            if (mode == EnrollmentMode.UPDATE)
            {

                List<string[]> lId = new List<string[]>();
                lId.Add(assignInitial);
                r = Data.Enrollments.InsertEnrollment(new string[] { (string)StId.SelectedValue, (string)CId.SelectedValue });

                if (r == 0)
                {
                    r = Data.Enrollments.DeleteEnrollments(lId);

                }
            }

            // Update evaluation
            if (mode == EnrollmentMode.FINALGRADE)
            {
                r = Business.Enrollments.ManageFinalGrade(assignInitial, FinalGrade.Text);
            }

            if (r == 0) { Close(); }
        }

        private void StId_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
