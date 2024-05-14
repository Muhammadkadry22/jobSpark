using jobSpark.Domain.Entities;

namespace jobSpark.Service.Abstracts
{
    public interface IApplicantService
    {
        public Task<Applicant> GetApplicantByIdAsync(int id);
    }
}
