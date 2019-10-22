using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using App.App;
using ChatServer;

namespace AppLibrary.Tests
{
    public class LogInTests
    {

        [Fact]
        public void IsCorrect_ShouldCheckIfDataIsCorrect()
        {

            bool actual = new LoginValidator().IsCorrect(Encryptor.Encrypt("teacher1"), Encryptor.Encrypt("teacher1"), "teacher");

            Assert.True(actual);
        }
    }
}
