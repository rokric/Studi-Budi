using App.App;
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
    public partial class StudentForm : Form
    {
        private IUser user;
        private StudentActivity studentActivity = new StudentActivity();

        public StudentForm(IUser user)
        {
            this.user = user;
            InitializeComponent();
            subjectBox.Items.AddRange(Builder.CreateSubjects().ToArray());
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ChatForm chatForm = new ChatForm(user);
            chatForm.ShowDialog();
        }

        private void StudentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form form in System.Windows.Forms.Application.OpenForms)
            {
                if (form.Name == "MainFrom")
                {
                    form.Show();
                    break;
                }
            }
        }

        private void SubjectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            teacherBox.Enabled = true;
            teacherBox.Items.Clear();

            teacherBox.Items.AddRange(
                studentActivity.LoadTeachersNameBySubject((string)subjectBox.SelectedItem).ToArray());
                                      
            subjectLabel.Text = (string)subjectBox.SelectedItem;
            teacherLabel.Text = "";
            teacherBox.Text = "Choose teacher";
        }

        private void TeacherBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            teacherLabel.Text = (string)teacherBox.SelectedItem;
        }
    }
}