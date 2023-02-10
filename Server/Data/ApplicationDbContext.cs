using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BlazorWYDDB23.Shared.Models;
using System.Reflection.Emit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BlazorWYDDB23.Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Day> Days { get; set; }
    public DbSet<DayEntry> DayEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DayEntry>()
           .HasOne(d => d.Day)
           .WithMany(e => e.Entries)
           .HasForeignKey(c => c.DayId)
           .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Day>()
            .HasMany(c => c.Entries)
            .WithOne(e => e.Day)
            .OnDelete(DeleteBehavior.Cascade);

    }
}

