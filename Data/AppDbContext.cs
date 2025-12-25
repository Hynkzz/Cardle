using Microsoft.EntityFrameworkCore;
using Cardle.Models;

namespace Cardle.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }
    
    public DbSet<Score> Scores { get; set; }
}