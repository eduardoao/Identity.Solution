using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.Data.Entities
{
    // Add profile data for application users by adding properties to this class
    public class AppUser : IdentityUser
    {
        // Extended Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Cpf { get; set; }
    }
}
