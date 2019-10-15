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
    public abstract class Validator
    {
        public Validator(){ }
    }

    public class LoginValidator : Validator, ILogin
    {

        public bool IsCorrect(string userName, string password, string profession)
        {
            return DataManager.IsLoginAccepted(userName, password, profession);
        }
    }

    
}
