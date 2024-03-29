﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using App.App;

namespace App
{
    public partial class LoginForm : Form
    {
        private LoginValidator loginValidator = new LoginValidator();

        public LoginForm()
        {
            InitializeComponent();
        }

        #region Events
        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if(loginValidator.IsCorrect(ChatServer.Encryptor.Encrypt(nicknameText.Text), ChatServer.Encryptor.Encrypt(passwordText.Text), (string)userTypeBox.SelectedItem))
            {
                UserLoader userLoader = new UserLoader();
                userLoader.LoadUser(ChatServer.Encryptor.Encrypt(nicknameText.Text), ChatServer.Encryptor.Encrypt(passwordText.Text), (string)userTypeBox.SelectedItem);
                Dispose();
            }
            else
            {
                nicknameText.Text = "";
                passwordText.Text = "";
                versionLabel.Text = "BAD DATA ENTERED";
                Timer timer = new Timer()
                {
                    Interval = 2000,
                    Enabled = true
                };

                timer.Tick += (tsender, ev) => {
                    versionLabel.Text = "Version v1.1";

                    timer.Dispose();
                };
            }
        }

        private void NoAccountButton_Click(object sender, EventArgs e)
        {
            Dispose();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
        }
        #endregion
    }
}
