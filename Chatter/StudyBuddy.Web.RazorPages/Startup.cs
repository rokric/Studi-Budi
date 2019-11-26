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
using StudyBuddy.Web.RazorPages.Logic.Profile;
using StudyBuddy.Web.RazorPages.Logic.Teacher;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using StudyBuddy.Web.RazorPages.Logic.Admin;

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

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            services.AddTransient<IStudiBudiContext, StudiBudiContext>();
            services.AddTransient<IUserInfoLoader, UserInfoLoader>();
            services.AddTransient<IStudentActivity, StudentActivity>();
            services.AddTransient<IQuestionRegister, QuestionRegister>();
            services.AddTransient<IQuestionLoader, QuestionLoader>();
            services.AddTransient<IQuestionAnswerRegister, QuestionAnswerRegister>();
            services.AddTransient<ILoginChecker, LoginChecker>();
            services.AddTransient<IUserInfoRegister, UserInfoRegister>();
            services.AddTransient<IDBManager, DBManager>();
            services.AddTransient<IStudentPoints, StudentPoints>();
            services.AddTransient<ITeacherPoints, TeacherPoints>();
            services.AddTransient<IPoints, Points>();
            services.AddTransient<IProfile, Profile>();
            services.AddTransient<ITeacherActivity, TeacherActivity>();
            services.AddTransient<ILogout, Logout>();
            services.AddTransient<IAdminActivity, AdminActivity>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
