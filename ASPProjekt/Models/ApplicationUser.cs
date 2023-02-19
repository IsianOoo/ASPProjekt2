using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace ASPProjekt.Models;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Required]
    [MaxLength(255)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(255)]
    public string LastName { get; set; }


}
