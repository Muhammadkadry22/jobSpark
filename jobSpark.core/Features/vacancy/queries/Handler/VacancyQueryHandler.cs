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
                                         IRequestHandler<GetVacancyByIdQuery,Response<GetVacancyByIdDto>>,
                                        IRequestHandler<GetVacancyApplicantsQuery,Response<List<GetVacancyApplicantsDto>>>
    {
        private readonly IMapper mapper;
        private readonly IVacancyService vacancyService;
        private readonly IApplicantVacancyService applicantVacancyService;

        public VacancyQueryHandler(IMapper mapper , IVacancyService vacancyService, IApplicantVacancyService applicantVacancyService)
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

        public async Task<Response<List<GetVacancyApplicantsDto>>> Handle(GetVacancyApplicantsQuery request, CancellationToken cancellationToken)
        {
            var vacancyApplicants = await applicantVacancyService.GetVacancyapplicants(request.Id);
            if (vacancyApplicants.Count ==0) return NotFound<List<GetVacancyApplicantsDto>>();
            var vacancyApplicantsMapper = mapper.Map<List<GetVacancyApplicantsDto>>(vacancyApplicants);
            return Success(vacancyApplicantsMapper);
        }
    }
}
