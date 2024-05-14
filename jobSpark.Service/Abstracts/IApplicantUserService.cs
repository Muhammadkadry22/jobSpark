using jobSpark.Domain.Entities;

namespace jobSpark.Service.Abstracts
{
    public interface IApplicantUserService
    {
        public Task<string> AddApplicant(Applicant applicant);

    }
}
