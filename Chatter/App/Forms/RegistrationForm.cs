using System;
using System.Windows.Forms;
using System.IO;
using App.App;

namespace App
{
    public partial class RegistrationForm : Form
    {
        private RegistrationValidator registrationValidator = new RegistrationValidator();
        private string message;

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {
            registrationValidator.IsPasswordValid(passwordText.Text, out message);
            passwordLabel.Text = message;
            registrationValidator.IsPasswordMatch(passwordText.Text, password2Text.Text, out message);
            password2Label.Text = message;
        }

        private void Password2Text_TextChanged(object sender, EventArgs e)
        {
            registrationValidator.IsPasswordMatch(passwordText.Text, password2Text.Text, out message);
            password2Label.Text = message;
        }

        private void NicknameText_Leave(object sender, EventArgs e)
        {
            registrationValidator.IsUserNameValid(nicknameText.Text, out message);
            nicknameLabel.Text = message;
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if(registrationValidator.IsAccepted(nicknameText.Text, passwordText.Text, password2Text.Text))
            {
                UserRegistry userRegistry = new UserRegistry();
                userRegistry.CreateUser(ChatServer.Encryptor.Encrypt(nicknameText.Text), ChatServer.Encryptor.Encrypt(passwordText.Text), (string)userTypeBox.SelectedItem);
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
    }
}
