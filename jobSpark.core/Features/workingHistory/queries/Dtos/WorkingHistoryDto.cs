namespace jobSpark.core.Features.workingHistory.queries.Dtos
{
    public class WorkingHistoryDto
    {
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string? Position { get; set; }

        public int? ApplicantId { get; set; }
    }
}
