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


                             IRequestHandler<GetVacancyPaginatedListQuery, PaginatedResult<GetVacancyPaginatedListResponse>>,


                                       IRequestHandler<GetVacancyListQuery, Response<List<GetVacancyListDto>>>, 
                                         IRequestHandler<GetVacancyByIdQuery,Response<GetVacancyByIdDto>>,
                                        IRequestHandler<GetVacancyApplicantsQuery,Response<List<GetVacancyApplicantsDto>>>

    {
        private readonly IMapper mapper;
        private readonly IVacancyService vacancyService;
        private readonly IApplicantVacancyService applicantVacancyService;


        public VacancyQueryHandler(IMapper mapper , IVacancyService vacancyService,IApplicantVacancyService applicantVacancyService)

        {
            this.mapper = mapper;
            this.vacancyService = vacancyService;
            this.applicantVacancyService = applicantVacancyService;
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



        public async Task<Response<List<GetVacancyApplicantsDto>>> Handle(GetVacancyApplicantsQuery request, CancellationToken cancellationToken)
        {
            var VacancyApplicantList = await applicantVacancyService.GetVacancyapplicants(request.Id);
            var vacancyAppMapper = mapper.Map<List<GetVacancyApplicantsDto>>(VacancyApplicantList);
            var result = Success(vacancyAppMapper);
            return result;
        }
    }
}
