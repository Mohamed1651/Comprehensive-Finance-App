using FluentValidation;
using ShinyCollectorPlatform.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinyCollectorPlatform.Domain.Entities
{
    public class UserQuiz : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public string Score { get; set;}
        public DateTime DateEarned { get; set; }
        public User User { get; set; }
        public Quiz Quiz { get; set; }
    }
    public class UserQuizValidator : AbstractValidator<UserQuiz>
    {
        public UserQuizValidator() 
        {
            RuleFor(x => x.UserId)
               .NotEmpty()
               .WithMessage("UserId is required");
            RuleFor(x => x.QuizId)
               .NotEmpty()
               .WithMessage("QuizId is required");
            RuleFor(x => x.Score)
                .NotEmpty()
                .WithMessage("Score is required");
            RuleFor(x => x.DateEarned)
                .NotEmpty()
                .WithMessage("DateEarned is required");
            RuleFor(x => x.User)
                .NotEmpty()
                .WithMessage("User is required");
            RuleFor(x => x.Quiz)
                .NotEmpty()
                .WithMessage("Quiz is required");
        }
    }
}
