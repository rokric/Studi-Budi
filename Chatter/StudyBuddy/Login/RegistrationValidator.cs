using StudyBuddy.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy
{
    public class RegistrationValidator : Validator, IRegistration
    {

        public void IsPasswordMatch(string password, string passwordRepeat, out string message)
        {
            if (password.Equals(passwordRepeat))
            {
                message = "password ok";
            }
            else
            {
                message = "passwords do not match";
            }
        }

        public void IsPasswordValid(string password, out string message)
        {
            message = "password ok";

            if (string.IsNullOrEmpty(password))
            {
                message = "cannot be empty";
            }
            else if (password.Length < 6)
            {
                message = "6 chars min";
            }
        }

        public void IsUserNameValid(string userName, out string message)
        {
            message = "username ok";

            if (string.IsNullOrEmpty(userName))
            {
                message = "cannot be empty";
            }
            else if (userName.Length < 6)
            {
                message = "6 chars min";
            }
            else if (!LoginManager.CheckIfUserNameIsAvailable(ChatServer.Encryptor.Encrypt(userName)))
            {
                message = "user name is already taken";
            }
        }

        public bool IsAccepted(string userName, string password, string passwordRepeat)
        {
            string message;
            IsUserNameValid(userName, out message);
            if (!message.Contains("ok"))
            {
                return false;
            }

            IsPasswordValid(password, out message);
            if (!message.Contains("ok"))
            {
                return false;
            }

            IsPasswordMatch(password, passwordRepeat, out message);
            if (!message.Contains("ok"))
            {
                return false;
            }


            return true;
        }
    }
}
