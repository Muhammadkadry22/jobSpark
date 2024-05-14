using jobSpark.core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.vacancy.commands.Model
{
    public class ApplyToVacancyCommand : IRequest<Response<string>>
    {
        public int VacancyId { get; set; }
    }
}
