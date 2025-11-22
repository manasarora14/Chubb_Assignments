using Microsoft.AspNetCore.Mvc.Testing;
using PolicyNotesService;
using PolicyNotesService.DTOs;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

public class NotesApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public NotesApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostNotes_ShouldReturn201()
    {
        var dto = new CreateNoteDto("P100", "Integration Test Note");
        var response = await _client.PostAsJsonAsync("/notes", dto);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task GetNotes_ShouldReturn200()
    {
        var response = await _client.GetAsync("/notes");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetNoteById_ShouldReturn404_WhenMissing()
    {
        var response = await _client.GetAsync("/notes/99999");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
