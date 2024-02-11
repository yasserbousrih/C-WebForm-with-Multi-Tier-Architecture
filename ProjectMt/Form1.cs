using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmpProj;

namespace EmpProj3
{
    public partial class Form1 : Form
    {
        internal enum Grids
        {
            Students,
            Enrollments,
            Courses,
            Programs
        }

        internal static Form1 current;

        private Grids grid;

        private bool OKToChange = true;

        public Form1()
        {
            current = this;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Students, Enrollments, Courses & Programs";
            dataGridView1.Dock = DockStyle.Fill;
            new StudentsF();
            new Courses();
            new Programs();
            new Enrollments();
        }


        private void studentsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (OKToChange)
            {
                grid = Grids.Students;
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                bindingSource1.DataSource = Business.Students.GetStudents();
                bindingSource1.Sort = "StId";
                dataGridView1.DataSource = bindingSource1;

                dataGridView1.Columns["StName"].HeaderText = "Student Name";
                dataGridView1.Columns["StId"].HeaderText = "Student ID";
                dataGridView1.Columns["ProgId"].HeaderText = "Program ID";
                dataGridView1.Columns["StId"].DisplayIndex = 0;
                dataGridView1.Columns["StName"].DisplayIndex = 1;
                dataGridView1.Columns["ProgId"].DisplayIndex = 2;
            }
        }

