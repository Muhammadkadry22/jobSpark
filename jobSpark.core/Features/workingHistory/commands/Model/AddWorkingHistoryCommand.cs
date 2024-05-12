using jobSpark.core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.workingHistory.commands.Model
{
    public class AddWorkingHistoryCommand : IRequest<Response<string>>
    {
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string? Position { get; set; }

        public int? ApplicantId { get; set; }
    }
}
