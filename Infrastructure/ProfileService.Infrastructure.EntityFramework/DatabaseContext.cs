using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProfileService.Domain.Entities;

namespace ProfileService.Infrastructure.EntityFramework;

/// <summary>
/// Контекст.
/// </summary>
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    /// <summary>
    /// Профили.
    /// </summary>
    public DbSet<ProfileInfo> Profiles { get; set; }

    /// <summary>
    /// Уроки.
    /// </summary>
    //public DbSet<Lesson> Lessons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<ProfileInfo>()
        //    .HasOne<ClientProfileInfo>()
        //    .WithOne(p => p.Profile)
        //    .IsRequired();

        //modelBuilder.Entity<Course>().HasIndex(c=>c.Name);

        //modelBuilder.Entity<Course>().Property(c => c.Name).HasMaxLength(100);
        //modelBuilder.Entity<Lesson>().Property(c => c.Subject).HasMaxLength(100);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
}