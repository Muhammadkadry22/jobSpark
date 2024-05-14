using AutoMapper;
using jobSpark.core.Features.project.commands.Model;
using jobSpark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.mapping.ProjectMapping
{
    public class ProjectProfile:Profile
    {
        public ProjectProfile() 
        {
            CreateMap<AddProjectCommand, Project>();
        }
    }
}
