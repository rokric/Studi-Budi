using NUnit.Framework;
using StudyBuddy.Web.RazorPages.Logic.Teacher;
using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Tests
{
    public class TeacherActivityTests: TestStartup
    {
        [Test]
        public async Task GetAvailableSubjects_gets_available_subjects_by_teacher_id_is_not_null()
        {
            var service = new TeacherActivity(context);
            List<Subject> result = await service.GetAvailableSubjects(1);
            Assert.IsNotNull(result);
        }
        [Test]
        public async Task GetAvailableSubjects_gets_available_subjects_by_teacher_id_is_equal()
        {
            var service = new TeacherActivity(context);
            List<Subject> result = await service.GetAvailableSubjects(1);
              Assert.AreEqual("Algorithm Theory", result[0].Title);
        } 
        [Test]
        public async Task GetMySubjects_gets_teaching_subject_title()
        {
            var service = new TeacherActivity(context);
            List<string> result = await service.GetMySubjects(1);
              Assert.AreEqual("Discrete Math", result[0]);
        }
        [Test]
        public async Task GetMySubjects_gets_teaching_subject_title_not_null()
        {
            var service = new TeacherActivity(context);
            List<string> result = await service.GetMySubjects(1);
              Assert.IsNotNull(result[0]);
        } 
        override
        public void PopulateContextWithData()
        {
            var subjects = new List<Subject>
            {
                new Subject {Subjectid=1, Title="Discrete Math"},
                new Subject {Subjectid=2, Title="Mathematics"},
                new Subject {Subjectid=3, Title="Algorithm Theory"}
            };

            foreach (Subject item in subjects)
            {
                context.Add(item);
            }

            var users = new List<User>
            {
                new User {Userid = 1, Nick = "SSaaJXIOmGkPgfxmxOoDZQ==", Password = "SSaaJXIOmGkPgfxmxOoDZQ==", Profession = "teacher"},
                new User {Userid = 2, Nick = "pVakbxJNDoqmAKF23JB1eg==", Password = "pVakbxJNDoqmAKF23JB1eg==", Profession = "student"}
            };

            foreach (User item in users)
            {
                context.Add(item);
            }

            var teaching = new List<Teaching>
            {
                new Teaching {Userid = 1, Subjectid=1},
                new Teaching {Userid = 1, Subjectid=2},
            };

            foreach (Teaching item in teaching)
            {
                context.Add(item);
            }

            context.SaveChanges();
        }
    }
}
