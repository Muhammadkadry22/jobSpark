using AutoMapper;
using jobSpark.core.Bases;
using jobSpark.core.Features.workingHistory.commands.Model;
using jobSpark.Domain.Entities;
using jobSpark.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.workingHistory.commands.Handler
{
    public class WorkingHistoryCommandHandler : ResponseHandler,
                                               IRequestHandler<AddWorkingHistoryCommand, Response<string>>
    {
        private readonly IMapper mapper;
        private readonly IWorkingHistoryService workingHistoryService;

        public WorkingHistoryCommandHandler(IMapper mapper, IWorkingHistoryService workingHistoryService)
        {
            this.mapper = mapper;
            this.workingHistoryService = workingHistoryService;
        }

        public async Task<Response<string>> Handle(AddWorkingHistoryCommand request, CancellationToken cancellationToken)
        {
            var workinghestorymapper = mapper.Map<WorkingHistory>(request);
            var result=await workingHistoryService.AddWorkingHistoryAsync(workinghestorymapper);
            if (result == "added")
                return Created("");
            else return BadRequest<string>();
        }
    }
}
