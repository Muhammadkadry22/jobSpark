using FluentValidation;
using jobSpark.core.Features.vacancy.commands.Model;
using jobSpark.core.Resources;
using jobSpark.Service.Abstracts;

namespace jobSpark.core.Features.vacancy.validator
{
    public class AddVacancyValidator : AbstractValidator<AddVacancyCommand>
    {

        ICategoryService categoryService;

        public AddVacancyValidator(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }


        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                    .NotNull().WithMessage(SharedResourcesKeys.Required);

            RuleFor(x => x.OpenDate)
                  .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                  .NotNull().WithMessage(SharedResourcesKeys.Required);

            RuleFor(x => x.Description)
                 .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                 .NotNull().WithMessage(SharedResourcesKeys.Required);
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.CategoryId)
                .MustAsync(async (Key, CancellationToken) => !await categoryService.IsCategoryIdExist(Key))
                .WithMessage(SharedResourcesKeys.IsExist);
        }


    }
}
