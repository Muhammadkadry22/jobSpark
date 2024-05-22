using FluentValidation;
using jobSpark.core.Features.project.commands.Model;
using jobSpark.core.Resources;

namespace jobSpark.core.Features.project.commands.Validator
{
    public class AddProjectValidator : AbstractValidator<AddProjectCommand>
    {
        public AddProjectValidator()
        {
            ApplyValidationRules();
        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                   .NotNull().WithMessage(SharedResourcesKeys.Required)
                 .MaximumLength(100).WithMessage(SharedResourcesKeys.MaxLengthis100);
        }

    }
}
