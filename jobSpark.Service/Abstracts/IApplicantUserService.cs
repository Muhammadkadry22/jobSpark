using jobSpark.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace jobSpark.Service.Abstracts
{
    public interface IApplicantUserService
    {
        public Task<string> AddApplicant(Applicant applicant,IFormFile file);
        public Task<int> GetApplicantIdByUserId(string userId);

    }
}
