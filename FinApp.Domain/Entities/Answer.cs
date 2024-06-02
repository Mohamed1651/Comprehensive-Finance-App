using FluentValidation;
using ShinyCollectorPlatform.Domain.Interfaces;

namespace ShinyCollectorPlatform.Domain.Entities
{
    public class Answer : IEntity
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }
    }
    public class AnswerValidator : AbstractValidator<Answer>
    {
        public AnswerValidator() 
        {
            RuleFor(x => x.QuestionId)
                .NotEmpty()
                .WithMessage("QuestionId is required");
            RuleFor(x => x.Text)
                .NotEmpty()
                .WithMessage("Text is required");
            RuleFor(x => x.IsCorrect)
                .NotEmpty()
                .WithMessage("IsCorrect is required");
            RuleFor(x => x.Question)
                .NotEmpty()
                .WithMessage("Question is required");
        }
    }
}
