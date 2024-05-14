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
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.project.commands.Handler
{
    public class ProjectCommandHandler : ResponseHandler,
                                         IRequestHandler<AddProjectCommand, Response<string>>
    {
        private readonly IMapper mapper;
        private readonly IProjectService projectService;

        public ProjectCommandHandler(IMapper mapper, IProjectService projectService)
        {
            this.mapper = mapper;
            this.projectService = projectService;
        }

        public async Task<Response<string>> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var projectMapper = mapper.Map<Project>(request);
            var result=await projectService.AddProjectAsync(projectMapper);
            if (result == "Added")
                return Created("");
            else return BadRequest<string>();
        }
    }
}