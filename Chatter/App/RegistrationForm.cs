using System;
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
            {
                this.nicknameLabel.Text = "minimum 5 char nick";
            }
            else if (!TextFileClass.CheckIfUserNameIsAvailable(nicknameText.Text))
            {
                this.nicknameLabel.Text = "user name is not available";
            }
            else
            {
                this.nicknameLabel.Text = "nick OK";
            } 
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (ValidDataEntered())
            {
                User newUser = Builder.CreateNewUser((string)userTypeBox.SelectedItem, nicknameText.Text, passwordText.Text);
                Dispose();
            }
            else
            {
                this.versionLabel.Text = "BAD DATA ENTERED";
                Timer timer = new Timer()
                {
                    Interval = 3000,
                    Enabled = true
                };

                timer.Tick += (tsender, ev) => {
                    this.versionLabel.Text = "Version v1.1";

                    timer.Dispose();
                };
            }
        }
        private bool ValidDataEntered()
        {
            if (this.nicknameLabel.Text == "nick OK" && this.passwordLabel.Text == "password OK" && this.password2Label.Text == "password OK")
                return true;
            else return false;
        }
    }
}
