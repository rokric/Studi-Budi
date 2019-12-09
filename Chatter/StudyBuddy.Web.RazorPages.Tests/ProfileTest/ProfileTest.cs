using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using StudyBuddy.Web.RazorPages.Logic.Profile;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Tests.ProfileTest
{
    class ProfileTest : TestStartup
    {


        [Test]
        public void GetPasswordByID_ShouldGetEncrypedPassword()
        {
            var service = new Profile(context);

            string res  = service.GetPasswordByID(1);

            Assert.AreEqual("SSaaJXIOmGkPgfxmxOoDZQ==", res);
        }

        [Test]
        public void IsPasswordMaches_ShouldReturnTrueIfPasswordMaches()
        {
            var service = new Profile(context);

            bool res = service.IsPasswordMaches("teacher", 1);

            Assert.IsTrue(res);
        }

        [Test]
        public void IsStringIsGood_ShouldCheckIfNameAndPasswordIdLong()
        {
            var service = new Profile(context);

            bool fail = service.IsStringGood("ne");
            bool pass = service.IsStringGood("gerasda");

            Assert.IsTrue(pass);
            Assert.IsFalse(fail);
        }

        [Test]
        public void IsStringsMaches_ShouldCheckIfStringIsEqual()
        {
            var service = new Profile(context);
            string kintamasis = "slaptazodis";

            bool rezult = service.IsStringsMaches(kintamasis, kintamasis);

            Assert.IsTrue(rezult);
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
