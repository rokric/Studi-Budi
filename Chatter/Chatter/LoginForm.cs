using System;
using System.Windows.Forms;

namespace Chattter
{
    public partial class LoginForm : Form
    {
        private string userName;
        private string userType;
        public string UserName
        {
            get { return userName; }
        }

        public string UserType
        {
            get { return userType; }
        }

        public LoginForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(LoginForm_FormClosing);
            okButton.Click += new EventHandler(OkButton_Click);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text.Trim();
            userType = (string)userTypeComboBox.SelectedItem;

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Invalid user name");
                return;
            }

            FormClosing -= LoginForm_FormClosing;
            Close();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            userName = "";
        }
    }
}
