using jobSpark.core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.ApplicationUser.Queries.Models
{
    public class AddCompanyCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string? Role { get; set; }
        public string? Industry { get; set; }
        public string? Brief { get; set; }
        public int? LaunchYear { get; set; }
        public string? HeadQuarter { get; set; }
        public int? Revenue { get; set; }
        public int? Size { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
    }
}
