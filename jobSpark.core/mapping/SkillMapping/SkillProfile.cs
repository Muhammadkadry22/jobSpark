using AutoMapper;
using jobSpark.core.Features.skills.commands.Model;
using jobSpark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.mapping.SkillMapping
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<AddSkillCommand, Skill>();
        }

    }
}
