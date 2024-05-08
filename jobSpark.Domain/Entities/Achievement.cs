using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Domain.Entities
{
    public class Achievement
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project? Project { get; set; }

        public int? CertificationId { get; set; }
        [ForeignKey("CertificationId")]
        public virtual Certification? Certifications { get; set; }

        public int? WorkingHistoryId { get; set; }
        [ForeignKey("WorkingHistoryId")]
        public virtual WorkingHistory? WorkingHistories { get; set; }
      
    }
}
