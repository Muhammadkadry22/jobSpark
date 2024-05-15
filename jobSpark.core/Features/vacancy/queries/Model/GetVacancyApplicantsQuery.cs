using jobSpark.core.Bases;
using jobSpark.core.Features.vacancy.queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.vacancy.queries.Model
{
    public class GetVacancyApplicantsQuery : IRequest<Response<List<GetVacancyApplicantsDto>>>
    {
        public int Id { get; set; }
    }
}
