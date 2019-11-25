using NUnit.Framework;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Tests
{
    public class UserInfoLoaderTests : TestStartup
    {
        [Test]
        public async Task GetEncryptedUsernameByID_gets_encrypted_username_by_id()
        {
        
            var service = new UserInfoLoader(context);
            string result = await service.GetEncryptedUserNameById(1);

            Assert.AreEqual("SSaaJXIOmGkPgfxmxOoDZQ==", result);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetEncryptedUsernameByID_returns_null_for_non_existing_id()
        {
            var service = new UserInfoLoader(context);
            string result = await service.GetEncryptedUserNameById(3);

            Assert.IsNull(result);
        }

        [Test]
        public async Task GetDecryptedUsernameByID_returns_decrypted_username()
        {
            var service = new UserInfoLoader(context);
            string result = await service.GetUserNameById(1);

            Assert.AreEqual("teacher", result);
        }

        [Test]
        public async Task GetDecryptedUsernameByID_returns_null_for_non_existing_id()
        {
            var service = new UserInfoLoader(context);
            string result = await service.GetUserNameById(3);

            Assert.IsNull(result);
        }

        override
        public void PopulateContextWithData()
        {

            var users = new List<User>
            {
                new User {Userid = 1, Nick = "SSaaJXIOmGkPgfxmxOoDZQ==", Password = "SSaaJXIOmGkPgfxmxOoDZQ==", Profession = "teacher"},
                new User {Userid = 2, Nick = "pVakbxJNDoqmAKF23JB1eg==", Password = "pVakbxJNDoqmAKF23JB1eg==", Profession = "student"}
            };

            foreach (User item in users)
            {
                context.Add(item);
            }

            context.SaveChanges();
        }
    }
}
