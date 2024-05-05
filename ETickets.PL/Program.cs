using ETickets.DAL.Data;
using ETickets.PL.Extensions;
using ETickets.PL.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ETickets.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Services 
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("ETicketsConnection"))
                        .UseLazyLoadingProxies();
            }
            );

            builder.Services.AddApplicationServices();

            builder.Services.AddAutoMapper(map =>
                    map.AddProfile(new MappingProfiles())
            );

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();





        }
    }
}