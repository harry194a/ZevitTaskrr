
using Microsoft.EntityFrameworkCore;
using ZevitTask.Infrastructure.Out.Persistence.Entity;

namespace ZevitTask.Application.comm;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ContactEntity>()
            .HasKey(x => x.Id);
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<ContactEntity> ContactEntity { get; set; }
}

