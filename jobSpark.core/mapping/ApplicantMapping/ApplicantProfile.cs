using AutoMapper;
using jobSpark.core.Features.Applicant.Queries.Dtos;
using jobSpark.Domain.Entities;

namespace jobSpark.core.mapping.ApplicantMapping
{
    public class ApplicantProfile : Profile
    {
        ApplicantProfile()
        {

            CreateMap<Applicant, GetApplicantByIdDto>()
                .ForMember(des => des.Certifications, opt => opt.MapFrom(src => src.Certifications))
                .ForMember(des => des.WorkingHistories, opt => opt.MapFrom(src => src.WorkingHistories))
                .ForMember(des => des.Projects, opt => opt.MapFrom(src => src.Projects))
                .ForMember(des => des.Skills, opt => opt.MapFrom(src => src.Skills))
                .ForMember(des => des.ApplicantVacancies, opt => opt.MapFrom(src => src.ApplicantVacancies));


        }
    }
}
