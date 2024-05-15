using AutoMapper;
using Azure.Core;
using jobSpark.core.Bases;
using jobSpark.core.Features.project.commands.Model;
using jobSpark.Domain.Entities;
using jobSpark.Service.Abstracts;
using jobSpark.Service.implementations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.project.commands.Handler
{
    public class ProjectCommandHandler : ResponseHandler,
                                         IRequestHandler<AddProjectCommand, Response<string>>
    {
        private readonly IMapper mapper;
        private readonly IProjectService projectService;
        private readonly IApplicationUserService applicationUserService;
        private readonly IApplicantUserService applicantUserService;
        public ProjectCommandHandler(IMapper mapper,
                                         IProjectService projectService,
                                             IApplicationUserService applicationUserService,
                                                   IApplicantUserService applicantUserService)
        {
            this.mapper = mapper;
            this.projectService = projectService;
            this.applicationUserService = applicationUserService;
            this.applicantUserService = applicantUserService;
        }

        public async Task<Response<string>> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var projectMapper = mapper.Map<Project>(request);
            var userId = await applicationUserService.getUserIdAsync();
            projectMapper.ApplicantId = await applicantUserService.GetApplicantIdByUserId(userId);
            var result=await projectService.AddProjectAsync(projectMapper);
            if (result == "Added")
                return Created("");
            else return BadRequest<string>();
        }
    }
}