using jobSpark.Domain.Entities;

namespace jobSpark.core.Features.Applicant.Queries.Dtos
{
    public class GetApplicantByIdDto
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
        public string? UserId { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();
        public virtual ICollection<Certification> Certifications { get; set; } = new HashSet<Certification>();
        public virtual ICollection<WorkingHistory> WorkingHistories { get; set; } = new HashSet<WorkingHistory>();
        public virtual ICollection<Skill> Skills { get; set; } = new HashSet<Skill>();
        public virtual ICollection<ApplicantVacancy> ApplicantVacancies { get; set; }

    }
}
