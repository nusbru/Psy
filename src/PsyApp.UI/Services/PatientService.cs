using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PsyApp.UI.Data;

namespace PsyApp.UI.Services;

public interface IPatientService
{
    Task<List<Patient>> GetPatientsByDoctorAsync(int doctorId);
    Task<Patient?> GetPatientByIdAsync(int id, int doctorId);
    Task<Patient> CreatePatientAsync(Patient patient);
    Task<Patient> UpdatePatientAsync(Patient patient);
    Task<bool> DeletePatientAsync(int id, int doctorId);
    Task<bool> PatientExistsAsync(int id, int doctorId);
}

public class PatientService : IPatientService
{
    private readonly ApplicationDbContext _context;

    public PatientService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Patient>> GetPatientsByDoctorAsync(int doctorId)
    {
        return await _context.Patients
            .Where(p => p.DoctorId == doctorId)
            .OrderBy(p => p.LastName)
            .ThenBy(p => p.Name)
            .ToListAsync();
    }

    public async Task<Patient?> GetPatientByIdAsync(int id, int doctorId)
    {
        return await _context.Patients
            .FirstOrDefaultAsync(p => p.Id == id && p.DoctorId == doctorId);
    }

    public async Task<Patient> CreatePatientAsync(Patient patient)
    {
        patient.CreatedAt = DateTime.UtcNow;
        patient.UpdatedAt = DateTime.UtcNow;
        
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
        return patient;
    }

    public async Task<Patient> UpdatePatientAsync(Patient patient)
    {
        patient.UpdatedAt = DateTime.UtcNow;
        
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
        return patient;
    }

    public async Task<bool> DeletePatientAsync(int id, int doctorId)
    {
        var patient = await GetPatientByIdAsync(id, doctorId);
        if (patient == null)
            return false;

        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> PatientExistsAsync(int id, int doctorId)
    {
        return await _context.Patients
            .AnyAsync(p => p.Id == id && p.DoctorId == doctorId);
    }
}
