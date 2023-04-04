using EComponents.Core.Domain.Role;
using EComponents.Core.Domain.User;
using EComponents.Database;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EComponentsXabWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services
                 .AddIdentity<ApplicationUser, ApplicationUserRole>(options =>
                 {
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequireUppercase = false;
                 })
                 .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services
                .AddControllersWithViews();

            #region CUSTOM_SERVICES

            #endregion

            var app = builder.Build();

            #region DB_INIT_PREACTIONS

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }

            #endregion


            #region CUSTOM_INITIALIZERS

            #endregion

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapFallbackToController("ErrorNotFound", "Home");

            app.Run();
        }
    }
}