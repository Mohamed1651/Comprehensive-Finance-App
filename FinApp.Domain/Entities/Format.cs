using FluentValidation;
using ShinyCollectorPlatform.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinyCollectorPlatform.Domain.Entities
{
    public class Format : IEntity
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Type { get; set; }
        public string Explanation { get; set; }
        public Question Question { get; set; }
    }
    public class FormatValidator : AbstractValidator<Format>
    {
        public FormatValidator() 
        {
            RuleFor(x => x.QuestionId)
                .NotEmpty()
                .WithMessage("QuestionId is required");
            RuleFor(x => x.Type)
                .NotEmpty()
                .WithMessage("Type is required");
            RuleFor(x => x.Explanation)
                .NotEmpty()
                .WithMessage("Explanation is required");
            RuleFor(x => x.Question)
                .NotEmpty()
                .WithMessage("Question is required");
        }
    }
}
