using FluentValidation;
using ShinyCollectorPlatform.Domain.Interfaces;

namespace ShinyCollectorPlatform.Domain.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() {
            RuleFor(x => x.Username)
                 .NotEmpty()
                 .WithMessage("Username is required.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.");
            RuleFor(x => x.Firstname)
                .NotEmpty()
                .WithMessage("Firstname is required.");
            RuleFor(x => x.Lastname)
                .NotEmpty()
                .WithMessage("Lastname is required.");
            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .WithMessage("DateOfBirth is required.");
        }
    }
}
