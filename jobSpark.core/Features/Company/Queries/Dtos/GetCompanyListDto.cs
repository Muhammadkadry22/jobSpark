using jobSpark.core.Features.vacancy.queries.Dtos;
using jobSpark.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.Company.Queries.Dtos
{
    public class GetCompanyListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Industry { get; set; }
        public string? Brief { get; set; }
        public int? LaunchYear { get; set; }
        public string? HeadQuarter { get; set; }
        public int? Revenue { get; set; }
        public int? Size { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }

        public HashSet<GetVacancyListDto> Vacancies { get; set;}

    }
}
