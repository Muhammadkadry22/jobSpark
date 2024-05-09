
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobSpark.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
