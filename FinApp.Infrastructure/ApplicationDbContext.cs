using FinApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Advice> Advices { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Forecast> Forecasts { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Budgets)
                .WithOne()
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Accounts)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Settings)
                .WithOne()
                .HasForeignKey<Settings>(s => s.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Reports)
                .WithOne()
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Transactions)
                .WithOne()
                .HasForeignKey(t => t.AccountId);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.Budget)
                .WithOne(b => b.Category)
                .HasForeignKey<Budget>(b => b.CategoryId);

            modelBuilder.Entity<CategoryTransaction>()
                .HasKey(ct => new { ct.CategoryId, ct.TransactionId });

            modelBuilder.Entity<CategoryTransaction>()
                .HasOne(ct => ct.Category)
                .WithMany(c => c.CategoryTransactions)
                .HasForeignKey(ct => ct.CategoryId);

            modelBuilder.Entity<CategoryTransaction>()
                .HasOne(ct => ct.Transaction)
                .WithMany(t => t.CategoryTransaction)
                .HasForeignKey(ct => ct.TransactionId);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Advice)
                .WithOne()
                .HasForeignKey<Advice>(a => a.ReportId);
        }
    }
}
