using FluentValidation;
using ShinyCollectorPlatform.Domain.Interfaces;

namespace ShinyCollectorPlatform.Domain.Entities
{
    public class UserBadge : IEntity
    {
        public int Id { get; set; }
        public int BadgeId { get; set; }
        public DateTime EarnedDate { get; set;}
        public User User { get; set; }
        public Badge Badge { get; set; }
    }
    public class UserBadgeValidator : AbstractValidator<UserBadge>
    {
        public UserBadgeValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("UserId is required");
            RuleFor(x => x.BadgeId)
                .NotEmpty()
                .WithMessage("BadgeId is required");
            RuleFor(x => x.EarnedDate)
                .NotEmpty()
                .WithMessage("EarnedDate is required");
            RuleFor(x => x.User)
                .NotEmpty()
                .WithMessage("User is required");
            RuleFor(x => x.Badge)
                .NotEmpty()
                .WithMessage("Badge is required");
        }
    }
}
