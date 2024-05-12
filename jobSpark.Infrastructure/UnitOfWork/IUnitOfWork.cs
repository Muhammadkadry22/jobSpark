using jobSpark.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IVacancyRepository Vacancies { get; }

        ICategoryRepository Categories { get; }

        ICompanyRepository Companies { get; }
        ISkillRepository Skills { get; }
        IWorkingHistoryRepository WorkingHistories { get; }
        Task SaveChangesAsync();
    }
}
