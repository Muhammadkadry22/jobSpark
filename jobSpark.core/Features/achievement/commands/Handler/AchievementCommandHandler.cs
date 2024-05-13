using AutoMapper;
using jobSpark.core.Bases;
using jobSpark.core.Features.achievement.commands.Model;
using jobSpark.Domain.Entities;
using jobSpark.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.achievement.commands.Handler
{
   
    public class AchievementCommandHandler : ResponseHandler,
                                              IRequestHandler<AddAchievementCommand, Response<string>>
    {
        private readonly IMapper mapper;
        private readonly IAchievementService achievmentService;

        public AchievementCommandHandler(IMapper mapper, IAchievementService achievmentService)
        {
            this.mapper = mapper;
            this.achievmentService = achievmentService;
        }

        public async Task<Response<string>> Handle(AddAchievementCommand request, CancellationToken cancellationToken)
        {
            var achievmentMapper = mapper.Map<Achievement>(request);
            var result=await achievmentService.AddAchievementAsync(achievmentMapper);
            if (result == "Added")
                return Created("");
            else return BadRequest<string>();
        }
    }
}
