using FluentValidation;
using ShinyCollectorPlatform.Domain.Interfaces;

namespace ShinyCollectorPlatform.Domain.Entities
{
    public class Badge : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
    public class BadgeValidator : AbstractValidator<Badge>
    {
        public BadgeValidator() {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required");
            RuleFor(x => x.Icon)
                .NotEmpty()
                .WithMessage("Icon is required");
        }
    }
}
