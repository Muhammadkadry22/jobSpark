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
       

    }
}
