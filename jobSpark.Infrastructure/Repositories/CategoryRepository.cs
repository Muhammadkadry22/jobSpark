using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.Abstractions;
using jobSpark.Infrastructure.Context;
using jobSpark.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
    {
        private readonly DbSet<Category> _categories;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _categories = context.Set<Category>();
        }

    }
}
