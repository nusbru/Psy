using Microsoft.AspNetCore.Identity;

namespace PsyApp.UI.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    // Navigation property to Doctor
    public Doctor? Doctor { get; set; }
}

