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
    public class GetVacancyListQuery : IRequest<Response<List<GetCompanyListDto>>>
    {
       
    }
}
