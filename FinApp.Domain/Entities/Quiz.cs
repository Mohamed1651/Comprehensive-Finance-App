using FluentValidation;
using ShinyCollectorPlatform.Domain.Interfaces;

namespace ShinyCollectorPlatform.Domain.Entities
{
    public class Quiz : IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Course Course { get; set; }
    }
    public class QuizValidator : AbstractValidator<Quiz>
    {
        public QuizValidator() 
        {
            RuleFor(x => x.CourseId)
                .NotEmpty()
                .WithMessage("CourseId is required");
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required");
            RuleFor(x => x.Course)
                .NotEmpty()
                .WithMessage("Course is required");
        }
    }
}
