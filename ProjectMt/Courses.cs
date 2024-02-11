using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpProj
{
    public partial class Courses : Form
    {
        internal static Courses current;
        public Courses()
        {
            if (current == null)
            {
                current = this;
            }
            InitializeComponent();
        }
        internal enum CourseMode
        {
            INSERT,
            UPDATE
        }
        private CourseMode mode = CourseMode.INSERT;
        private string[] assignInitial;
        internal void Start(CourseMode m, DataGridViewSelectedRowCollection c)
        {
            mode = m;
            Text = "" + mode;

            DataTable coursesTable = Data.Courses.GetCourses();

            if (coursesTable.Rows.Count > 0)
            {
                DataRow courseRow = coursesTable.Rows[0];

                CId.Text = courseRow["CId"].ToString();
                CName.Text = courseRow["CName"].ToString();
                ProgId.DisplayMember = "ProgId";
                ProgId.ValueMember = "ProgId";
                ProgId.DataSource = Data.Programs.GetPrograms(); ;
                ProgId.DropDownStyle = ComboBoxStyle.DropDownList;
                ProgId.SelectedIndex = 0;

                if (mode == CourseMode.UPDATE && c != null && c.Count > 0)
                {
                    CId.Text = c[0].Cells["CId"].Value.ToString();
                    CName.Text = c[0].Cells["CName"].Value.ToString();
                    ProgId.Text = c[0].Cells["ProgId"].Value.ToString();
                    assignInitial = new string[] { c[0].Cells["CId"].Value.ToString(), c[0].Cells["CName"].Value.ToString(), c[0].Cells["ProgId"].Value.ToString() };
                }

                ShowDialog();
            }
            else
            {
                MessageBox.Show("No courses found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int r = -1;

            if (mode == CourseMode.INSERT)
            {
                r = Data.Courses.InsertCourse(new string[] { CId.Text, CName.Text, ProgId.Text });
            }

            if (mode == CourseMode.UPDATE)
            {
                List<string[]> lId = new List<string[]>();
                lId.Add(assignInitial);
                r = Data.Courses.DeleteCourses(lId);



                if (r == 0)
                {
                    
                    r = Data.Courses.InsertCourse(new string[] { CId.Text, CName.Text, ProgId.Text });
                }

                // Close the form if everything is successful
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
