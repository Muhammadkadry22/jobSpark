using Azure.Core;
using jobSpark.core.Bases;
using jobSpark.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.achievement.commands.Model
{
    public class AddAchievementCommand:IRequest<Response<string>>   
    {
        public string? Description { get; set; }
        public int? ProjectId { get; set; }
        public int? CertificationId { get; set; }
        public int? WorkingHistoryId { get; set; }
    }
}
