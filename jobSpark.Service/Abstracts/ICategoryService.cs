using jobSpark.Domain.Entities;

namespace jobSpark.Service.Abstracts
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetCategoryListAsync();
        public Task<bool> IsCategoryIdExist(int? categoryId);
    }
}
