﻿using AutoMapper;
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

namespace jobSpark.core.mapping.VacancyMapping
{
    public class VacancyProfile : Profile
    {
        public VacancyProfile()
        {
            CreateMap<Vacancy, GetVacancyListDto>()
                .ForMember(des => des.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(des => des.CategoryName, opt => opt.MapFrom(src => src.Company.Name));


            CreateMap<Vacancy,GetVacancyByIdDto>()
                 .ForMember(des => des.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(des => des.CategoryName, opt => opt.MapFrom(src => src.Company.Name));

            CreateMap<AddVacancyCommand, Vacancy>();

            CreateMap<ApplyToVacancyCommand, ApplicantVacancy>();
                

        }
    }
}
