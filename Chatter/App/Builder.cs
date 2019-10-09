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
            string jsonValue = TextFileClass.FindUser(userName, password);

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

        public static User CreateNewUser(string userType, string userName, string password)
        {
            if (userType.Equals("student"))
            {
                User user = new Student(userName, password);
                string json = JsonConvert.SerializeObject(user);
                TextFileClass.AddData(json);
                return user;
            }
            else if (userType.Equals("teacher"))
            {
                User user = new Teacher(userName, password);
                string json = JsonConvert.SerializeObject(user);
                TextFileClass.AddData(json);
                return user;
            }
            else
            {
                return null;
            }
        }

        public static List<string> CreateSubjects()
        {
            return TextFileClass.ReadSubjects();
        }
    }
}
