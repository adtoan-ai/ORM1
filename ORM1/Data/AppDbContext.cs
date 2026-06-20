using Microsoft.EntityFrameworkCore;
using ORM1.Models;

namespace ORM1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                // Ánh xạ tới bảng Book
                entity.ToTable("Book");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(x => x.Title)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(x => x.Author)
                      .HasMaxLength(100);

                entity.Property(x => x.Price)
                      .HasColumnType("float");

                entity.Property(x => x.PublishYear);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}