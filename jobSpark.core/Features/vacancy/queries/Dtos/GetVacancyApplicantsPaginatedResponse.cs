namespace jobSpark.core.Features.vacancy.queries.Dtos
{
    public class GetVacancyApplicantsPaginatedResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Brief { get; set; }
        public string? Cv { get; set; }
        public string? GraduationYear { get; set; }
        public int? Experience { get; set; }
        public string? Website { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
    }
}
