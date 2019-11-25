using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StudyBuddy.Web.RazorPages.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Web.RazorPages.Tests
{
    public class TestStartup
    {
        protected StudiBudiContext context;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<StudiBudiContext>()
                          .UseInMemoryDatabase(GetType().Name)
                          .Options;
            context = new StudiBudiContext(options);

            PopulateContextWithData();
        }

        public virtual void PopulateContextWithData()
        {
            throw new NotImplementedException();
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
