using Microsoft.EntityFrameworkCore;
using ZuesDigitalDesigns.Data;

namespace ZuesDigitalDesigns;

/// <summary>
/// The entry point for the ZuesDigitalDesigns application.
/// Configures and starts the web application, including dependency injection,
/// routing, database context, and middleware for HTTP request processing.
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        
        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Grab the connection string from appsettings.json
        string connectionString = builder.Configuration
                                      .GetConnectionString("DefaultConnection") ??
                                  throw new InvalidOperationException("Connection string not found");

        builder.Services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(connectionString));

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}