using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.App
{
    /*
     * Classes for UI and backend connection 
     * Registration and login validation
     */

    public interface ILogin
    {
        bool IsCorrect(string userName, string password);
    }

    public interface IRegistration
    {
        void IsUserNameValid(string userName, out string message);
        void IsPasswordValid(string password, out string message);
        void IsPasswordMatch(string password, string passwordRepeat, out string message);
    }

    public abstract class Validator
    {
        public Validator(){ }
    }

    public class LoginValidator : Validator, ILogin
    {

        public bool IsCorrect(string userName, string password)
        {
            return DataManager.IsLoginAccepted(userName, password);
        }
    }

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

            if(string.IsNullOrEmpty(password))
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
            else if (!DataManager.CheckIfUserNameIsAvailable(userName))
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
