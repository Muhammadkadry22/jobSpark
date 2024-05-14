namespace jobSpark.Domain.Entities
{
    public class ApplicantVacancy
    {
        public int ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }
        public int VacancyId { get; set; }
        public virtual Vacancy Vacancy { get; set; }
    }
}
