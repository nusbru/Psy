using System.ComponentModel.DataAnnotations;

namespace PsyApp.UI.Data;

public class Doctor
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [StringLength(20)]
    public string LicenseNumber { get; set; } = string.Empty;
    
    [StringLength(100)]
    public string? Specialization { get; set; }
    
    [StringLength(15)]
    public string? PhoneNumber { get; set; }
    
    [StringLength(500)]
    public string? Bio { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation property to ApplicationUser
    public string ApplicationUserId { get; set; } = string.Empty;
    public ApplicationUser ApplicationUser { get; set; } = null!;
    
    public string FullName => $"{FirstName} {LastName}";
}
