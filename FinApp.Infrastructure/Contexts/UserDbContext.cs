using FinApp.Domain.Aggregates;
using FinApp.Domain.Entities;
using FinApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Infrastructure.Contexts
{
    public class UserDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        public UserDbContext(
           DbContextOptions<UserDbContext> options,
           IDomainEventDispatcher domainEventDispatcher) : base(options)
        {
            _domainEventDispatcher = domainEventDispatcher;
        }
        public DbSet<UserAggregate> Users { get; set; }
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

                builder.HasOne(u => u.Settings)
                       .WithOne()
                       .HasForeignKey<Settings>(s => s.UserId)
                       .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Settings>(builder =>
            {
                builder.ToTable("Settings");

                builder.HasKey(s => s.Id);

                builder.Property(s => s.Id).ValueGeneratedNever();

                builder.Property(s => s.UserId)
                       .IsRequired();

                builder.Property(s => s.Darkmode);

                builder.Property(s => s.NotificationsEnabled);

                builder.Property(s => s.Language)
                        .IsRequired()
                        .HasMaxLength(3);
            });
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Save first
            var result = await base.SaveChangesAsync(cancellationToken);

            // Then dispatch domain events
            var domainEntities = ChangeTracker.Entries<IAggregateRoot>()
                .Where(e => e.Entity.DomainEvents != null && e.Entity.DomainEvents.Any())
                .Select(e => e.Entity)
                .ToList();

            var domainEvents = domainEntities
                .SelectMany(e => e.DomainEvents)
                .ToList();

            foreach (var entity in domainEntities)
            {
                entity.ClearDomainEvents();
            }

            if (_domainEventDispatcher != null)
            {
                await _domainEventDispatcher.DispatchAsync(domainEvents);
            }

            return result;
        }
    }
}
