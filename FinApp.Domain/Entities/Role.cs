using FluentValidation;
using ShinyCollectorPlatform.Domain.Interfaces;

namespace ShinyCollectorPlatform.Domain.Entities
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator() {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
        }   
    }
}
