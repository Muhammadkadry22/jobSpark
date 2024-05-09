using jobSpark.Infrastructure.Abstractions;
using jobSpark.Infrastructure.Context;
using jobSpark.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Infrastructure.UnitOfWork
{
    public class unitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IVacancyRepository Vacancies { get; private set; }
         public ICategoryRepository Categories { get; private set; }

        public unitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Vacancies = new VacancyRepository(_context);
            Categories=new CategoryRepository(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
       
        

    }

