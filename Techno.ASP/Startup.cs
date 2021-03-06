using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Techno.DAL;
using Techno.ASP.Services;
using MailKit.Net.Smtp;
using System.Net.Http;
using Techno.ASP.Models;
using Techno.ASP.Models.Forms;
using Techno.ASP.Models.FormsModel;

namespace Techno.ASP
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
            services.AddControllersWithViews();

            services.AddScoped<DataContext>();

            services.AddScoped<HttpClient>();
            services.AddScoped<SmtpClient>();
            services.AddScoped<Mailer>();

            services.AddScoped<IServices<UserModel, UserForm>, UserService>();
            services.AddScoped<IServices<SkillModel, SkillForm>, SkillService>();
            services.AddScoped<IServices<SectionModel, SectionForm>, SectionService>();
            services.AddScoped<IServices<ProfileModel, ProfileForm>, ProfileService>();


            services.AddScoped<ProfileService>();

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=AllProfiles}/{id?}");
            });
        }
    }
}
