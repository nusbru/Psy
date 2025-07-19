using System.ComponentModel.DataAnnotations;

namespace PsyApp.UI.Data;

public class Patient
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;
    
    [StringLength(15)]
    public string? PhoneNumber { get; set; }
    
    [EmailAddress]
    [StringLength(256)]
    public string? Email { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Foreign key to Doctor
    public int DoctorId { get; set; }
    
    // Navigation property
    public Doctor Doctor { get; set; } = null!;
    
    public string FullName => $"{Name} {LastName}";
}
