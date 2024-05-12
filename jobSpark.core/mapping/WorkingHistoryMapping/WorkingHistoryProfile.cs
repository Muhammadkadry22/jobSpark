using AutoMapper;
using jobSpark.core.Features.workingHistory.commands.Model;
using jobSpark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.mapping.WorkingHistoryMapping
{
    public class WorkingHistoryProfile : Profile
    {
        public WorkingHistoryProfile()
        {
        
            CreateMap<AddWorkingHistoryCommand, WorkingHistory>();
        }
    }
}
