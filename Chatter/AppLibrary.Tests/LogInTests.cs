using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using App.App;

namespace AppLibrary.Tests
{
    public class LogInTests
    {

        [Fact]
        public void IsCorrect_ShouldChechIfDataIsCurrect()
        {

            bool actual = new LoginValidator().IsCorrect("teacher1", "teacher1", "teacher");

            Assert.True(actual);
        }
    }
}
