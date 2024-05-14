using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.UnitOfWork;
using jobSpark.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Service.implementations
{
    public class AchievementService : IAchievementService
    {
        private readonly IUnitOfWork unitOfWork;
public AchievementService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> AddAchievementAsync(Achievement achievement)
        {
           await unitOfWork.Achievements.AddAsync(achievement);
            await unitOfWork.SaveChangesAsync();
            return "Added";
        }
    }
}
