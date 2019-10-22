namespace App
{
    partial class TeacherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherForm));
            this.addCourse = new System.Windows.Forms.Button();
            this.deleteCourse = new System.Windows.Forms.Button();
            this.subjectsList = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.subjectsBox = new System.Windows.Forms.ComboBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addCourse
            // 
            this.addCourse.Location = new System.Drawing.Point(288, 285);
            this.addCourse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addCourse.Name = "addCourse";
            this.addCourse.Size = new System.Drawing.Size(135, 44);
            this.addCourse.TabIndex = 0;
            this.addCourse.Text = "Add";
            this.addCourse.UseVisualStyleBackColor = true;
            this.addCourse.Click += new System.EventHandler(this.AddCourse_Click);
            // 
            // deleteCourse
            // 
            this.deleteCourse.Location = new System.Drawing.Point(577, 476);
            this.deleteCourse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteCourse.Name = "deleteCourse";
            this.deleteCourse.Size = new System.Drawing.Size(268, 71);
            this.deleteCourse.TabIndex = 1;
            this.deleteCourse.Text = "Delete course";
            this.deleteCourse.UseVisualStyleBackColor = true;
            this.deleteCourse.Click += new System.EventHandler(this.DeleteCourse_Click);
            // 
            // subjectsList
            // 
            this.subjectsList.HideSelection = false;
            this.subjectsList.Location = new System.Drawing.Point(577, 32);
            this.subjectsList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.subjectsList.Name = "subjectsList";
            this.subjectsList.Size = new System.Drawing.Size(267, 409);
            this.subjectsList.TabIndex = 2;
            this.subjectsList.UseCompatibleStateImageBehavior = false;
            this.subjectsList.View = System.Windows.Forms.View.List;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.subjectsBox);
            this.groupBox1.Controls.Add(this.descriptionTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.addCourse);
            this.groupBox1.Location = new System.Drawing.Point(26, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(462, 364);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add new course";
            // 
            // subjectsBox
            // 
            this.subjectsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subjectsBox.FormattingEnabled = true;
            this.subjectsBox.Location = new System.Drawing.Point(174, 70);
            this.subjectsBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.subjectsBox.Name = "subjectsBox";
            this.subjectsBox.Size = new System.Drawing.Size(248, 28);
            this.subjectsBox.TabIndex = 5;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(174, 126);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(248, 124);
            this.descriptionTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "You can help with:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Subject:";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(26, 476);
            this.connectButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(138, 70);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.subjectsList);
            this.Controls.Add(this.deleteCourse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TeacherForm";
            this.Text = "TeacherForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeacherForm_FormClosing);
            this.Load += new System.EventHandler(this.TeacherForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addCourse;
        private System.Windows.Forms.Button deleteCourse;
        private System.Windows.Forms.ListView subjectsList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox subjectsBox;
        private System.Windows.Forms.Button connectButton;
    }
}