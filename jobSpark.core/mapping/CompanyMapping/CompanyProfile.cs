using AutoMapper;
using jobSpark.core.Features.Company.Queries.Dtos;
using jobSpark.core.Features.vacancy.queries.Dtos;
using jobSpark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.mapping.CompanyMapping
{
    public class CompanyProfile:Profile
    {
        public CompanyProfile() 
        { 
            CreateMap<Company,GetCompanyListDto>()
                .ForMember(des=>des.Vacancies,opt=>opt.MapFrom(src=>src.Vacancies));


            CreateMap<Vacancy, GetVacancyListDto>()
                           .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));
        }
    }
}
