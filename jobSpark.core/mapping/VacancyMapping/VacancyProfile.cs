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
            CreateMap<Project, ProjectDto>()
                         .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                         .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills))
                         .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link));

            CreateMap<WorkingHistory, WorkingHistoryDto>()
                           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                           .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                           .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                           .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position));

            CreateMap<Skill, SkillDto>()
                           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                           .ForMember(dest => dest.ApplicantId, opt => opt.MapFrom(src => src.ApplicantId));


            CreateMap<Certification, CertificateDto>()
                           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                           .ForMember(dest => dest.ApplicantId, opt => opt.MapFrom(src => src.ApplicantId))
                           .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                           .ForMember(dest => dest.Institution, opt => opt.MapFrom(src => src.Institution));

            CreateMap<ApplicantVacancy, ApplicantVacancyDto>()
                          .ForMember(dest => dest.ApplicantId, opt => opt.MapFrom(src => src.ApplicantId))
                          .ForMember(dest => dest.VacancyId, opt => opt.MapFrom(src => src.VacancyId));

        }
    }
}
