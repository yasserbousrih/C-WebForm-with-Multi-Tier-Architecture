using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EmpProj.Programs;

namespace EmpProj
{
    public partial class Programs : Form
    {
        internal static Programs current;

        public Programs()
        {
            if (current == null)
            {
                current = this;
            }
            InitializeComponent();
        }

        internal void Start(ProgramMode m, DataGridViewSelectedRowCollection c)
        {
            mode = m;
            Text = "" + mode;

            DataTable programsTable = Data.Programs.GetPrograms();

            if (programsTable.Rows.Count > 0)
            {
                DataRow programRow = programsTable.Rows[0];

                ProgId.Text = programRow["ProgId"].ToString();
                ProgName.Text = programRow["ProgName"].ToString();

                if (mode == ProgramMode.UPDATE && c != null && c.Count > 0)
                {
                    ProgId.Text = c[0].Cells["ProgId"].Value.ToString();
                    ProgName.Text = c[0].Cells["ProgName"].Value.ToString();
                    assignInitial = new string[] { c[0].Cells["ProgId"].Value.ToString(), c[0].Cells["ProgName"].Value.ToString() };
                }

                ShowDialog();
            }
            else
            {
                MessageBox.Show("No programs found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        internal enum ProgramMode
        {
            INSERT,
            UPDATE
        }

        private ProgramMode mode = ProgramMode.INSERT;

        private string[] assignInitial;

        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                int r = -1;

                if (mode == ProgramMode.INSERT)
                {
                    r = Data.Programs.InsertProgram(new string[] { ProgId.Text, ProgName.Text });
                }

                if (mode == ProgramMode.UPDATE)
                {
                    List<string[]> lId = new List<string[]>();
                    lId.Add(assignInitial);
                    r = Data.Programs.DeletePrograms(lId);

                    if (r == 0)
                    {
                        r = Data.Programs.InsertProgram(new string[] { ProgId.Text, ProgName.Text });

                        
                    }

                    
                    Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
