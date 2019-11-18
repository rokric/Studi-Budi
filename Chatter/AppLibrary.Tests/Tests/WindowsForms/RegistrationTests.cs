using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.App;
using Xunit;

namespace AppLibrary.Tests
{
    public class RegistrationTests
    {
        private RegistrationValidator registrationValidator = new RegistrationValidator();

        [Fact]
        public void IsPasswordMatch_ShouldChechIfDataIsCurrect()
        {

            string message;

            string password ="Slaptazodis",passwordRepeat =  "Slaptazodis";
            

             registrationValidator.IsPasswordMatch(password, passwordRepeat, out message);

            Assert.Matches("password ok", message);
        }
        [Fact]
        public void IsPasswordValid_ShouldCheckIfPasswordIsGood()
        {

            string message;

            string password = "Slaptazodis";


            registrationValidator.IsPasswordValid(password, out message);

            Assert.Matches("password ok", message);
        }
        [Fact]
        public void IsPasswordValid_ShouldCheckIfPasswordIsNull()
        {

            string message;

            string password = null;


            registrationValidator.IsPasswordValid(password, out message);

            Assert.Matches("cannot be empty", message);
        }

        [Fact]
        public void IsPasswordValid_ShouldCheckIfPasswordIsLong()
        {

            string message;

            string password = "short";


            registrationValidator.IsPasswordValid(password, out message);

            Assert.Matches("6 chars min", message);
        }

        [Fact]
        public void IsUserNameValid_ShouldCheckIfNameIsNotNull()
        {

            string message;

            string Name = null;


            registrationValidator.IsUserNameValid(Name, out message);

            Assert.Matches("cannot be empty", message);
        }

        [Fact]
        public void IsUserNameValid_ShouldCheckIfNameIsLong()
        {

            string message;

            string name = "short";


            registrationValidator.IsUserNameValid(name, out message);

            Assert.Matches("6 chars min", message);
        }

    }
}
