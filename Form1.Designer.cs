namespace CollegeManagementSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.CollegeManagementSystem = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MyProgressBar = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // CollegeManagementSystem
            // 
            this.CollegeManagementSystem.AutoSize = true;
            this.CollegeManagementSystem.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CollegeManagementSystem.ForeColor = System.Drawing.Color.LawnGreen;
            this.CollegeManagementSystem.Location = new System.Drawing.Point(0, 0);
            this.CollegeManagementSystem.Name = "CollegeManagementSystem";
            this.CollegeManagementSystem.Size = new System.Drawing.Size(400, 29);
            this.CollegeManagementSystem.TabIndex = 1;
            this.CollegeManagementSystem.Text = "College Management System";
            this.CollegeManagementSystem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CollegeManagementSystem.Click += new System.EventHandler(this.CollegeManagementSystem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label2.Location = new System.Drawing.Point(306, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Version1.0";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // MyProgressBar
            // 
            this.MyProgressBar.BackColor = System.Drawing.Color.MediumBlue;
            this.MyProgressBar.Location = new System.Drawing.Point(0, 159);
            this.MyProgressBar.Name = "MyProgressBar";
            this.MyProgressBar.Size = new System.Drawing.Size(469, 23);
            this.MyProgressBar.TabIndex = 3;
            this.MyProgressBar.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(471, 186);
            this.Controls.Add(this.MyProgressBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CollegeManagementSystem);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label CollegeManagementSystem;
        private Label label2;
        private ProgressBar MyProgressBar;
        private System.Windows.Forms.Timer timer1;
    }
}