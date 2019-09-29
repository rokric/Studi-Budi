namespace App
{
    partial class LoginForm
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
        
        #endregion
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.nicknameText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.registrationLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.nicknameLabel = new System.Windows.Forms.Label();
            this.cButton = new System.Windows.Forms.Button();
            this.noAccountButton = new System.Windows.Forms.Button();
            this.userTypeBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // nicknameText
            // 
            this.nicknameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nicknameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nicknameText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nicknameText.Location = new System.Drawing.Point(14, 116);
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
            this.passwordText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.passwordText.Location = new System.Drawing.Point(14, 165);
            this.passwordText.MaxLength = 14;
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '●';
            this.passwordText.Size = new System.Drawing.Size(224, 23);
            this.passwordText.TabIndex = 1;
            this.passwordText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordText.TextChanged += new System.EventHandler(this.PasswordText_TextChanged);
            // 
            // registrationLabel
            // 
            this.registrationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.registrationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrationLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.registrationLabel.Location = new System.Drawing.Point(12, 13);
            this.registrationLabel.Name = "registrationLabel";
            this.registrationLabel.Size = new System.Drawing.Size(227, 32);
            this.registrationLabel.TabIndex = 3;
            this.registrationLabel.Text = "Login";
            this.registrationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.versionLabel.Location = new System.Drawing.Point(14, 315);
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
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.passwordLabel.Location = new System.Drawing.Point(14, 142);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(224, 20);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "password:";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nicknameLabel
            // 
            this.nicknameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nicknameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nicknameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.nicknameLabel.Location = new System.Drawing.Point(14, 94);
            this.nicknameLabel.Name = "nicknameLabel";
            this.nicknameLabel.Size = new System.Drawing.Size(224, 19);
            this.nicknameLabel.TabIndex = 7;
            this.nicknameLabel.Text = "nickname:";
            this.nicknameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cButton
            // 
            this.cButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cButton.AutoSize = true;
            this.cButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cButton.ForeColor = System.Drawing.SystemColors.Control;
            this.cButton.Location = new System.Drawing.Point(77, 202);
            this.cButton.Name = "cButton";
            this.cButton.Size = new System.Drawing.Size(100, 30);
            this.cButton.TabIndex = 8;
            this.cButton.Text = "continue";
            this.cButton.UseVisualStyleBackColor = false;
            this.cButton.Click += new System.EventHandler(this.cButton_Click);
            // 
            // noAccountButton
            // 
            this.noAccountButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noAccountButton.AutoSize = true;
            this.noAccountButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.noAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noAccountButton.ForeColor = System.Drawing.SystemColors.Control;
            this.noAccountButton.Location = new System.Drawing.Point(55, 256);
            this.noAccountButton.Name = "noAccountButton";
            this.noAccountButton.Size = new System.Drawing.Size(140, 30);
            this.noAccountButton.TabIndex = 9;
            this.noAccountButton.Text = "No account yet?";
            this.noAccountButton.UseVisualStyleBackColor = false;
            this.noAccountButton.Click += new System.EventHandler(this.NoAccountButton_Click);
            // 
            // userTypeBox
            // 
            this.userTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userTypeBox.FormattingEnabled = true;
            this.userTypeBox.Items.AddRange(new object[] {
            "teacher",
            "student"});
            this.userTypeBox.Location = new System.Drawing.Point(65, 57);
            this.userTypeBox.Name = "userTypeBox";
            this.userTypeBox.Size = new System.Drawing.Size(130, 25);
            this.userTypeBox.TabIndex = 10;
            this.userTypeBox.SelectedIndex = 0;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(255, 338);
            this.Controls.Add(this.userTypeBox);
            this.Controls.Add(this.noAccountButton);
            this.Controls.Add(this.cButton);
            this.Controls.Add(this.nicknameLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.registrationLabel);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.nicknameText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Study buddy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #region Components
        private System.Windows.Forms.TextBox nicknameText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label registrationLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label nicknameLabel;
        private System.Windows.Forms.Button cButton;
        private System.Windows.Forms.Button noAccountButton;

        #endregion

        private System.Windows.Forms.ComboBox userTypeBox;
    }
}

