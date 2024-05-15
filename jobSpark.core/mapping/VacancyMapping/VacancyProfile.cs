using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jobSpark.Domain.Entities;
using jobSpark.core.Features.vacancy.queries.Dtos;

using System.ComponentModel;

using jobSpark.core.Features.vacancy.commands.Model;
using jobSpark.core.Features.Company.Queries.Dtos;
using jobSpark.core.Features.vacancy.queries.Model;
using jobSpark.core.Features.ApplicantVacancy.queries.Dtos;
using jobSpark.core.Features.certification.queries.Dtos;
using jobSpark.core.Features.project.queries.Dtos;
using jobSpark.core.Features.skills.queries.Dtos;
using jobSpark.core.Features.workingHistory.queries.Dtos;

namespace jobSpark.core.mapping.VacancyMapping
{
    public class VacancyProfile : Profile
    {
        public VacancyProfile()
        {
            CreateMap<Vacancy, GetVacancyListDto>()
                .ForMember(des => des.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(des => des.CompanyName, opt => opt.MapFrom(src => src.Company.Name));


            CreateMap<Vacancy,GetVacancyByIdDto>()
                 .ForMember(des => des.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(des => des.CompanyName, opt => opt.MapFrom(src => src.Company.Name));

            CreateMap<AddVacancyCommand, Vacancy>();

            CreateMap<ApplyToVacancyCommand, ApplicantVacancy>();

            CreateMap<Applicant, GetVacancyApplicantsDto>();
            CreateMap<Project, ProjectDto>();
   
            CreateMap<WorkingHistory, WorkingHistoryDto>();


            CreateMap<Skill, SkillDto>();
       


            CreateMap<Certification, CertificateDto>();
         

            CreateMap<ApplicantVacancy, ApplicantVacancyDto>();
                         

        }
    }
}
