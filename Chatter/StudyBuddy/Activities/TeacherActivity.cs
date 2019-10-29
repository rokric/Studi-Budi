using StudyBuddy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Activities
{
    public class TeacherActivity
    {
        public Teacher Teacher { get; set; }
        public List<string> AllSubjects { get; set; }
        public List<Subject> MySubjects { get; set; }

        public TeacherActivity(Teacher teacher)
        {
            Teacher = teacher;
            AllSubjects = LoadSubjects();
            MySubjects = new List<Subject>();
        }

        private List<string> LoadSubjects()
        {
            return DataManager.ReadSubjects();
        }

        public void AddCourse(string title, string description)
        {
            ValidateData(title, description);
            MySubjects.Add(new Subject(title, description));
            DataManager.UpdateTeacherInfo(title, Teacher.UserName);
        }

        public void ValidateData(string title, string description)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Please select subject!");
            }
           
            foreach (Subject subject in MySubjects)
            {
                if (subject.Title == title)
                {
                    throw new ArgumentException("This subject already exists in your profile!");
                }
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Description field cannot be empty.");
            }
        }

        public void DeleteCourse(string title)
        {
            foreach(Subject subject in MySubjects)
            {
                if (subject.Title.Equals(title))
                {
                    MySubjects.Remove(subject);
                    break;
                }
            }
        }
    }
}

