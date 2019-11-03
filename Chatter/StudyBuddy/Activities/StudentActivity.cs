using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddyLogic
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
            foreach (string userNick in DataManager.LoadTeachers())
            {
                Teacher teacher = new Teacher(ChatServer.Encryptor.Encrypt(userNick));
                Teachers.Add(teacher);
            }
        }
       
        public List<string> LoadTeachersBySubject(string subject)
        {
            ChatServer.DataWriter cheker = new ChatServer.DataWriter();
            return cheker.GetTeacherBySubject(subject);
        }
        
        public List<string> LoadTeachersNameBySubject(string subject)
        {
            List<string> teachers = LoadTeachersBySubject(subject);
            List<string> teachersName = new List<string>();

            foreach (string teacher in teachers)
            {
                teachersName.Add(ChatServer.Encryptor.Decrypt(teacher));
            }

            return teachersName;
        }
    }
}
