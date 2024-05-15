using jobSpark.core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace jobSpark.core.Features.ApplicationUser.Queries.Models
{
    public class AddApplicantCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string GraduationYear { get; set; }
        public int Experience { get; set; }
        public string Website { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Brief { get; set; }

        public IFormFile? Cv { get; set; }



       

    }
}
