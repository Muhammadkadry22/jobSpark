using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.UnitOfWork;
using jobSpark.Service.Abstracts;

namespace jobSpark.Service.implementations
{
    public class ApplicantService : IApplicantService
    {

        private readonly IUnitOfWork unitOfWork;
        public ApplicantService(IUnitOfWork unitOfWork) { this.unitOfWork = unitOfWork; }



        public async Task<Applicant> GetApplicantByIdAsync(int id)
        {
            return await unitOfWork.applicants.GetByIdAsync(id);
        }


    }
}
