using Microsoft.EntityFrameworkCore;
using TaskFlow.API.Models;


namespace TaskFlow.API.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
}

