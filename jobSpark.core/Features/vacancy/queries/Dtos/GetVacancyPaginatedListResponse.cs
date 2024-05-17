using jobSpark.Domain.Enum;

namespace jobSpark.core.Features.vacancy.queries.Dtos
{
    public class GetVacancyPaginatedListResponse
    {

        public int Id { get; set; }
        public string? VacancyName { get; set; }
        public DateTime OpenDate { get; set; }
        public EState State { get; set; }
        public string? Description { get; set; }
        public int? ApplicantCount { get; set; }
        public int? ReviewCount { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }

    }
}
