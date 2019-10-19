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
          /*  foreach (Teacher teacher in DataManager.LoadTeachers())
                Teachers.Add(teacher);
          */
            foreach (string userNick in DataManager.LoadTeachers())
            {
                Teacher t=new Teacher(ChatServer.Encryptor.Encrypt(userNick)/*, Encryptor.Encrypt(password)*/);
                Teachers.Add(t);
            }
        }
        //+
        public List<string> LoadTeachersBySubject(string subject)
        {
            ChatServer.DataWriter cheker = new ChatServer.DataWriter();
            return cheker.GetTeacherBySubject(subject);

            /*foreach(Teacher teacher in Teachers)
            {
                foreach(Subject sub in teacher.SubjectsList)
                {
                    if (sub.title.Equals(subject))
                    {
                        teachers.Add(teacher);
                        break;
                    }
                }
            }*/
            
        }
        //-
        public List<string> LoadTeachersNameBySubject(string subject)
        {
            List<string> teachers = LoadTeachersBySubject(subject);
            List<string> teachersName = new List<string>();

            /* foreach(Teacher teacher in teachers)
             {
                 teachersName.Add(teacher.GetDecryptedUserName());
             }*/
            foreach (string teacher in teachers)
            {
                teachersName.Add(ChatServer.Encryptor.Decrypt(teacher));
            }

            return teachersName;
        }
        //-
    }
}
