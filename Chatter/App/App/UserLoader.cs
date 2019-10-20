using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.App
{
    /*
   * Classes for UI and backend connection 
   * Loads or creates users
   */

    public class UserLoader
    {
        //If user is not registerd in database, builder returns null
        public void LoadUser(string userName, string password, string userType)
        {
            User user = DataManager.ReturnUser(userName, password, userType);

            if (userType.Equals("student"))
            {
                StudentForm studentForm = new StudentForm((Student)user);
                studentForm.Show();
                CloseMainForm();
            }
            else if (userType.Equals("teacher"))
            {
                TeacherForm teacherForm = new TeacherForm((Teacher)user);
                teacherForm.Show();
                CloseMainForm();
            }
        }

        private void CloseMainForm()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "MainFrom")
                {
                    form.Hide();
                    break;
                }
            }
        }
    }
}
