using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public static class Builder
    {
        public static User LoadUser(string userType, string userName, string password)
        {
            string jsonValue = DataManager.FindUser(userName, password);

            if (!jsonValue.Equals(""))
            {
                if (userType == "student")
                {
                    return JsonConvert.DeserializeObject<Student>(jsonValue);
                }
                else if (userType == "teacher")
                {
                    return JsonConvert.DeserializeObject<Teacher>(jsonValue);
                }
            }
            return null;
        }

        public static void CreateUser(string userType, string userName, string password)
        {
            if (userType.Equals("student"))
            {
                User user = new Student(Encryptor.Encrypt(userName), Encryptor.Encrypt(password));
                string json = JsonConvert.SerializeObject(user);
                DataManager.AddData(json);
            }
            else if (userType.Equals("teacher"))
            {
                User user = new Teacher(Encryptor.Encrypt(userName), Encryptor.Encrypt(password));
                string json = JsonConvert.SerializeObject(user);
                DataManager.AddData(json);
            }
        }

        public static List<string> CreateSubjects()
        {
            return DataManager.ReadSubjects();
        }
    }
}
