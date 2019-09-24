namespace Chattter
{
    partial class RateForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonsGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.ignoreButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.radioButtonsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonsGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.submitButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ignoreButton, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(604, 270);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(598, 67);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please rate the conversation!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButtonsGroupBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.radioButtonsGroupBox, 2);
            this.radioButtonsGroupBox.Controls.Add(this.radioButton1);
            this.radioButtonsGroupBox.Controls.Add(this.radioButton2);
            this.radioButtonsGroupBox.Controls.Add(this.radioButton3);
            this.radioButtonsGroupBox.Controls.Add(this.radioButton4);
            this.radioButtonsGroupBox.Controls.Add(this.radioButton5);
            this.radioButtonsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonsGroupBox.Location = new System.Drawing.Point(3, 70);
            this.radioButtonsGroupBox.Name = "radioButtonsGroupBox";
            this.radioButtonsGroupBox.Size = new System.Drawing.Size(598, 129);
            this.radioButtonsGroupBox.TabIndex = 1;
            this.radioButtonsGroupBox.TabStop = false;
            this.radioButtonsGroupBox.Text = "What is your evaluation?";
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(40, 54);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(37, 21);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(160, 54);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(37, 21);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "2";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(280, 54);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(37, 21);
            this.radioButton3.TabIndex = 8;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "3";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(400, 54);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(37, 21);
            this.radioButton4.TabIndex = 9;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "4";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(522, 54);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(37, 21);
            this.radioButton5.TabIndex = 10;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "5";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            this.radioButton5.Checked = true;
            // 
            // ignoreButton
            // 
            this.ignoreButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ignoreButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ignoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ignoreButton.Location = new System.Drawing.Point(15, 217);
            this.ignoreButton.Margin = new System.Windows.Forms.Padding(15);
            this.ignoreButton.Name = "ignoreButton";
            this.ignoreButton.Size = new System.Drawing.Size(272, 38);
            this.ignoreButton.TabIndex = 2;
            this.ignoreButton.Text = "Ignore";
            this.ignoreButton.UseVisualStyleBackColor = false;
            this.ignoreButton.Click += new System.EventHandler(this.IgnoreButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.submitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(317, 217);
            this.submitButton.Margin = new System.Windows.Forms.Padding(15);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(272, 38);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // RateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 270);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RateForm";
            this.Text = "RateFrom";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.radioButtonsGroupBox.ResumeLayout(false);
            this.radioButtonsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox radioButtonsGroupBox;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button ignoreButton;
    }
}