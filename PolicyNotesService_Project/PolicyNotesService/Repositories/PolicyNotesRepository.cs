using Microsoft.EntityFrameworkCore;
using PolicyNotesService.Data;
using PolicyNotesService.Models;

namespace PolicyNotesService.Repositories;

public class PolicyNotesRepository : IPolicyNotesRepository
{
    private readonly AppDbContext _context;

    public PolicyNotesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PolicyNote> AddAsync(PolicyNote note)
    {
        _context.PolicyNotes.Add(note);
        await _context.SaveChangesAsync();
        return note;
    }

    public async Task<List<PolicyNote>> GetAllAsync()
        => await _context.PolicyNotes.ToListAsync();

    public async Task<PolicyNote?> GetByIdAsync(int id)
        => await _context.PolicyNotes.FindAsync(id);
}
