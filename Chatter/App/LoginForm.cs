using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class LoginForm : Form
    {
        public string UserName { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            UserName = userNameTextBox.Text;
            if (String.IsNullOrEmpty(UserName))
            {
                UserName = "default";
            }
            Dispose();
        }
    }
}
