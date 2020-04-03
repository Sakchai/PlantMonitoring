using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using Plant.Data;
using Autofac;
using Plant.Web;
using Plant.Model;
using Plant.Services;

namespace Plant
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }
        public IContainer ApplicationContainer { get; private set; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Add any Autofac modules or registrations.
            // This is called AFTER ConfigureServices so things you
            // register here OVERRIDE things registered in ConfigureServices.
            //
            // You must have the call to AddAutofac in the Program.Main
            // method or this won't be called.
            builder.RegisterModule(new AutofacModule());

            //using (var container = builder.Build())
            //{
            //    var studentService = container.Resolve<IStudentService>();
            //    var cityService = container.Resolve<ICityService>();
            //    var countryService = container.Resolve<ICountryService>();
            //    var students = studentService.GetStudentsList();
            //    foreach (var item in students)
            //    {
            //        System.Console.WriteLine($"{item.Id} {item.FirstName}");
            //    }
            //    var student = studentService.GetStudentByID(1);
            //    System.Console.WriteLine($"{student.Id} {student.FirstName}");

            //    var cities = cityService.GetCitysList();
            //    foreach (var item in cities)
            //    {
            //        System.Console.WriteLine($"{item.Id} {item.Name}");
            //    }
            //    var counties = countryService.GetCountrysList();
            //    foreach (var item in counties)
            //    {
            //        System.Console.WriteLine($"{item.Id} {item.Name}");
            //    }
            //}
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews()
                .AddJsonOptions(options => {
                    // set this option to TRUE to indent the JSON output
                    options.JsonSerializerOptions.WriteIndented = true;
                    // set this option to NULL to use PascalCase instead of CamelCase (default)
                    // options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddAutoMapper(typeof(IMapper), typeof(AutoMapping));
            // Add EntityFramework support for SqlServer.
            //services.AddEntityFrameworkSqlServer();

            //// Add ApplicationDbContext.
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")
            //        )
            //);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

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
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";
               // spa.UseProxyToSpaDevelopmentServer("http://localhost:11119");
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
