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
        string nick;
        string Pav { get; set; }
        private Teacher teacher;
        private bool dataChanged = false;
        public TeacherForm(Teacher teacher, string userName)
        {
            nick = userName;
            this.teacher = teacher;
            InitializeComponent();
            subjectsBox.Items.AddRange(DataManager.ReadSubjects().ToArray());
        }

        private void AddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                string name, description;
                GetData(out name, out description);
                Pav = name;
                Subject subject = new Subject(name, description);
                teacher.SubjectsList.Add(subject);    
                subjectsList.Items.Add(subject.Title);
                dataChanged = true;
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(argumentException.Message);
            }
            
        }

        private void GetData(out string name, out string description)
        {
            if(subjectsBox.SelectedItem == null)
            {
                throw new ArgumentException("Please select subject!");
            }
            else
            {
                name = (string)subjectsBox.SelectedItem;

                foreach(Subject subject in teacher.SubjectsList)
                {
                    if(subject.Title == name)
                    {
                        throw new ArgumentException("This subject already exists in your profile!");
                    }
                }
            }

            if(string.IsNullOrEmpty(descriptionTextBox.Text))
            {
                throw new ArgumentException("Description field cannot be empty.");
            }
            else
            {
                description = descriptionTextBox.Text;
            }

            subjectsBox.SelectedItem = null;
            descriptionTextBox.Text = "";
        }

        private void TeacherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form form in System.Windows.Forms.Application.OpenForms)
            {
                ///TODO
                //for some reasons the returned form name is MainFrom instead of MainForm
                if (form.Name == "MainFrom")
                {
                    form.Show();
                    break;
                }

            }

            if (dataChanged)
            {
                DataManager.UpdateTeacherInfo(Pav,nick);
                Console.WriteLine("Saving data");
            }
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            
            foreach(string subject in DataManager.GetSubjectsByTeacherName(teacher.UserName))
            {
                subjectsList.Items.Add(subject);
            }
        }

        private void DeleteCourse_Click(object sender, EventArgs e)
        {
            if(subjectsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select subjects to delete");
            }
            else if(subjectsList.SelectedItems.Count > 1)
            {
                MessageBox.Show("You can delete only one subject at once");
            }
            else
            {
                RemoveSubjects();
                dataChanged = true;
            }
        }

        private void RemoveSubjects()
        {
            foreach(ListViewItem subjectName in subjectsList.SelectedItems)
            {
                foreach (Subject subject in teacher.SubjectsList)
                {
                    if (subject.Title == subjectName.Text)
                    {
                        teacher.SubjectsList.Remove(new Subject(subject.Title, subject.Description));
                        subjectsList.Items.Remove(subjectName);
                        break;
                    }
                }
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ChatForm chatForm = new ChatForm(teacher, "");
            chatForm.Show();
        }
    }
}
