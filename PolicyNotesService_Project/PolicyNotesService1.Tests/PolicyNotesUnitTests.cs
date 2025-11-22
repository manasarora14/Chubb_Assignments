using Microsoft.EntityFrameworkCore;
using PolicyNotesService.Data;
using PolicyNotesService.DTOs;
using PolicyNotesService.Repositories;
using PolicyNotesService.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PolicyNotesService1.Tests
{
    public class PolicyNotesUnitTests
    {
        private IPolicyNotesService GetService()
        {
            // Create a NEW in-memory DB for each test
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())   // FIXED
                .Options;

            var context = new AppDbContext(options);
            var repo = new PolicyNotesRepository(context);

            return new PolicyNotesService.Services.PolicyNotesService(repo);

        }

        [Fact]
        public async Task AddNote_Should_AddSuccessfully()
        {
            var service = GetService();
            var dto = new CreateNoteDto("P123", "Test Note");

            var result = await service.AddNoteAsync(dto);

            Assert.NotNull(result);
            Assert.Equal("P123", result.PolicyNumber);
            Assert.Equal("Test Note", result.Note);
        }

        [Fact]
        public async Task GetNotes_Should_ReturnNotes()
        {
            var service = GetService();
            await service.AddNoteAsync(new CreateNoteDto("P111", "Sample Note"));

            var notes = await service.GetNotesAsync();

            Assert.NotEmpty(notes);
            Assert.Single(notes);
        }
    }
}
