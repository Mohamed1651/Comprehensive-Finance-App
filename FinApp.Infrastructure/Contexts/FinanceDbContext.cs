using FinApp.Domain.Aggregates;
using FinApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Infrastructure.Contexts
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) { }
        public DbSet<AccountAggregate> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CategoryTransaction> CategoryTransactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountAggregate>(builder =>
            {
                builder.ToTable("Accounts");

                builder.HasKey(a => a.Id);

                builder.Property(a => a.Name)
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(a => a.AccountType)
                       .IsRequired()
                       .HasConversion<string>();

                builder.Property(a => a.UserId)
                       .IsRequired();

                // Value Object: Balance
                builder.OwnsOne(a => a.Balance, balance =>
                {
                    balance.Property(b => b.Value)
                           .HasColumnName("Balance")
                           .IsRequired();
                });

                builder.Metadata
                       .FindNavigation(nameof(AccountAggregate.Transactions))
                       .SetPropertyAccessMode(PropertyAccessMode.Field);
            });

            modelBuilder.Entity<Transaction>(builder =>
            {
                builder.ToTable("Transactions");

                builder.HasKey(t => t.Id);

                builder.Property(t => t.Title)
                       .IsRequired()
                       .HasMaxLength(200);

                builder.Property(t => t.Description)
                       .HasMaxLength(500);

                builder.Property(t => t.Type)
                       .IsRequired()
                       .HasConversion<string>();

                builder.Property(t => t.AccountId)
                       .IsRequired();

                // Value Object: Amount
                builder.OwnsOne(t => t.Amount, amount =>
                {
                    amount.Property(a => a.Value)
                          .HasColumnName("Amount")
                          .IsRequired();
                });

                builder.HasMany(t => t.CategoryTransaction)
                       .WithOne(ct => ct.Transaction)
                       .HasForeignKey(ct => ct.TransactionId);
            });

            modelBuilder.Entity<CategoryTransaction>(builder =>
            {
                builder.ToTable("CategoryTransactions");

                builder.HasKey(ct => new { ct.CategoryId, ct.TransactionId });

                builder.Property(ct => ct.TransactionDate)
                       .IsRequired();

                builder.HasOne(ct => ct.Category)
                       .WithMany()
                       .HasForeignKey(ct => ct.CategoryId);
            });

            modelBuilder.Entity<Category>(builder =>
            {
                builder.ToTable("Categories");

                builder.HasKey(c => c.Id);

                builder.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                // Configure value object: ColorHex
                builder.OwnsOne(c => c.ColorHex, color =>
                {
                    color.Property(ch => ch.Value)
                        .HasColumnName("ColorHex")
                        .IsRequired()
                        .HasMaxLength(7); // assuming format "#FFFFFF"
                });

                // One-to-many with CategoryTransaction
                builder.HasMany(c => c.CategoryTransactions)
                    .WithOne(ct => ct.Category)
                    .HasForeignKey(ct => ct.CategoryId);

                // Optional one-to-one (or one-to-many) with Budget
                builder.HasOne(c => c.Budget)
                    .WithOne() // or .WithMany() depending on your domain model
                    .HasForeignKey<Budget>(b => b.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Budget>(builder =>
            {
                builder.ToTable("Budgets");

                builder.HasKey(b => b.Id);

                // Value Object: Amount
                builder.OwnsOne(b => b.Amount, amount =>
                {
                    amount.Property(a => a.Value)
                          .HasColumnName("Amount")
                          .HasColumnType("decimal(18,2)")
                          .IsRequired();
                });

                builder.Property(b => b.CategoryId)
                       .IsRequired();

                builder.Property(b => b.UserId)
                       .IsRequired();

                builder.Property(b => b.StartDate)
                       .IsRequired();

                builder.Property(b => b.EndDate)
                       .IsRequired();

                // Optional: One-to-one (or many-to-one) with Category
                builder.HasOne(b => b.Category)
                       .WithOne(c => c.Budget) // or .WithMany(c => c.Budgets) if Category can have many budgets
                       .HasForeignKey<Budget>(b => b.CategoryId)
                       .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
