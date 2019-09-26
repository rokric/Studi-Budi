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
    public partial class LoginForm : Form
    {
        public string UserName { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        #region Events
        private void PasswordText_TextChanged(object sender, EventArgs e)
        {
            if (this.passwordText.Text.Length < 6)
                this.passwordLabel.Text = "minimum 6 char password";
            else
                this.passwordLabel.Text = "password OK";
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
                UserName = nicknameText.Text;
                ChatClient.ChatForm user = new ChatClient.ChatForm(UserName);
                user.Show();
                user.ConnectToServer();

                addData(this.nicknameText.Text, this.passwordText.Text, filePath);

                var mainForm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "MainForm").FirstOrDefault();
                if(mainForm != null)
                {
                    mainForm.Close();
                }

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
            if (this.nicknameLabel.Text == "nick OK" && this.passwordLabel.Text == "password OK")
                return true;
            else return false;
        }
        private void addData(string nick, string password, string filePath)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(filePath, true))
                {
                    file.WriteLine(nick + "," + password);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error with a text file: ", ex);
            }
        }
        #endregion

        private void NoAccountButton_Click(object sender, EventArgs e)
        {
            Dispose();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
        }
    }
}
