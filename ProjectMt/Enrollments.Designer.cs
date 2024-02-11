namespace EmpProj
{
    partial class Enrollments
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
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.FinalGrade = new System.Windows.Forms.TextBox();
            this.CId = new System.Windows.Forms.ComboBox();
            this.StId = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Final Grade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Course ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Student ID";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(292, 123);
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
            this.button1.Location = new System.Drawing.Point(197, 123);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 28);
            this.button1.TabIndex = 16;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FinalGrade
            // 
            this.FinalGrade.Location = new System.Drawing.Point(271, 62);
            this.FinalGrade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FinalGrade.Name = "FinalGrade";
            this.FinalGrade.Size = new System.Drawing.Size(87, 22);
            this.FinalGrade.TabIndex = 15;
            // 
            // CId
            // 
            this.CId.FormattingEnabled = true;
            this.CId.Location = new System.Drawing.Point(140, 58);
            this.CId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CId.Name = "CId";
            this.CId.Size = new System.Drawing.Size(89, 24);
            this.CId.TabIndex = 14;
            // 
            // StId
            // 
            this.StId.FormattingEnabled = true;
            this.StId.Location = new System.Drawing.Point(15, 58);
            this.StId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StId.Name = "StId";
            this.StId.Size = new System.Drawing.Size(89, 24);
            this.StId.TabIndex = 12;
            this.StId.TextChanged += new System.EventHandler(this.StId_TextChanged);
            // 
            // Enrollments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 173);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FinalGrade);
            this.Controls.Add(this.CId);
            this.Controls.Add(this.StId);
            this.Name = "Enrollments";
            this.Text = "Enrollments";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox FinalGrade;
        private System.Windows.Forms.ComboBox CId;
        private System.Windows.Forms.ComboBox StId;
    }
}