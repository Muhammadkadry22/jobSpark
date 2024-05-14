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
    public class SkillSevice : ISkillSevice
    {
        private readonly IUnitOfWork unitOfWork;
        public SkillSevice(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> AddSkillAsync(Skill skill)
        {
           await unitOfWork.Skills.AddAsync(skill);
            await unitOfWork.SaveChangesAsync();
            return "Added";
        }

        public async Task<bool> SkillExistsForApplicant(string name , int applicantId)
        {
            var result= await unitOfWork.Skills.FindAsync(s => s.Name == name && s.ApplicantId == applicantId);
            if(result == null) return false;
            else return true;
        }
            
        
    }
}
