using FluentValidation;
using jobSpark.core.Features.skills.commands.Model;
using jobSpark.core.Resources;
using jobSpark.Domain.Entities;
using jobSpark.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.skills.commands.Validator
{
    public class AddSkillValidator : AbstractValidator<AddSkillCommand>
    {
        private readonly ISkillSevice skillService;
        private readonly IApplicantUserService applicantUserService;
        private readonly IApplicationUserService applicationUserService;

        public AddSkillValidator(ISkillSevice skillService,
                                 IApplicantUserService applicantUserService,
                                 IApplicationUserService applicationUserService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            this.skillService = skillService;
            this.applicantUserService = applicantUserService;
            this.applicationUserService = applicationUserService;
        }

       
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                 .MaximumLength(100).WithMessage(SharedResourcesKeys.MaxLengthis100);
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x=>x.Name)
                .MustAsync(async (name, CancellationToken)=> {
                    string userId = await applicationUserService.getUserIdAsync();
                    int applicantId =await  applicantUserService.GetApplicantIdByUserId(userId);
                    return !await skillService.SkillExistsForApplicant(name, applicantId);
                    })
                .WithMessage(SharedResourcesKeys.IsExist);
        }

    }
}
