using jobSpark.core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.project.commands.Model
{
    public class AddProjectCommand:IRequest<Response<string>>
    {
        public string? Name { get; set; }
        public string? Link { get; set; }
        public string? Skills { get; set; }
       // public int? ApplicantId { get; set; }
    }
}
