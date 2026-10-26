using Microsoft.EntityFrameworkCore;

namespace ZuesDigitalDesigns.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
}