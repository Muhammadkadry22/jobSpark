using jobSpark.Domain.Entities;

namespace jobSpark.Service.Abstracts
{
    public interface ICompanyService
    {
        public Task<List<Company>> GetCompanyListAsync();

        public Task<int> GetCompanyByUserId(string userId);

        public Task<Company> GetCompanyByIdAsync(int id);
    }
}
