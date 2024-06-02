using FluentValidation;
using ShinyCollectorPlatform.Domain.Interfaces;

namespace ShinyCollectorPlatform.Domain.Entities
{
    public class Setting : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public class SettingValidator : AbstractValidator<Setting>
    {
        public SettingValidator() {
            RuleFor(x => x.UserId)
            .NotNull()
            .WithMessage("User Id is required");
            RuleFor(x => x.User)
            .NotNull()
            .WithMessage("User is required");
        }

    }
}
