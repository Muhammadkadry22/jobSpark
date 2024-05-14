using jobSpark.core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.skills.commands.Model
{
    public class AddSkillCommand:IRequest<Response<string>>
    {
        public string? Name { get; set; }
        //public int? ApplicantId { get; set; }
    }
}
