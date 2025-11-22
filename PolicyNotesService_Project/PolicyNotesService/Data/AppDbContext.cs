using Microsoft.EntityFrameworkCore;
using PolicyNotesService.Models;

namespace PolicyNotesService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<PolicyNote> PolicyNotes => Set<PolicyNote>();
}
