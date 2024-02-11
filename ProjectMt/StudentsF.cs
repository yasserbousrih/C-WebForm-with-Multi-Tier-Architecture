using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using EmpProj;
using System.Security.Cryptography;

namespace EmpProj
{
    public partial class StudentsF : Form
    {
        internal static StudentsF current;

        public StudentsF()
        {
            if (current == null)
            {
                current = this;
            }
            InitializeComponent();
        }
        internal void Start(StudentMode m, DataGridViewSelectedRowCollection c)
        {
            mode = m;
            Text = "" + mode;

            DataTable studentsTable = Data.Students.GetStudents();

            if (studentsTable.Rows.Count > 0)
            {
                DataRow studentRow = studentsTable.Rows[0];

                StId.Text = studentRow["StId"].ToString();
                StName.Text = studentRow["StName"].ToString();

                ProgId.DisplayMember = "ProgId";
                ProgId.ValueMember = "ProgId";
                ProgId.DataSource = Data.Programs.GetPrograms(); ;
                ProgId.DropDownStyle = ComboBoxStyle.DropDownList;
                ProgId.SelectedIndex = 0;

                StId.ReadOnly = false;
                StName.ReadOnly = false;

                if (mode == StudentMode.UPDATE && c != null && c.Count > 0)
                {
                    StId.Text = c[0].Cells["StId"].Value.ToString();
                    StName.Text = c[0].Cells["StName"].Value.ToString();
                    ProgId.SelectedValue = c[0].Cells["ProgId"].Value;
                    assignInitial = new string[] { c[0].Cells["StId"].Value.ToString(), c[0].Cells["StName"].Value.ToString(), c[0].Cells["ProgId"].Value.ToString() };

                }


                ShowDialog();

            }
            else
            {
                MessageBox.Show("No students found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //StId is a text box 
        //StName is a text box 
        //ProgID is a combo box 
        internal enum StudentMode
        {
            INSERT,
            UPDATE
        }
        

        private StudentMode mode = StudentMode.INSERT;

        private string[] assignInitial;





        private void button1_Click(object sender, EventArgs e)
        {
            int r = -1; 


            if (mode == StudentMode.INSERT)
            {

                r = Data.Students.InsertStudent(new string[] { StId.Text, StName.Text, ProgId.Text });
            }


            if (mode == StudentMode.UPDATE)
            {
                List<string[]> lId = new List<string[]>();
                lId.Add(assignInitial);
               // to work around the unique constrainsts i delete first 
                r = Data.Students.DeleteStudents(lId);
                if (r == 0)
                {
                    r = Data.Students.InsertStudent(new string[] { StId.Text, StName.Text, ProgId.Text });
                }
                Close();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StudentsF_Load(object sender, EventArgs e)
        {

        }
    }
}
