namespace EmpProj3
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enrollmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEnrollmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editEnrollmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEnrollmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageFinalGradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coursesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(154, 80);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(213, 120);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 28);
            this.splitter1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 332);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentsToolStripMenuItem,
            this.enrollmentsToolStripMenuItem,
            this.coursesToolStripMenuItem,
            this.programsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(711, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertStudentToolStripMenuItem,
            this.editStudentToolStripMenuItem,
            this.deleteStudentToolStripMenuItem});
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            this.studentsToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.studentsToolStripMenuItem.Text = "Students";
            this.studentsToolStripMenuItem.Click += new System.EventHandler(this.studentsToolStripMenuItem_Click_1);
            // 
            // insertStudentToolStripMenuItem
            // 
            this.insertStudentToolStripMenuItem.Name = "insertStudentToolStripMenuItem";
            this.insertStudentToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.insertStudentToolStripMenuItem.Text = "Add Student";
            this.insertStudentToolStripMenuItem.Click += new System.EventHandler(this.insertStudentToolStripMenuItem_Click);
            // 
            // editStudentToolStripMenuItem
            // 
            this.editStudentToolStripMenuItem.Name = "editStudentToolStripMenuItem";
            this.editStudentToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.editStudentToolStripMenuItem.Text = "Edit Student";
            this.editStudentToolStripMenuItem.Click += new System.EventHandler(this.editStudentToolStripMenuItem_Click);
            // 
            // deleteStudentToolStripMenuItem
            // 
            this.deleteStudentToolStripMenuItem.Name = "deleteStudentToolStripMenuItem";
            this.deleteStudentToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.deleteStudentToolStripMenuItem.Text = "Delete Student";
            this.deleteStudentToolStripMenuItem.Click += new System.EventHandler(this.deleteStudentToolStripMenuItem_Click);
            // 
            // enrollmentsToolStripMenuItem
            // 
            this.enrollmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEnrollmentToolStripMenuItem,
            this.editEnrollmentToolStripMenuItem,
            this.deleteEnrollmentToolStripMenuItem,
            this.manageFinalGradeToolStripMenuItem});
            this.enrollmentsToolStripMenuItem.Name = "enrollmentsToolStripMenuItem";
            this.enrollmentsToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.enrollmentsToolStripMenuItem.Text = "Enrollments";
            this.enrollmentsToolStripMenuItem.Click += new System.EventHandler(this.enrollmentsToolStripMenuItem_Click_1);
            // 
            // addEnrollmentToolStripMenuItem
            // 
            this.addEnrollmentToolStripMenuItem.Name = "addEnrollmentToolStripMenuItem";
            this.addEnrollmentToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.addEnrollmentToolStripMenuItem.Text = "Add Enrollment";
            this.addEnrollmentToolStripMenuItem.Click += new System.EventHandler(this.addEnrollmentToolStripMenuItem_Click);
            // 
            // editEnrollmentToolStripMenuItem
            // 
            this.editEnrollmentToolStripMenuItem.Name = "editEnrollmentToolStripMenuItem";
            this.editEnrollmentToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.editEnrollmentToolStripMenuItem.Text = "Edit Enrollment ";
            this.editEnrollmentToolStripMenuItem.Click += new System.EventHandler(this.editEnrollmentToolStripMenuItem_Click);
            // 
            // deleteEnrollmentToolStripMenuItem
            // 
            this.deleteEnrollmentToolStripMenuItem.Name = "deleteEnrollmentToolStripMenuItem";
            this.deleteEnrollmentToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.deleteEnrollmentToolStripMenuItem.Text = "Delete Enrollment ";
            this.deleteEnrollmentToolStripMenuItem.Click += new System.EventHandler(this.deleteEnrollmentToolStripMenuItem_Click);
            // 
            // manageFinalGradeToolStripMenuItem
            // 
            this.manageFinalGradeToolStripMenuItem.Name = "manageFinalGradeToolStripMenuItem";
            this.manageFinalGradeToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.manageFinalGradeToolStripMenuItem.Text = "Manage Final Grade";
            this.manageFinalGradeToolStripMenuItem.Click += new System.EventHandler(this.manageFinalGradeToolStripMenuItem_Click);
            // 
            // coursesToolStripMenuItem
            // 
            this.coursesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCouseToolStripMenuItem,
            this.editCourseToolStripMenuItem,
            this.deleteCourseToolStripMenuItem});
            this.coursesToolStripMenuItem.Name = "coursesToolStripMenuItem";
            this.coursesToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.coursesToolStripMenuItem.Text = "Courses";
            this.coursesToolStripMenuItem.Click += new System.EventHandler(this.coursesToolStripMenuItem_Click_1);
            // 
            // addCouseToolStripMenuItem
            // 
            this.addCouseToolStripMenuItem.Name = "addCouseToolStripMenuItem";
            this.addCouseToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.addCouseToolStripMenuItem.Text = "Add Course ";
            this.addCouseToolStripMenuItem.Click += new System.EventHandler(this.addCouseToolStripMenuItem_Click);
            // 
            // editCourseToolStripMenuItem
            // 
            this.editCourseToolStripMenuItem.Name = "editCourseToolStripMenuItem";
            this.editCourseToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.editCourseToolStripMenuItem.Text = "Edit Course ";
            this.editCourseToolStripMenuItem.Click += new System.EventHandler(this.editCourseToolStripMenuItem_Click);
            // 
            // deleteCourseToolStripMenuItem
            // 
            this.deleteCourseToolStripMenuItem.Name = "deleteCourseToolStripMenuItem";
            this.deleteCourseToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.deleteCourseToolStripMenuItem.Text = "Delete Course ";
            this.deleteCourseToolStripMenuItem.Click += new System.EventHandler(this.deleteCourseToolStripMenuItem_Click);
            // 
            // programsToolStripMenuItem
            // 
            this.programsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProgramToolStripMenuItem,
            this.editProgramToolStripMenuItem,
            this.deleteProgramToolStripMenuItem});
            this.programsToolStripMenuItem.Name = "programsToolStripMenuItem";
            this.programsToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.programsToolStripMenuItem.Text = "Programs";
            this.programsToolStripMenuItem.Click += new System.EventHandler(this.programsToolStripMenuItem_Click_1);
            // 
            // addProgramToolStripMenuItem
            // 
            this.addProgramToolStripMenuItem.Name = "addProgramToolStripMenuItem";
            this.addProgramToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.addProgramToolStripMenuItem.Text = "Add Program ";
            this.addProgramToolStripMenuItem.Click += new System.EventHandler(this.addProgramToolStripMenuItem_Click);
            // 
            // editProgramToolStripMenuItem
            // 
            this.editProgramToolStripMenuItem.Name = "editProgramToolStripMenuItem";
            this.editProgramToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.editProgramToolStripMenuItem.Text = "Edit Program ";
            this.editProgramToolStripMenuItem.Click += new System.EventHandler(this.editProgramToolStripMenuItem_Click);
            // 
            // deleteProgramToolStripMenuItem
            // 
            this.deleteProgramToolStripMenuItem.Name = "deleteProgramToolStripMenuItem";
            this.deleteProgramToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.deleteProgramToolStripMenuItem.Text = "Delete Program";
            this.deleteProgramToolStripMenuItem.Click += new System.EventHandler(this.deleteProgramToolStripMenuItem_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // bindingSource2
            // 
            this.bindingSource2.CurrentChanged += new System.EventHandler(this.bindingSource2_CurrentChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.BindingSource bindingSource3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enrollmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coursesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programsToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource4;
        private System.Windows.Forms.ToolStripMenuItem insertStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEnrollmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editEnrollmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteEnrollmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageFinalGradeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteProgramToolStripMenuItem;
    }
}

