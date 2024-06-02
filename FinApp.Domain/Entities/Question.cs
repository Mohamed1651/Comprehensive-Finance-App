using FluentValidation;
using ShinyCollectorPlatform.Domain.Interfaces;

namespace ShinyCollectorPlatform.Domain.Entities
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string Text { get; set; }
        public Quiz Quiz { get; set; }
    }
    public class QuestionValidator : AbstractValidator<Question>
    {
        public QuestionValidator() {
            RuleFor(x => x.QuizId)
                .NotEmpty()
                .WithMessage("QuizId is required");
            RuleFor(x => x.Text)
                .NotEmpty()
                .WithMessage("Text is required");
            RuleFor(x => x.Quiz)
                .NotEmpty()
                .WithMessage("Quiz is required");
        }
    }
}
