using _9jasorosoke.Interface;
using _9jasorosoke.Repositories.DataAccess;
using _9jasorosoke.Repositories.Models;
using _9jasorosoke.Repositories.Repository;
using _9jaSoroSoke.Domain.Factories;
using _9jaSoroSoke.Domain.Models;
using _9jaSoroSoke.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _9jaSoroSoke
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
            services.AddSingleton<DatabaseManager>();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(ConnectionString.MyConnectionString));
            services.AddScoped<ICarOwner, CarOwner>();
            services.AddScoped<IFuelingStationOwner, FuelingStationOwner>();
            services.AddScoped<IGeneralFactories, GeneralFactories>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IGeneralService, GeneralService>();
            services.AddScoped<ICarOwnerViewModel, CarOwnerViewModel>();
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
