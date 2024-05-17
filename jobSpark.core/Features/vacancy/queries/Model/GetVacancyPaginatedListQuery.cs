using jobSpark.core.Bases;
using jobSpark.core.Features.vacancy.queries.Dtos;
using jobSpark.core.wrappers;
using MediatR;

namespace jobSpark.core.Features.vacancy.queries.Model
{
    public class GetVacancyPaginatedListQuery : IRequest<Response<PaginatedResult<GetVacancyPaginatedListResponse>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
    }
}
