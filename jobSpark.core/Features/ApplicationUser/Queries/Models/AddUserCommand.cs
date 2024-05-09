using jobSpark.core.Bases;
using MediatR;


namespace jobSpark.core.Features.ApplicationUser.Queries.Models
{
    public class AddUserCommand : IRequest<Response<string>>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
