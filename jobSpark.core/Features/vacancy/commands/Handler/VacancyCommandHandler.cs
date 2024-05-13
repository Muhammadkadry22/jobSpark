using AutoMapper;
using jobSpark.core.Bases;
using jobSpark.core.Features.vacancy.commands.Model;
using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.UnitOfWork;
using jobSpark.Service.Abstracts;
using jobSpark.Service.implementations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.vacancy.commands.Handler
{
    public class VacancyCommandHandler : ResponseHandler,
                                         IRequestHandler<AddVacancyCommand, Response<String>>
    {
        private readonly IMapper mapper;
        private readonly IVacancyService vacancyService;
        private readonly IApplicationUserService appUserService;
        private readonly ICompanyService companyService;

        public VacancyCommandHandler(IMapper mapper, 
            IVacancyService vacancyService , 
            IApplicationUserService appUserService ,
            ICompanyService companyService
            )
        {
            this.mapper = mapper;
            this.vacancyService = vacancyService;
            this.appUserService = appUserService;
            this.companyService = companyService;
        }

        
        public async Task<Response<string>> Handle(AddVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancyMapper = mapper.Map<Vacancy>(request);
            var userId =  await appUserService.getUserIdAsync();
            vacancyMapper.CompanyId = await companyService.GetCompanyByUserId(userId); 
            var result = await vacancyService.AddVacanyAsync(vacancyMapper);
            if (result == "Added")
                return Created("");
            else return BadRequest<string>();
        }
    }
}
