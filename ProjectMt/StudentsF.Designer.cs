namespace EmpProj
{
    partial class StudentsF
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ProgId = new System.Windows.Forms.ComboBox();
            this.StName = new System.Windows.Forms.TextBox();
            this.StId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Program ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Student Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Student ID";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(381, 119);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 28);
            this.button2.TabIndex = 17;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 119);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 28);
            this.button1.TabIndex = 16;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProgId
            // 
            this.ProgId.FormattingEnabled = true;
            this.ProgId.Location = new System.Drawing.Point(355, 62);
            this.ProgId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProgId.Name = "ProgId";
            this.ProgId.Size = new System.Drawing.Size(89, 24);
            this.ProgId.TabIndex = 14;
            // 
            // StName
            // 
            this.StName.Location = new System.Drawing.Point(134, 62);
            this.StName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StName.Name = "StName";
            this.StName.Size = new System.Drawing.Size(178, 22);
            this.StName.TabIndex = 13;
            // 
            // StId
            // 
            this.StId.Location = new System.Drawing.Point(22, 64);
            this.StId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StId.Name = "StId";
            this.StId.Size = new System.Drawing.Size(89, 22);
            this.StId.TabIndex = 24;
            // 
            // StudentsF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 171);
            this.Controls.Add(this.StId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ProgId);
            this.Controls.Add(this.StName);
            this.Name = "StudentsF";
            this.Text = "Students";
            this.Load += new System.EventHandler(this.StudentsF_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ProgId;
        private System.Windows.Forms.TextBox StName;
        private System.Windows.Forms.TextBox StId;
    }
}