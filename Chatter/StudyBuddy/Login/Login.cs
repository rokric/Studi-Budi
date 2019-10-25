using StudyBuddy.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy
{
    public abstract class Validator
    {
        public Validator(){ }
    }

    public class LoginValidator : Validator, ILogin
    {

        public bool IsCorrect(string userName, string password, string profession)
        {
            return LoginManager.IsLoginAccepted(userName, password, profession);
        }
    }

    
}
