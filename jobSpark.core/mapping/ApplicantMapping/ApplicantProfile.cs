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

            CreateMap<Applicant, GetApplicantByIdDto>()
                .ForMember(des => des.Certifications, opt => opt.MapFrom(src => src.Certifications))
                .ForMember(des => des.WorkingHistories, opt => opt.MapFrom(src => src.WorkingHistories))
                .ForMember(des => des.Projects, opt => opt.MapFrom(src => src.Projects))
                .ForMember(des => des.Skills, opt => opt.MapFrom(src => src.Skills))
                .ForMember(des => des.ApplicantVacancies, opt => opt.MapFrom(src => src.ApplicantVacancies));

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
