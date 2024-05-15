using AutoMapper;
using jobSpark.core.Features.ApplicationUser.Commands.Models;
using jobSpark.core.Features.ApplicationUser.Queries.Models;
using jobSpark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.mapping.ApplicationUser
{
    public class ApplicationUserProfile : Profile  
    {
        public ApplicationUserProfile() {

            CreateMap<AddApplicantCommand, User>();
            CreateMap<AddApplicantCommand, Applicant>();
            CreateMap<AddCompanyCommand, User>();
            CreateMap<AddCompanyCommand, Company>();
            CreateMap<AddCompanyCommand, Project>();
            CreateMap<AddCompanyCommand, WorkingHistory>();
        }

    }
}
