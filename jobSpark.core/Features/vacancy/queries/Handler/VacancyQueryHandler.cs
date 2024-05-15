using AutoMapper;
using jobSpark.core.Bases;
using jobSpark.core.Features.vacancy.queries.Dtos;
using jobSpark.core.Features.vacancy.queries.Model;
using jobSpark.Infrastructure.Abstractions;
using jobSpark.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Response<List<GetVacancyApplicantsDto>>> Handle(GetVacancyApplicantsQuery request, CancellationToken cancellationToken)
        {
            var VacancyApplicantList = await applicantVacancyService.GetVacancyapplicants(request.Id);
            var vacancyAppMapper = mapper.Map<List<GetVacancyApplicantsDto>>(VacancyApplicantList);
            var result = Success(vacancyAppMapper);
            return result;
        }
    }
}
