using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using App;

namespace AppLibrary.Tests
{
    public class DataWriterTests
    {
            
        [Fact]
        public void IsNickAvailable_ShouldChechIfNameIstaken()
        {
           string userName = Encryptor.Encrypt("teacher1");
           string  password = Encryptor.Encrypt("teacher1");

            DataWriter dataWriter = new DataWriter(userName,password, "teacher");

            Assert.False(dataWriter.IsNickAvailable());

        }
        
        [Fact]
        public void IsNickAvailable_ShouldChechIfNameIsFree()
        {
            string userName = Encryptor.Encrypt("Neuzimtas");
            string password = Encryptor.Encrypt("teacher1");

            DataWriter dataWriter = new DataWriter(userName, password, "teacher");

            Assert.True(dataWriter.IsNickAvailable());

        }

        [Fact]
        public void IsLoginAccepted_ShouldChechIfDataMach()
        {
            string userName = Encryptor.Encrypt("teacher1");
            string password = Encryptor.Encrypt("teacher1");

            DataWriter dataWriter = new DataWriter(userName, password, "teacher");

            Assert.True(dataWriter.IsLoginAccepted());
        }

    }
}
