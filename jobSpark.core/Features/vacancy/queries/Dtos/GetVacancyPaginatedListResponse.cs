using jobSpark.Domain.Enum;

namespace jobSpark.core.Features.vacancy.queries.Dtos
{
    public class GetVacancyPaginatedListResponse
    {

        public GetVacancyPaginatedListResponse(int id, string VacancyName, DateTime openDate, EState state, string description, int? applicantCount, int? reviewCount, int? categoryId, string? CategoryName, int? companyId, string? CompanyName)
        {
            Id = id;
            this.VacancyName = VacancyName;
            OpenDate = openDate;
            State = state;
            Description = description;
            ApplicantCount = applicantCount;
            ReviewCount = reviewCount;
            CategoryId = categoryId;
            this.CategoryName = CategoryName;
            CompanyId = companyId;
            this.CompanyName = CompanyName;
        }

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
