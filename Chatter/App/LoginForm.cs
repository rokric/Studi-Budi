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
            string userName = nicknameText.Text;
            string password = passwordText.Text;
            string userType = (String)userTypeBox.SelectedItem;
            User newUser = null;

            if ((newUser = Builder.LoadUser(userType, userName, password)) != null)
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

                if(newUser.GetType() == "student")
                {
                    StudentForm contentForm = new StudentForm(newUser);
                    contentForm.ShowDialog();
                }
                else if(newUser.GetType() == "teacher")
                {
                    TeacherForm teacherForm = new TeacherForm((Teacher)newUser);
                    teacherForm.ShowDialog();
                }

             
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
    }
}
