using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.UnitOfWork;
using jobSpark.Service.Abstracts;

namespace jobSpark.Service.implementations
{

    public class ApplicantUserService : IApplicantUserService
    {
        public readonly IUnitOfWork unitOfWork;
        public ApplicantUserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> AddApplicant(Applicant applicant)
        {
            var res = unitOfWork._userManager.Users.FirstOrDefault(u=>u.Email == applicant.Email);
            if (res != null)
            {
                applicant.UserId = res.Id;
            }
            await unitOfWork.applicants.AddAsync(applicant);
            await unitOfWork.SaveChangesAsync();
            return "Added";
        }

        public async Task<int> GetApplicantIdByUserId(string userId)
        {
            return unitOfWork.applicants.FindAsync(u => u.UserId == userId).Result.Id;
        }
    }
}
