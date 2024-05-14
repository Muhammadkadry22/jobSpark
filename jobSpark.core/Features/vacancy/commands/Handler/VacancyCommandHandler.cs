using AutoMapper;
using jobSpark.core.Bases;
using jobSpark.core.Features.vacancy.commands.Model;
using jobSpark.Domain.Entities;
using jobSpark.Service.Abstracts;
using MediatR;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.vacancy.commands.Handler
{
    public class VacancyCommandHandler : ResponseHandler,
                                         IRequestHandler<AddVacancyCommand, Response<string>>,
                                         IRequestHandler<ApplyToVacancyCommand, Response<string>>
    {
        private readonly IMapper mapper;
        private readonly IVacancyService vacancyService;
        private readonly IApplicationUserService appUserService;
        private readonly ICompanyService companyService;
        private readonly IApplicantUserService applicantUserService;
        private readonly IApplicantVacancyService applicantVacancyService;

        public VacancyCommandHandler(IMapper mapper, 
            IVacancyService vacancyService , 
            IApplicationUserService appUserService ,
            ICompanyService companyService,
            IApplicantUserService applicantUserService,
            IApplicantVacancyService applicantVacancyService
            )
        {
            this.mapper = mapper;
            this.vacancyService = vacancyService;
            this.appUserService = appUserService;
            this.companyService = companyService;
            this.applicantUserService = applicantUserService;
            this.applicantVacancyService = applicantVacancyService;
        }


        public async Task<Response<string>> Handle(AddVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancyMapper = mapper.Map<Vacancy>(request);
            var userId = await appUserService.getUserIdAsync();
            vacancyMapper.CompanyId = await companyService.GetCompanyByUserId(userId);
            var result = await vacancyService.AddVacanyAsync(vacancyMapper);
            if (result == "Added")
                return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(ApplyToVacancyCommand request, CancellationToken cancellationToken)
        {
            var appvacancyMapper = mapper.Map<ApplicantVacancy>(request);
            var userId = await appUserService.getUserIdAsync();
            appvacancyMapper.ApplicantId = await applicantUserService.GetApplicantIdByUserId(userId);
            var result = await applicantVacancyService.AddAppVacancyAsync(appvacancyMapper);
            if(result == "Added")
                return Created("");
            else  return BadRequest<string>();
        }
    }
}
