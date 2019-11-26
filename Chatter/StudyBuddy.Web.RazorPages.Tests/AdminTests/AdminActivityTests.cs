using NUnit.Framework;
using StudyBuddy.Web.RazorPages.Logic.Admin;
using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Tests.AdminTests
{
    public class AdminActivityTests : TestStartup
    {
        [Test]
        public void ApproveNewSubjectRequest_throws_that_subject_already_exists_despite_capital_letters_in_Table()
        {
            var service = new AdminActivity(context);

            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(async () => await service.ApproveNewSubjectRequest(1));
            Assert.That(ex.Message, Is.EqualTo("request cannot be approved: subject already exist."));
        }

        [Test]
        public void ApproveNewSubjectRequest_throws_that_subject_already_exists_despite_capital_letters_in_request()
        {
            var service = new AdminActivity(context);

            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(async () => await service.ApproveNewSubjectRequest(2));
            Assert.That(ex.Message, Is.EqualTo("request cannot be approved: subject already exist."));
        }

        [Test]
        public void ApproveNewSubjectRequest_throws_that_subject_title_cannot_be_empty()
        {
            var service = new AdminActivity(context);

            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(async () => await service.ApproveNewSubjectRequest(5));
            Assert.That(ex.Message, Is.EqualTo("request cannot be approved: subject title cannot be empty."));
        }

        [Test]
        public async Task ApproveNewSubjectRequest_adds_new_subject_and_deletes_request()
        {
            var service = new AdminActivity(context);
            await service.ApproveNewSubjectRequest(3);

            Assert.AreEqual(true, context.Subject.Any(s => s.Title == "c#"));
            Assert.AreEqual(false, context.SubjectRequest.Any(s => s.Title == "c#"));
        }

        [Test]
        public void SuspendUser_throws_invalid_date()
        {
            var service = new AdminActivity(context);

            ArgumentException ex = Assert.Throws<ArgumentException>(() => service.SuspendUser(1, new DateTime(2019, 10, 11)));
            Assert.That(ex.Message, Is.EqualTo("User cannot be banned: Date is not valid. It has already gone."));
        }

        [Test]
        public void SuspendUser_suspends_user()
        {
            var service = new AdminActivity(context);

            DateTime dateTime = DateTime.Now;
            service.SuspendUser(1, dateTime);
            Assert.AreEqual(1, context.Suspension.Count());
            Assert.AreEqual(dateTime, context.Suspension.Select(s => s.Until).First());
        }

        override
        public void PopulateContextWithData()
        {
            var subjectRequests = new List<SubjectRequest>
            {
                new SubjectRequest {ID = 1, UserID = 3, Title = "math"},
                new SubjectRequest {ID = 2, UserID = 2, Title = "Java"},
                new SubjectRequest {ID = 3, UserID = 1, Title = "c#"},
                new SubjectRequest {ID = 4, UserID = 1, Title = "discrete math"},
                new SubjectRequest {ID = 5, UserID = 1, Title = ""}
            };
            AddDataToEntity(subjectRequests);

            var subjects = new List<Subject>
            {
                new Subject {Subjectid = 1, Title = "Math"},
                new Subject {Subjectid = 2, Title = "java"},
                new Subject {Subjectid = 3, Title = "computer arcitecture"},
                new Subject {Subjectid = 4, Title = "C++"}
            };

            AddDataToEntity(subjects);

            var users = new List<User>
            {
                new User {Userid = 1, Nick = "dsfdsf", Password = "fdfdsf", Profession = "student"},
                new User {Userid = 2, Nick = "dgfd", Password = "fdsfdf", Profession = "teacher"},
                new User {Userid = 3, Nick = "fdsfdsfd", Password = "fdfsdff", Profession = "student"},
                new User {Userid = 4, Nick = "Cdfdsf", Password = "fdfsddf", Profession = "teacher" }
            };

            AddDataToEntity(users);
        }

        private void AddDataToEntity<T>(List<T> data)
        {
            foreach (T item in data)
            {
                context.Add(item);
            }

            context.SaveChanges();
        }
    }
}
