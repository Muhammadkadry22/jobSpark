using AutoMapper;
using jobSpark.core.Bases;
using jobSpark.core.Features.vacancy.queries.Dtos;
using jobSpark.core.Features.vacancy.queries.Model;
using jobSpark.core.wrappers;
using jobSpark.Domain.Entities;
using jobSpark.Service.Abstracts;
using MediatR;
using System.Linq.Expressions;

namespace jobSpark.core.Features.vacancy.queries.Handler
{
    public class VacancyQueryHandler : ResponseHandler,

                             IRequestHandler<GetVacancyListQuery, Response<List<GetVacancyListDto>>>,
                             IRequestHandler<GetVacancyByIdQuery, Response<GetVacancyByIdDto>>,
                             IRequestHandler<GetVacancyPaginatedListQuery, PaginatedResult<GetVacancyPaginatedListResponse>>

    {
        private readonly IMapper mapper;
        private readonly IVacancyService vacancyService;

        public VacancyQueryHandler(IMapper mapper, IVacancyService vacancyService)
        {
            this.mapper = mapper;
            this.vacancyService = vacancyService;
        }
        public async Task<Response<List<GetVacancyListDto>>> Handle(GetVacancyListQuery request, CancellationToken cancellationToken)
        {
            var VacancyList = await vacancyService.GetVacancyListAsync();
            var vacancyMapper = mapper.Map<List<GetVacancyListDto>>(VacancyList);
            var result = Success(vacancyMapper);
            return result;
        }

        public async Task<Response<GetVacancyByIdDto>> Handle(GetVacancyByIdQuery request, CancellationToken cancellationToken)
        {
            var vacancy = await vacancyService.GetVacancyByIdAsync(request.Id);
            if (vacancy == null) return NotFound<GetVacancyByIdDto>();
            var vacancyMapper = mapper.Map<GetVacancyByIdDto>(vacancy);
            var result = Success(vacancyMapper);
            return result;
        }

        public async Task<PaginatedResult<GetVacancyPaginatedListResponse>> Handle(GetVacancyPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Vacancy, GetVacancyPaginatedListResponse>> expression = e => new GetVacancyPaginatedListResponse(e.Id, e.Name, e.OpenDate, e.State, e.Description, e.ApplicantCount, e.ReviewCount, e.CategoryId, e.Category.Name, e.CompanyId, e.Company.Name);
            // var querable = vacancyService.GetVacanciesQuerable();
            var FilterQuery = vacancyService.FilliterVacanciesPaginatedQuerable(request.Search);
            var paginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }


    }
}
