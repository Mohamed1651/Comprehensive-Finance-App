using FinApp.Domain.Entities;
using FinApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Aggregates
{
    public class ReportAggregate : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
        public Advice Advice { get; set; }

        public IReadOnlyCollection<IDomainEvent> DomainEvents => throw new NotImplementedException();

        public ReportAggregate(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void ClearDomainEvents()
        {
            throw new NotImplementedException();
        }
    }
}
