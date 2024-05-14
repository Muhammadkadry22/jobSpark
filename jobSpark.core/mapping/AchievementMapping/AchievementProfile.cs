using AutoMapper;
using jobSpark.core.Features.achievement.commands.Model;
using jobSpark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.mapping.AchievementMapping
{
    public class AchievementProfile : Profile
    {
        public AchievementProfile()
        {
            CreateMap<AddAchievementCommand, Achievement>();
        }
    }
}
