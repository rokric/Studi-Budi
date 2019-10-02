namespace App
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.nicknameText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.password2Text = new System.Windows.Forms.TextBox();
            this.registrationLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.password2Label = new System.Windows.Forms.Label();
            this.nicknameLabel = new System.Windows.Forms.Label();
            this.continueButton = new System.Windows.Forms.Button();
            this.userTypeBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // nicknameText
            // 
            this.nicknameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nicknameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nicknameText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nicknameText.Location = new System.Drawing.Point(12, 106);
            this.nicknameText.MaxLength = 14;
            this.nicknameText.Name = "nicknameText";
            this.nicknameText.Size = new System.Drawing.Size(224, 23);
            this.nicknameText.TabIndex = 0;
            this.nicknameText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nicknameText.Leave += new System.EventHandler(this.NicknameText_Leave);
            // 
            // passwordText
            // 
            this.passwordText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.passwordText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.passwordText.Location = new System.Drawing.Point(12, 153);
            this.passwordText.MaxLength = 14;
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '●';
            this.passwordText.Size = new System.Drawing.Size(224, 23);
            this.passwordText.TabIndex = 1;
            this.passwordText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordText.TextChanged += new System.EventHandler(this.PasswordText_TextChanged);
            // 
            // password2Text
            // 
            this.password2Text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.password2Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.password2Text.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.password2Text.Location = new System.Drawing.Point(12, 199);
            this.password2Text.MaxLength = 14;
            this.password2Text.Name = "password2Text";
            this.password2Text.PasswordChar = '●';
            this.password2Text.Size = new System.Drawing.Size(224, 23);
            this.password2Text.TabIndex = 2;
            this.password2Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.password2Text.TextChanged += new System.EventHandler(this.Password2Text_TextChanged);
            // 
            // registrationLabel
            // 
            this.registrationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.registrationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrationLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.registrationLabel.Location = new System.Drawing.Point(17, 13);
            this.registrationLabel.Name = "registrationLabel";
            this.registrationLabel.Size = new System.Drawing.Size(222, 23);
            this.registrationLabel.TabIndex = 3;
            this.registrationLabel.Text = "Registration";
            this.registrationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.versionLabel.Location = new System.Drawing.Point(14, 304);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(224, 20);
            this.versionLabel.TabIndex = 4;
            this.versionLabel.Text = "Version v1.2";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.passwordLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.passwordLabel.Location = new System.Drawing.Point(12, 130);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(224, 20);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "password:";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // password2Label
            // 
            this.password2Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.password2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.password2Label.ForeColor = System.Drawing.SystemColors.Control;
            this.password2Label.Location = new System.Drawing.Point(12, 177);
            this.password2Label.Name = "password2Label";
            this.password2Label.Size = new System.Drawing.Size(224, 19);
            this.password2Label.TabIndex = 6;
            this.password2Label.Text = "confirm password:";
            this.password2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nicknameLabel
            // 
            this.nicknameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nicknameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nicknameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.nicknameLabel.Location = new System.Drawing.Point(12, 84);
            this.nicknameLabel.Name = "nicknameLabel";
            this.nicknameLabel.Size = new System.Drawing.Size(224, 19);
            this.nicknameLabel.TabIndex = 7;
            this.nicknameLabel.Text = "nickname:";
            this.nicknameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cButton
            // 
            this.continueButton.AutoSize = true;
            this.continueButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.continueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.continueButton.ForeColor = System.Drawing.SystemColors.Control;
            this.continueButton.Location = new System.Drawing.Point(73, 238);
            this.continueButton.Name = "cButton";
            this.continueButton.Size = new System.Drawing.Size(100, 28);
            this.continueButton.TabIndex = 8;
            this.continueButton.Text = "continue";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // userTypeBox
            // 
            this.userTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userTypeBox.FormattingEnabled = true;
            this.userTypeBox.Items.AddRange(new object[] {
            "teacher",
            "student"});
            this.userTypeBox.Location = new System.Drawing.Point(73, 56);
            this.userTypeBox.Name = "userTypeBox";
            this.userTypeBox.Size = new System.Drawing.Size(121, 25);
            this.userTypeBox.TabIndex = 9;
            this.userTypeBox.SelectedIndex = 0;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(255, 327);
            this.Controls.Add(this.userTypeBox);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.nicknameLabel);
            this.Controls.Add(this.password2Label);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.registrationLabel);
            this.Controls.Add(this.password2Text);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.nicknameText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrationForm";
            this.Text = "Study buddy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nicknameText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.TextBox password2Text;
        private System.Windows.Forms.Label registrationLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label password2Label;
        private System.Windows.Forms.Label nicknameLabel;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.ComboBox userTypeBox;
    }
}

