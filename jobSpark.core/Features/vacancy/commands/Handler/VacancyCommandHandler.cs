using AutoMapper;
using jobSpark.core.Bases;
using jobSpark.core.Features.vacancy.commands.Model;
using jobSpark.Domain.Entities;
using jobSpark.Service.Abstracts;
using MediatR;
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

        public VacancyCommandHandler(IMapper mapper, IVacancyService vacancyService)
        {
            this.mapper = mapper;
            this.vacancyService = vacancyService;
        }
        public async Task<Response<string>> Handle(AddVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancyMapper = mapper.Map<Vacancy>(request);
            var result = await vacancyService.AddVacacny(vacancyMapper);
            if (result == "Added")
                return Created("");
            else return BadRequest<string>();
        }
    }
}
