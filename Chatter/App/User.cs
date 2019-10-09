using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public interface IUser
    {
        string UserName { get; set; }
        string Password { get; set; }

        string GetDecryptedUserName();
    }

    public abstract class User : IUser
    {
        private Encryptor encryptor;
        private string username;
        private string password; 

        public User(string userName, string password)
        {
            encryptor = new Encryptor();
            UserName = userName;
            Password = password;
        }

        public string UserName
        {
            get { return encryptor.Encrypt(username); }
            set { username = value; }
        }

        public string Password
        {
            get { return encryptor.Encrypt(password); }
            set { password = value; }
        }

        public string GetDecryptedUserName()
        {
            return username;
        }

        public abstract new string GetType();
    }

    public class Student : User
    {
        public Student(string userName, string password):base(userName, password)
        {
            
        }

        public override string ToString()
        {
            return UserName + "," + Password + "," + "student";
        }

        public override string GetType()
        {
            return "student";
        }
    }

    public class Teacher : User
    {
        private List<Subject> subjectsList;

        public Teacher(string userName, string password) : base(userName, password)
        {
            subjectsList = TextFileClass.ReadTeacherSubjects(UserName);
        }

        public override string ToString()
        {
            return UserName + "," + Password + "," + "teacher";
        }

        public override string GetType()
        {
            return "teacher";
        }

        public List<Subject> SubjectsList
        {
            get { return subjectsList;}
        }
    }  
}
