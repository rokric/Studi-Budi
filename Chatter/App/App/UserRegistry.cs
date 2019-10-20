using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.App
{
    public class UserRegistry
    {
        public void CreateUser(string userName, string password, string userType)
        {
            if (userType.Equals("student"))
            {
                User user = new Student(userName, password);
                DataManager.AddData(userName, password, userType); // TODO-> sends encrypted nick, password and profession boolean is false (not teacher)
            }
            else if (userType.Equals("teacher"))
            {
                User user = new Teacher(userName, password);
                DataManager.AddData(userName, password, userType);//TODO-> sends encrypted nick, password and profession boolean is true (is teacher)
            }
        }
    }
}
