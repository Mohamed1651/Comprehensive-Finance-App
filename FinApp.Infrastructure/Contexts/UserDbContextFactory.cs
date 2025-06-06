using FinApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Infrastructure.Contexts
{
    public class UserDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();
            var connectionString = configuration.GetConnectionString("SqlServerConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new UserDbContext(optionsBuilder.Options, new NoOpDomainEventDispatcher());
        }

        /// <summary>
        /// Dummy dispatcher used only during migrations.
        /// </summary>
        private sealed class NoOpDomainEventDispatcher : IDomainEventDispatcher
        {
            public Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents) => Task.CompletedTask;
        }
    }



}
