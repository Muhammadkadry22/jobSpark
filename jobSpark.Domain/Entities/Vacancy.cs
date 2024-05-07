using jobSpark.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Domain.Entities
{
    public class Vacancy
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime OpenDate { get; set; }
        public EState State { get; set; }
        public string? Description { get; set; }
        public int? ApplicantCount { get; set; }
        public int? ReviewCount { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
        public ICollection<ApplicantVacancy> ApplicantVacancies { get; set; }
    }
}
