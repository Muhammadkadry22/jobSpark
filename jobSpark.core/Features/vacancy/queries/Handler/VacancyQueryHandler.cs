using AutoMapper;
using jobSpark.core.Bases;
using jobSpark.core.Features.vacancy.queries.Dtos;
using jobSpark.core.Features.vacancy.queries.Model;
using jobSpark.core.wrappers;
using jobSpark.Service.Abstracts;
using MediatR;

namespace jobSpark.core.Features.vacancy.queries.Handler
{
    public class VacancyQueryHandler : ResponseHandler,

<<<<<<< HEAD
                                       IRequestHandler<GetVacancyListQuery, Response<List<GetVacancyListDto>>>, 
                                         IRequestHandler<GetVacancyByIdQuery,Response<GetVacancyByIdDto>>,
                                        IRequestHandler<GetVacancyApplicantsQuery,Response<List<GetVacancyApplicantsDto>>>
=======
                                       IRequestHandler<GetVacancyListQuery, Response<List<GetVacancyListDto>>>,
                                         IRequestHandler<GetVacancyByIdQuery, Response<GetVacancyByIdDto>>,
                                         IRequestHandler<GetVacancyPaginatedListQuery, PaginatedResult<GetVacancyPaginatedListResponse>>
>>>>>>> origin/master
    {
        private readonly IMapper mapper;
        private readonly IVacancyService vacancyService;
        private readonly IApplicantVacancyService applicantVacancyService;

<<<<<<< HEAD
        public VacancyQueryHandler(IMapper mapper , IVacancyService vacancyService, IApplicantVacancyService applicantVacancyService)
=======
        public VacancyQueryHandler(IMapper mapper, IVacancyService vacancyService)
>>>>>>> origin/master
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

<<<<<<< HEAD
        public async Task<Response<List<GetVacancyApplicantsDto>>> Handle(GetVacancyApplicantsQuery request, CancellationToken cancellationToken)
        {
            var vacancyApplicants = await applicantVacancyService.GetVacancyapplicants(request.Id);
            if (vacancyApplicants.Count ==0) return NotFound<List<GetVacancyApplicantsDto>>();
            var vacancyApplicantsMapper = mapper.Map<List<GetVacancyApplicantsDto>>(vacancyApplicants);
            return Success(vacancyApplicantsMapper);
=======
        public async Task<PaginatedResult<GetVacancyPaginatedListResponse>> Handle(GetVacancyPaginatedListQuery request, CancellationToken cancellationToken)
        {
            //Expression<Func<Vacancy, GetVacancyPaginatedListResponse>> expression = e => new GetVacancyPaginatedListResponse(e.Name , e.CategoryId , e.OpenDate , e.State , e.Description , e.Category.Name);
            //var res = await  vacancyService.GetVacanciesQuerable().Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize); 
            var FilterQuery = vacancyService.FilliterVacanciesPaginatedQuerable(request.Search);
            var PaginatedList = await mapper.ProjectTo<GetVacancyPaginatedListResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return PaginatedList;
>>>>>>> origin/master
        }
    }
}
