using jobSpark.core.Features.ApplicantVacancy.queries.Dtos;
using jobSpark.core.Features.certification.queries.Dtos;
using jobSpark.core.Features.project.queries.Dtos;
using jobSpark.core.Features.skills.queries.Dtos;
using jobSpark.core.Features.workingHistory.queries.Dtos;
using jobSpark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.vacancy.queries.Dtos
{
    public class GetVacancyApplicantsDto
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

        public virtual ICollection<ProjectDto> Projects { get; set; } = new HashSet<ProjectDto>();
        public virtual ICollection<CertificateDto> Certifications { get; set; } = new HashSet<CertificateDto>();
        public virtual ICollection<WorkingHistoryDto> WorkingHistories { get; set; } = new HashSet<WorkingHistoryDto>();
        public virtual ICollection<SkillDto> Skills { get; set; } = new HashSet<SkillDto>();
        public virtual ICollection<ApplicantVacancyDto> ApplicantVacancies { get; set; }

    }
}
