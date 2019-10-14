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
            DataWriter check = new DataWriter(userName,password,userType);

            string jsonValue = DataManager.FindUser(userName, password);

            if (!jsonValue.Equals(""))
            {
                if (check.profession == "student")
                {
                    return JsonConvert.DeserializeObject<Student>(jsonValue);
                }
                else if (check.profession == "teacher")
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
                User user = new Student(userName, password);
                DataManager.AddData(userName, password,userType); // TODO-> sends encrypted nick, password and profession boolean is false (not teacher)
            }
            else if (userType.Equals("teacher"))
            {
                User user = new Teacher(userName, password);
                DataManager.AddData(userName, password, userType);//TODO-> sends encrypted nick, password and profession boolean is true (is teacher)
            }
        }

        public static List<string> CreateSubjects()
        {
            return DataManager.ReadSubjects();
        }
    }
}
