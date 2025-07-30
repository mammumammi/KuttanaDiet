using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Food> Foods{get; set;}
    public DbSet<DailyLog> DailyLogs{get; set;}
    
}