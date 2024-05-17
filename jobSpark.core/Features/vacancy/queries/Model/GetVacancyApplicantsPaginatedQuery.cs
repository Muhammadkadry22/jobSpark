using jobSpark.core.Features.vacancy.queries.Dtos;
using jobSpark.core.wrappers;
using MediatR;

namespace jobSpark.core.Features.vacancy.queries.Model
{
    public class GetVacancyApplicantsPaginatedQuery : IRequest<PaginatedResult<GetVacancyApplicantsPaginatedResponse>>
    {
        public int VacancyId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
