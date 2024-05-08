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
                                       IRequestHandler<GetVacancyListQuery, Response<List<GetVacancyListDto>>>
    {
        private readonly IMapper mapper;
        private readonly IVacancyService vacancyService;

        public VacancyQueryHandler(IMapper mapper , IVacancyService vacancyService)
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
    }
}
