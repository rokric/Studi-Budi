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
                teacher.SubjectsList.Add(subject);    //TODO: reikia database, nes kitaip vis skirtingam faile reiketu
                subjectsList.Items.Add(subject.title);//saugoti kiekvieno mokytojo duomenis

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
    }
}
