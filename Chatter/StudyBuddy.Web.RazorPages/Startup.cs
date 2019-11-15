using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Ratings;

namespace StudyBuddy.Web.RazorPages
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddDbContext<StudiBudiContext>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString("StudiBudiContext")));


            services.AddTransient<IStudiBudiContext, StudiBudiContext>();
            services.AddTransient<IUserInfoLoader, UserInfoLoader>();
            services.AddTransient<IStudentActivity, StudentActivity>();
            services.AddTransient<IQuestionRegister, QuestionRegister>();
            services.AddTransient<IQuestionLoader, QuestionLoader>();
            services.AddTransient<IQuestionAnswerRegister, QuestionAnswerRegister>();
            services.AddTransient<ILoginChecker, LoginChecker>();
<<<<<<< HEAD
            services.AddTransient<IStudentPoints, StudentPoints>();
            services.AddTransient<ITeacherPoints, TeacherPoints>();
            services.AddTransient<IDBManager, DBManager>();
            services.AddTransient<IPoints, Points>();
            services.AddTransient<IUserInfoRegister, UserInfoRegister>();
=======
>>>>>>> master
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
