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
    public partial class TeacherForm : Form
    {
        private Teacher teacher;
        public TeacherForm(Teacher teacher)
        {
            this.teacher = teacher;
            InitializeComponent();
        }

        private void AddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                string name, description;
                GetData(out name, out description);
                Subject subject = new Subject(name, description);
                teacher.SubjectsList.Add(subject);    
                subjectsList.Items.Add(subject.title);
                TextFileClass.WriteTeacherSubject(teacher.UserName, subject.title +":" + subject.description);

            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(argumentException.Message);
            }
            
        }

        private void GetData(out string name, out string description)
        {
            if(string.IsNullOrEmpty(subjectTextBox.Text))
            {
                throw new ArgumentException("Subject field cannot be empty.");
            }
            else
            {
                name = subjectTextBox.Text;
            }

            if(string.IsNullOrEmpty(descriptionTextBox.Text))
            {
                throw new ArgumentException("Description field cannot be empty.");
            }
            else
            {
                description = descriptionTextBox.Text;
            }

            subjectTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        private void TeacherForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            foreach(Subject subject in teacher.SubjectsList)
            {
                subjectsList.Items.Add(subject.title);
            }
        }
    }
}
