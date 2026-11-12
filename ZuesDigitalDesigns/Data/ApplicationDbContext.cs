using Microsoft.EntityFrameworkCore;
using ZuesDigitalDesigns.Models;

namespace ZuesDigitalDesigns.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ContactInquiry> ContactInquiries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial projects to ensure the portfolio 
            // is never empty upon deployment.
            modelBuilder.Entity<Project>().HasData(
                new Project 
                { 
                    Id = 1, 
                    Title = "QRForge", 
                    Description = "QRForge is a custom, cross-platform QR " +
                                  "Code Generator built with C# and .NET " +
                                  "10. Featuring a sleek industrial UI " +
                                  "theme, this tool is designed for " +
                                  "developers and users who need to " +
                                  "generate and log QR codes efficiently.",
                    ImagePath = "/images/qrforge-logo.png",
                    Problem = "Users needed a fast, reliable, offline " +
                              "desktop tool to generate QR codes without " +
                              "paying for subscription web services.",
                    Solution = "Built a standalone, cross-platform " +
                               "desktop application using Avalonia UI " +
                               "for instant, local QR generation.",
                    TechStack = "C#, .NET 10, Avalonia UI"
                },
                new Project 
                { 
                    Id = 2, 
                    Title = "Nexus Sports Center", 
                    Description = "Nexus Sports Center is a comprehensive " + 
                                  "sports management web app. It " + 
                                  "streamlines operations by allowing " + 
                                  "users to create teams, manage player " + 
                                  "rosters, and assign home venues. " + 
                                  "With intuitive tools to schedule " + 
                                  "matches, log game results, and " + 
                                  "seamlessly filter historical scores, " + 
                                  "it serves as the ultimate hub for " + 
                                  "organizing competitive play.",
                    ImagePath = "/images/Nexus-logo.png",
                    Problem = "Local sports leagues lacked a unified " +
                              "system to manage rosters, schedule games, " +
                              "and track historical scores.",
                    Solution = "Developed a comprehensive relational " +
                               "database and UI to streamline all " +
                               "league logistics in one hub.",
                    TechStack = "C#, ASP.NET Core MVC, EF Core, SQL Server"
                },
                new Project 
                { 
                    Id = 3, 
                    Title = "Dance Studio Management", 
                    Description = "A full-stack .NET 10 MVC portal " + 
                                  "designed to eliminate the logistical " + 
                                  "chaos of running a modern dance " + 
                                  "studio. Features include class " + 
                                  "registration, secure tuition billing, " + 
                                  "competition tracking, and role-based " + 
                                  "dashboards for directors, " + 
                                  "instructors, and parents.",
                    ImagePath = "/images/dance-logo.png",
                    Problem = "Studio directors were drowning in paper " +
                              "registration forms and disorganized " +
                              "tuition billing processes.",
                    Solution = "Created a secure, role-based portal to " +
                               "automate class sign-ups, billing, and " +
                               "competition tracking.",
                    TechStack = "C#, .NET 10, HTML/CSS, Bootstrap 5"
                }
            );
        }
    }
}