using FinApp.Domain.Aggregates;
using FinApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Infrastructure
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<UserAggregate> Users { get; set; }
        public DbSet<AccountAggregate> Accounts { get; set; }
        public DbSet<Settings> Settings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAggregate>(builder =>
            {

                builder.ToTable("Users");

                builder.HasKey(u => u.Id);

                builder.Property(u => u.Id).ValueGeneratedNever();

                builder.Property(u => u.Uid)
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(u => u.Name)
                       .IsRequired()
                       .HasMaxLength(100);

                // Email Value Object
                builder.OwnsOne(u => u.Email, email =>
                {
                    email.Property(e => e.Value)
                         .HasColumnName("Email")
                         .IsRequired()
                         .HasMaxLength(255);
                });

                // Settings Value Object
                builder.OwnsOne(u => u.Settings, settings =>
                {
                    settings.Property(s => s.Darkmode)
                            .HasColumnName("Darkmode");

                    settings.Property(s => s.NotificationsEnabled)
                            .HasColumnName("NotificationsEnabled");

                    settings.Property(s => s.Language)
                            .HasColumnName("Language")
                            .HasMaxLength(50);
                });

                // Optional: store linked account IDs without joining to AccountAggregate
                builder.Ignore("_accounts"); // If _accounts is used only in memory
                builder.Ignore(u => u.Accounts); // Avoid exposing cross-domain aggregates

            });
        }
    }
}
