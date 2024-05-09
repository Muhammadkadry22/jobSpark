using jobSpark.core.Bases;
using jobSpark.core.Features.Company.Queries.Dtos;
using jobSpark.core.Features.vacancy.queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.Company.Queries.Model
{
    public class GetCompanytListQuery : IRequest<Bases.Response<List<GetCompanyListDto>>>
    {
    }
}
