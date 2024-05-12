using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Domain.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Industry { get; set; }
        public string? Brief { get; set; }
        public int? LaunchYear { get; set; }
        public string? HeadQuarter { get; set; }
        public int? Revenue { get; set; }
        public int? Size { get;set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }

        
        public string? UserId { get; set; }

        public virtual ICollection<Vacancy> Vacancies { get; set; }=new HashSet<Vacancy>();

        [ForeignKey("UserId")]
        public virtual User user { get; set; }
    }
}
