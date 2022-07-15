using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FilmsCatalog.Models;

namespace FilmsCatalog.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }

    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>(e =>
            {
                e.ToTable("AspNetFilms");
                e.HasKey(e => e.Id);

                e.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                e.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(450);
                e.Property(e => e.Producer)
                    .IsRequired()
                    .HasMaxLength(100);
                e.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(4);
                e.Property(e => e.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
                e.Property(e => e.UpdatedDate).IsRequired().HasDefaultValue(DateTime.Now);
                e.Property(e => e.IsDeleted)
                .HasDefaultValue(0);

                e.HasIndex(e => e.Producer);
                e.HasIndex(e => e.CreatedDate);
                e.HasIndex(e => e.Year);
            });
        }

        public DbSet<Film> Films { get; set; }
    }
}
