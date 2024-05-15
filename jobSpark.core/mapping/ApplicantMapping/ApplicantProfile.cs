using AutoMapper;
using jobSpark.core.Features.Applicant.Queries.Dtos;
using jobSpark.core.Features.ApplicantVacancy.queries.Dtos;
using jobSpark.core.Features.certification.queries.Dtos;
using jobSpark.core.Features.project.queries.Dtos;
using jobSpark.core.Features.skills.queries.Dtos;
using jobSpark.core.Features.workingHistory.queries.Dtos;
using jobSpark.Domain.Entities;

namespace jobSpark.core.mapping.ApplicantMapping
{
    public class ApplicantProfile : Profile
    {
        public ApplicantProfile()
        {

            CreateMap<Applicant, GetApplicantByIdDto>();
    

            CreateMap<Project, ProjectDto>();
       

            CreateMap<WorkingHistory, WorkingHistoryDto>();
           

            CreateMap<Skill, SkillDto>();
   


            CreateMap<Certification, CertificateDto>();
         

            CreateMap<ApplicantVacancy, ApplicantVacancyDto>();
                      

        }
    }
}
