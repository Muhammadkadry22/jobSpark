using jobSpark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.category.queries.Dtos
{
    public class GetCategoryListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public HashSet<Vacancy> Vacancies { get; set; } 
    }
}
