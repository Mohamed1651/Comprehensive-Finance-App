using FluentValidation;
using ShinyCollectorPlatform.Domain.Interfaces;

namespace ShinyCollectorPlatform.Domain.Entities
{
    public class Lesson : IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Course Course { get; set; } 
    }
    public class LessonValidator : AbstractValidator<Lesson>
    {
        public LessonValidator()
        { 
            RuleFor(x => x.CourseId)
                .NotEmpty()
                .WithMessage("CourseId is required");
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required");
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Content is required");
            RuleFor(x => x.Course)
                .NotEmpty()
                .WithMessage("Course is required");
        }
    }
}
