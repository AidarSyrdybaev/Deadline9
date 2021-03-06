using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Deadline9.BL.AutoMapper;
using DeadLine9.DAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Deadline9.BL.Services;
using Deadline9.BL.AutoMapper.Mappings;
using DeadLine9.DAL.Entities;
using Deadline9.Models;

namespace Deadline9.UI
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
            //services.AddControllersWithViews(opts =>
            //{
            //    opts.ModelBinderProviders.Insert(0, new PointModelBinderProvider());
            //});
            string connectionString = Configuration.GetConnectionString("MainConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseNpgsql(connectionString);

            services.AddSingleton<IApplicationDbContextFactory>(
                sp => new ApplicationDbContextFactory(
                    optionsBuilder.Options
                ));

            services.AddDbContext<ApplicationDbContext>(options =>
        {
                options.UseNpgsql(connectionString);
                
            });

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();

            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddScoped<ISpecialtyService, SpecialtyService>();

            services.AddScoped<ITeacherService, TeacherService>();

            services.AddScoped<IGroupService, GroupService>();

            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<ILessionService, LessionService >();

            services.AddScoped<ILectureService, LectureService>();

            services.AddScoped<IPointService, PointService>();

            services.AddRazorPages();
            Mapper.Initialize(m => m.AddProfile(new MappingProfile()));

            
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
