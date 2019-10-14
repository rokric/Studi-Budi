using Newtonsoft.Json;
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
        private string userName;
        private string password;
        //constructor arguments are encrypted password and username
        [JsonConstructor]
        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public string UserName {
            get { return userName; }
            set { userName = value; }
        }

        public string Password 
        {
            get { return password; }
            set { password = value; }
        }

        public abstract string Type { get;}
      
        public string GetDecryptedUserName()
        {
            return Encryptor.Decrypt(UserName);
        }
    }

    public class Student : User
    {
        public Student(string userName, string password):base(userName, password)
        {
            
        }

        public override string Type 
        {
            get { return "student"; }
        }
    }

    public class Teacher : User
    {
        private List<Subject> subjectsList = new List<Subject>();

        public Teacher(string userName, string password) : base(userName, password)
        {
 
        }

        public List<Subject> SubjectsList
        {
            get { return subjectsList;}
        }

        public override string Type
        {
            get { return "teacher"; }
        }
    }  
}
