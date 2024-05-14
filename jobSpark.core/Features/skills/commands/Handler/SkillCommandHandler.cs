using AutoMapper;
using jobSpark.core.Bases;
using jobSpark.core.Features.skills.commands.Model;
using jobSpark.Domain.Entities;
using jobSpark.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.skills.commands.Handler
{
    public class SkillCommandHandler : ResponseHandler,
                                      IRequestHandler<AddSkillCommand, Response<string>>
    {
        private readonly IMapper mapper;
        private readonly ISkillSevice skillSevice;
        private readonly IApplicationUserService applicationUserService;
        private readonly IApplicantUserService applicantUserService;

        public SkillCommandHandler(IMapper mapper,
                                   ISkillSevice skillSevice,
                                   IApplicationUserService applicationUserService,
                                   IApplicantUserService applicantUserService)
        {
            this.mapper = mapper;
            this.skillSevice = skillSevice;
            this.applicationUserService = applicationUserService;
            this.applicantUserService = applicantUserService;
        }

       public async Task<Response<string>> Handle(AddSkillCommand request, CancellationToken cancellationToken)
        {
            var skillMapper = mapper.Map<Skill>(request);
            var userId = await applicationUserService.getUserIdAsync();
            skillMapper.ApplicantId = await applicantUserService.GetApplicantIdByUserId(userId);
            var result = await skillSevice.AddSkillAsync(skillMapper);
            if (result == "Added")
                return Created("");
            else return BadRequest<string>();

        }
    }
}
