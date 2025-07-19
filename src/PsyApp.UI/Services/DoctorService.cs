using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PsyApp.UI.Data;

namespace PsyApp.UI.Services;

public interface IDoctorService
{
    Task<Doctor?> GetCurrentDoctorAsync(string userId);
    Task<int?> GetCurrentDoctorIdAsync(string userId);
}

public class DoctorService : IDoctorService
{
    private readonly ApplicationDbContext _context;

    public DoctorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Doctor?> GetCurrentDoctorAsync(string userId)
    {
        return await _context.Doctors
            .FirstOrDefaultAsync(d => d.ApplicationUserId == userId);
    }

    public async Task<int?> GetCurrentDoctorIdAsync(string userId)
    {
        var doctor = await GetCurrentDoctorAsync(userId);
        return doctor?.Id;
    }
}
