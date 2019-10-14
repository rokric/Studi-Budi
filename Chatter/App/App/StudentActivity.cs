using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.App
{
    public class StudentActivity
    {
        public List<Teacher> Teachers { get; }

        public StudentActivity()
        {
            Teachers = new List<Teacher>();
            LoadTeachers();
        }

        private void LoadTeachers()
        {
            foreach(string jsonValue in DataManager.LoadTeachers())
            {
                Teachers.Add(JsonConvert.DeserializeObject<Teacher>(jsonValue));
            }
        }

        public List<Teacher> LoadTeachersBySubject(string subject)
        {
            List<Teacher> teachers = new List<Teacher>();

            foreach(Teacher teacher in Teachers)
            {
                foreach(Subject sub in teacher.SubjectsList)
                {
                    if (sub.title.Equals(subject))
                    {
                        teachers.Add(teacher);
                        break;
                    }
                }
            }

            return teachers;
        }

        public List<string> LoadTeachersNameBySubject(string subject)
        {
            List<Teacher> teachers = LoadTeachersBySubject(subject);
            List<string> teachersName = new List<string>();

            foreach(Teacher teacher in teachers)
            {
                teachersName.Add(teacher.GetDecryptedUserName());
            }

            return teachersName;
        }
    }
}
