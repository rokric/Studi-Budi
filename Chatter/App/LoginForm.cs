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
        public LoginForm()
        {
            InitializeComponent();
        }

        #region Events
        private void ContinueButton_Click(object sender, EventArgs e)
        {
            User tempUser = new User();
            tempUser.UserName = nicknameText.Text;
            tempUser.Password = passwordText.Text;
            tempUser.UserType = (string)userTypeBox.SelectedItem;

            if (DoesUserExist(tempUser))
            {
                foreach (Form form in Application.OpenForms)
                {
                    ///TODO
                    //for some reasons the returned form name is MainFrom instead of MainForm
                    if (form.Name == "MainFrom")
                    {
                        form.Hide();
                        break;
                    }

                }

                Dispose();
                ContentForm contentForm = new ContentForm(tempUser);
                contentForm.ShowDialog();
            }  
            else
            {
                this.nicknameText.Text = "";
                this.passwordText.Text = "";
                this.versionLabel.Text = "BAD DATA ENTERED";
                Timer timer = new Timer()
                {
                    Interval = 2000,
                    Enabled = true
                };

                timer.Tick += (tsender, ev) => {
                    this.versionLabel.Text = "Version v1.1";

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

        private bool DoesUserExist(User user)
        {
            string filePath = @".\data.txt";
            bool found = false;

            using (StreamReader file = new StreamReader(filePath))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    if(user.UserName == data[0] && user.Password == data[1] && user.UserType == data[2])
                    {
                        found = true;
                        break;
                    }
                }
                file.Close();
            }

            return found;
        }
    }
}
