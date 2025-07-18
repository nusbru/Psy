using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PsyApp.UI.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Configure one-to-one relationship between ApplicationUser and Doctor
        builder.Entity<ApplicationUser>()
            .HasOne(u => u.Doctor)
            .WithOne(d => d.ApplicationUser)
            .HasForeignKey<Doctor>(d => d.ApplicationUserId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // Configure one-to-many relationship between Doctor and Patient
        builder.Entity<Patient>()
            .HasOne(p => p.Doctor)
            .WithMany(d => d.Patients)
            .HasForeignKey(p => p.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // Configure indexes for better performance
        builder.Entity<Patient>()
            .HasIndex(p => p.DoctorId);
    }
}
