using PolicyNotesService.DTOs;
using PolicyNotesService.Models;
using PolicyNotesService.Repositories;



namespace PolicyNotesService.Services;

public interface IPolicyNotesService
{
    Task<PolicyNote> AddNoteAsync(CreateNoteDto dto);
    Task<List<PolicyNote>> GetNotesAsync();
    Task<PolicyNote?> GetNoteByIdAsync(int id);
}

public class PolicyNotesService : IPolicyNotesService
{
    private readonly IPolicyNotesRepository _repo;

    public PolicyNotesService(IPolicyNotesRepository repo)
    {
        _repo = repo;
    }

    public async Task<PolicyNote> AddNoteAsync(CreateNoteDto dto)
    {
        var note = new PolicyNote
        {
            PolicyNumber = dto.PolicyNumber,
            Note = dto.Note
        };

        return await _repo.AddAsync(note);
    }

    public Task<List<PolicyNote>> GetNotesAsync() => _repo.GetAllAsync();

    public Task<PolicyNote?> GetNoteByIdAsync(int id) => _repo.GetByIdAsync(id);
}
