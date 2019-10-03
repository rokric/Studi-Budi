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
    public partial class ContentForm : Form
    {
        private IUser user;

        public ContentForm(IUser user)
        {
            InitializeComponent();
            FillSubjectBox();
            this.user = user;
        }

        private void FillSubjectBox()
        {
            string[] subjects = { "Discrete Mathematics", "Algorithm Theory", "Computer Architecture" };

            foreach(string subject in subjects)
            {
                subjectBox.Items.Add(subject);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ChatClient.ChatForm chatForm = new ChatClient.ChatForm(user.EncryptedUserName);
            chatForm.ConnectToServer();
            chatForm.ShowDialog();
        }

        private void ContentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                ///TODO
                //for some reasons the returned form name is MainFrom instead of MainForm
                if (form.Name == "MainFrom")
                {
                    form.Show();
                    break;
                }

            }
        }
    }
}
