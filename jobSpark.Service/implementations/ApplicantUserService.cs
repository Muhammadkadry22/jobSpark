using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.UnitOfWork;
using jobSpark.Service.Abstracts;
using Microsoft.AspNetCore.Http;

namespace jobSpark.Service.implementations
{

    public class ApplicantUserService : IApplicantUserService
    {
        public readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;
        public ApplicantUserService(IUnitOfWork unitOfWork, IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        public async Task<string> AddApplicant(Applicant applicant, IFormFile file)
        {
            var res = unitOfWork._userManager.Users.FirstOrDefault(u => u.Email == applicant.Email);
            var fileUrl = await fileService.UploadFile("Applicant", file);
            switch (fileUrl)
            {
                case "NoFile": return "NoFile";
                case "FailedToUploadFile": return "FailedToUploadFile";
            }
            applicant.Cv = fileUrl;

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
