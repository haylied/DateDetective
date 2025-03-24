using DDetective.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DDetective.Areas.Identity.Data;
using DDetective.Services;

namespace DDetective
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Define the CORS policy name.
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder(args);

            // Configure CORS to allow any origin, header, and method.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            // ENTITY FRAMEWORK:  (will need to remove)
            //builder.Services.AddDbContext<EventDbContext>(options =>
            //    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DDetectiveIdentityDbContext>();



            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddControllersWithViews();


            // Register Classes via DI for Modular use?
            builder.Services.AddScoped<Repo>();
            builder.Services.AddScoped<Domain>();


            var app = builder.Build();

            //--------------------------------//

            //MINIMAL API ENDPOINTS - I think

            app.MapEndpoints();

            //--------------------------------//

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Enable CORS middleware.
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
