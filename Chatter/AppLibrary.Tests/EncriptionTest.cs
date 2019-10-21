using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using App;

namespace AppLibrary.Tests
{

    public class EncriptionTest
    {

        [Theory]
        [ InlineData ("bandymas")]
        [InlineData("KitasBandymas652")]
        public void Encrypt_ShouldChechIfEncriptionAndDecriptionWork(string bandymas)
        {
            string bandymasEncypted = Encryptor.Encrypt(bandymas);

            Assert.Equal(Encryptor.Encrypt(bandymas), bandymasEncypted);
            Assert.Equal(Encryptor.Decrypt(bandymasEncypted), bandymas);
            Assert.Equal(Encryptor.Decrypt(bandymasEncypted), Encryptor.Decrypt(bandymasEncypted));

        }


    }
}
