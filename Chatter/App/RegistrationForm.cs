using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace App
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {
            if(this.passwordText.Text.Length<6)
                this.passwordLabel.Text = "minimum 6 char password";
            else
                this.passwordLabel.Text = "password OK";
            PasswordMatch();
        }

        private void Password2Text_TextChanged(object sender, EventArgs e)
        {
            PasswordMatch();
        }
        private void PasswordMatch()
        {
            if (!(this.passwordText.Text.Equals(this.password2Text.Text)))
                this.password2Label.Text = "passwords do not match!";
            else
                this.password2Label.Text = "password OK";
        }

        private void NicknameText_Leave(object sender, EventArgs e)
        {
            if (this.nicknameText.Text.Length < 5)
                this.nicknameLabel.Text = "minimum 5 char nick";
            else
                this.nicknameLabel.Text = "nick OK";
        }

        private void cButton_Click(object sender, EventArgs e)
        {
            string filePath = @".\data.txt";
            if (validDataEntered())
            {
                User newUser = new User();
                newUser.UserName = nicknameText.Text;
                newUser.UserType = (string)userTypeBox.SelectedItem;
                newUser.Password = passwordText.Text;
                addData(newUser.UserName, newUser.UserType, newUser.Password, filePath);
                Dispose();
            }
            else
            {
                this.versionLabel.Text = "BAD DATA ENTERED";
                Timer timer = new Timer()
                {
                    Interval = 1000,
                    Enabled = true
                };

                timer.Tick += (tsender, ev) => {
                    this.versionLabel.Text = "Version v1.1";

                    timer.Dispose();
                };
            }

        }
        private bool validDataEntered()
        {
            if (this.nicknameLabel.Text == "nick OK" && this.passwordLabel.Text == "password OK" && this.password2Label.Text == "password OK")
                return true;
            else return false;
        }
        private void addData(string nick, string userType, string password, string filePath)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(filePath, true))
                {
                    file.WriteLine(nick + "," + password + "," + userType);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error with a text file: ", ex);
            }
        }

        private void VersionLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
