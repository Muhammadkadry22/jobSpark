using jobSpark.core.Bases;
using jobSpark.core.Features.category.queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.category.queries.Model
{
    public class GetCategoryListQuery :IRequest<Response<List<GetCategoryListDto>>>
    {
    }
}
