using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Domain.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }
        public string? Skills { get; set; }
        public int? ApplicantId { get; set; }

        [ForeignKey("ApplicantId")]
        public Applicant? Applicant { get; set; }


        public ICollection<Achievement> Achievements { get; set;} =new HashSet<Achievement>();


    }
}
