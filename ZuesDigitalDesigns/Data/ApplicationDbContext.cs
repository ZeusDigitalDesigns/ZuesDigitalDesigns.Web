using Microsoft.EntityFrameworkCore;
using ZuesDigitalDesigns.Models;

namespace ZuesDigitalDesigns.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    // Maps the Project model to a SQL table named Projects
    public DbSet<Project> Projects { get; set; }
}