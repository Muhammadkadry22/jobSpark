namespace jobSpark.core.Features.certification.queries.Dtos
{
    public class CertificateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Institution { get; set; }
        public string? Image { get; set; }
        public DateTime CompletedDate { get; set; }
        public int? ApplicantId { get; set; }
    }
}
