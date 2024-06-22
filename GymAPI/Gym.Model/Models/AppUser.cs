using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Gym.Model.Models
{
    public class AppUser : IdentityUser
    {
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Surname { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? PESEL { get; set; }
    }
}
