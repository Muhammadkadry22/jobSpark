using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Domain.Entities
{
    public class Certification
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Institution  { get; set; }
        public string? Image { get; set; }
        public DateTime CompletedDate { get; set; }
        public int? ApplicantId { get; set; }

        [ForeignKey("ApplicantId")]
        public Applicant? Applicant { get; set; }
        public ICollection<Achievement> Achievements { get; set;}=new HashSet<Achievement>();
    }
}