        private void enrollmentsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            if (OKToChange)
            {
                grid = Grids.Enrollments;
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                bindingSource2.DataSource = Business.Enrollments.GetEnrollments();
                bindingSource2.Sort = "StId, CId";
                dataGridView1.DataSource = bindingSource2;
                dataGridView1.Columns["StId"].HeaderText = "Student ID";
                dataGridView1.Columns["CId"].HeaderText = "Course ID";
                dataGridView1.Columns["finalGrade"].HeaderText = "Final Grade";
                dataGridView1.Columns["StId"].DisplayIndex = 0;
                dataGridView1.Columns["CId"].DisplayIndex = 1;
                dataGridView1.Columns["finalGrade"].DisplayIndex = 2;
            }
        }

        private void coursesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (OKToChange)
            {
                grid = Grids.Courses;
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                bindingSource3.DataSource = Business.Courses.GetCourses();
                bindingSource3.Sort = "CId";
                dataGridView1.DataSource = bindingSource3;

                dataGridView1.Columns["CName"].HeaderText = "Course Name";
                dataGridView1.Columns["CId"].HeaderText = "Course ID";
                dataGridView1.Columns["ProgId"].HeaderText = "Program ID";

                dataGridView1.Columns["CId"].DisplayIndex = 0;
                dataGridView1.Columns["CName"].DisplayIndex = 1;
                dataGridView1.Columns["ProgId"].DisplayIndex = 2;
            }
        }

        private void programsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (OKToChange)
            {
                grid = Grids.Programs;
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                bindingSource4.DataSource = Business.Programs.GetPrograms();
                bindingSource4.Sort = "ProgId";
                dataGridView1.DataSource = bindingSource4;

                dataGridView1.Columns["ProgName"].HeaderText = "Program Name";
                dataGridView1.Columns["ProgId"].HeaderText = "Program ID";

                dataGridView1.Columns["ProgId"].DisplayIndex = 0;
                dataGridView1.Columns["ProgName"].DisplayIndex = 1;
            }
        }



        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (Business.Students.UpdateStudents() == -1)
            {
                bindingSource1.ResetBindings(false);
            }
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            if (Business.Enrollments.UpdateEnrollments() == -1)
            {
                bindingSource2.ResetBindings(false);
            }
        }

        private void bindingSource3_CurrentChanged(object sender, EventArgs e)
        {
            if (Business.Courses.UpdateCourses() == -1)
            {
                bindingSource3.ResetBindings(false);
            }
        }

        private void bindingSource4_CurrentChanged(object sender, EventArgs e)
        {
            if (Business.Programs.UpdatePrograms() == -1)
            {
                bindingSource4.ResetBindings(false);
            }
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
            OKToChange = true;
            Validate();

            switch (grid)
            {
                case Grids.Students:
                    if (Business.Students.UpdateStudents() == -1)
                    {
                        OKToChange = false;
                    }
                    break;

                case Grids.Enrollments:
                    if (Business.Enrollments.UpdateEnrollments() == -1)
                    {
                        OKToChange = false;
                    }
                    break;

                case Grids.Courses:
                    if (Business.Courses.UpdateCourses() == -1)
                    {
                        OKToChange = false;
                    }
                    break;

                case Grids.Programs:
                    if (Business.Programs.UpdatePrograms() == -1)
                    {
                        OKToChange = false;
                    }
                    break;
            }
        }

        internal static void BLLMessage(string s)
        {
            MessageBox.Show("Business Layer: " + s);
        }

        internal static void DALMessage(string s)
        {
            MessageBox.Show("Data Layer: " + s);
        }



        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Impossible to insert / update");
            e.Cancel = false;
            OKToChange = false;
        }

        private void insertStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            StudentsF.current.Start(StudentsF.StudentMode.INSERT, null);
        }

        private void editStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;

            if (c.Count == 0)
            {
                MessageBox.Show("A line must be selected for update");
            }
            else if (c.Count > 1)
            {
                MessageBox.Show("Only one line must be selected for update");
            }
            else
            {
                StudentsF.current.Start(StudentsF.StudentMode.UPDATE, c);
            }
        }

        private void deleteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;
            if (c.Count == 0)
            {
                MessageBox.Show("At least one line must be selected for deletion");
            }
            else // (c.Count > 1)
            {
                List<string[]> lId = new List<string[]>();
                for (int i = 0; i < c.Count; i++)
                {
                    lId.Add(new string[] { "" + c[i].Cells["StId"].Value,
                                           "" + c[i].Cells["StName"].Value,
                                           "" + c[i].Cells["ProgId"].Value });
                }
                Data.Students.DeleteStudents(lId);
            }
        }



        private void editProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;

            if (c.Count == 0)
            {
                MessageBox.Show("A line must be selected for update");
            }
            else if (c.Count > 1)
            {
                MessageBox.Show("Only one line must be selected for update");
            }
            else
            {
                Programs.current.Start(Programs.ProgramMode.UPDATE, c);
            }
        }

        private void deleteProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;
            if (c.Count == 0)
            {
                MessageBox.Show("At least one line must be selected for deletion");
            }
            else
            {
                List<string[]> lId = new List<string[]>();
                for (int i = 0; i < c.Count; i++)
                {
                    lId.Add(new string[] { "" + c[i].Cells["ProgId"].Value,
                                   "" + c[i].Cells["ProgName"].Value });
                }
                Data.Programs.DeletePrograms(lId);
            }
        }

        private void addProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Programs.current.Start(Programs.ProgramMode.INSERT, null);
        }



        private void editCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;

            if (c.Count == 0)
            {
                MessageBox.Show("A line must be selected for update");
            }
            else if (c.Count > 1)
            {
                MessageBox.Show("Only one line must be selected for update");
            }
            else
            {
                Courses.current.Start(Courses.CourseMode.UPDATE, c);
            }
        }

        private void deleteCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;
            if (c.Count == 0)
            {
                MessageBox.Show("At least one line must be selected for deletion");
            }
            else
            {
                List<string[]> lId = new List<string[]>();
                for (int i = 0; i < c.Count; i++)
                {
                    lId.Add(new string[] { "" + c[i].Cells["CId"].Value,
                               "" + c[i].Cells["CName"].Value,
                               "" + c[i].Cells["ProgId"].Value });
                }
                Data.Courses.DeleteCourses(lId);
            }
        }

        private void addCouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Courses.current.Start(Courses.CourseMode.INSERT, null);
        }

        private void addEnrollmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enrollments.current.Start(Enrollments.EnrollmentMode.INSERT, null);
        }

        private void editEnrollmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;

            if (c.Count == 0)
            {
                MessageBox.Show("A line must be selected for update");
            }
            else if (c.Count > 1)
            {
                MessageBox.Show("Only one line must be selected for update");
            }
            else
            {
                Enrollments.current.Start(Enrollments.EnrollmentMode.UPDATE, c);
            }
        }

        private void deleteEnrollmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;
            if (c.Count == 0)
            {
                MessageBox.Show("At least one line must be selected for deletion");
            }
            else
            {
                List<string[]> lId = new List<string[]>();
                for (int i = 0; i < c.Count; i++)
                {
                    lId.Add(new string[] { "" + c[i].Cells["StId"].Value,
                                   "" + c[i].Cells["CId"].Value,
                                   "" + c[i].Cells["FinalGrade"].Value });
                }
                Data.Enrollments.DeleteEnrollments(lId);
            }
        }

        private void manageFinalGradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;
            if (c.Count == 0)
            {
                MessageBox.Show("A line must be selected for final grade");
            }
            else if (c.Count > 1)
            {
                MessageBox.Show("Only one line must be selected for update");
            }
            else
            {
                Enrollments.current.Start(Enrollments.EnrollmentMode.FINALGRADE, c);
            }
        }
    }
}
