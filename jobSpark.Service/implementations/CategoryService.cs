using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.UnitOfWork;
using jobSpark.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace jobSpark.Service.implementations
{
    public class CategoryService : ICategoryService
    {
        public readonly IUnitOfWork unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Category>> GetCategoryListAsync()
        {
            return (await unitOfWork.Categories.GetAllAsync()).ToList();
        }
        public async Task<bool> IsCategoryIdExist(int? categoryId)
        {
            if (categoryId == null) return false;
            return await unitOfWork.Categories.GetTableNoTracking().AnyAsync(x => x.Id.Equals(categoryId));
        }



    }
}
