using FluentValidation;
using ShinyCollectorPlatform.Domain.Interfaces;

namespace ShinyCollectorPlatform.Domain.Entities
{
    public class UserRole : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
    public class UserRoleValidation : AbstractValidator<UserRole>
    {
        public UserRoleValidation() {
            RuleFor(x => x.UserId)
            .NotNull()
            .WithMessage("User Id is required");
            RuleFor(x => x.RoleId)
            .NotNull()
            .WithMessage("Role Id is required");
            RuleFor(x => x.User)
            .NotNull()
            .WithMessage("User is required");
            RuleFor(x => x.Role)
            .NotNull()
            .WithMessage("Role is required");
        }
    }
}
