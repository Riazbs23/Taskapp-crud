using Microsoft.EntityFrameworkCore;
using TaskApp.Models;

namespace TaskApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.DueDate)
                      .IsRequired();

                entity.Property(e => e.Status)
                      .IsRequired()
                      .HasDefaultValue("Not Started");
            });
        }
    }
}