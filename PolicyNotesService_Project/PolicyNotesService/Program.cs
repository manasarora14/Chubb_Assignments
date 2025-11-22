using Microsoft.EntityFrameworkCore;
using PolicyNotesService.Data;
using PolicyNotesService.DTOs;
using PolicyNotesService.Repositories;
using PolicyNotesService.Services;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core InMemory
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("PolicyNotesDb"));

// DI
builder.Services.AddScoped<IPolicyNotesRepository, PolicyNotesRepository>();
builder.Services.AddScoped<IPolicyNotesService, PolicyNotesService.Services.PolicyNotesService>();


var app = builder.Build();

// POST /notes
app.MapPost("/notes", async (CreateNoteDto dto, IPolicyNotesService service) =>
{
    var note = await service.AddNoteAsync(dto);
    return Results.Created($"/notes/{note.Id}", note);
});

// GET /notes
app.MapGet("/notes", async (IPolicyNotesService service) =>
{
    return Results.Ok(await service.GetNotesAsync());
});

// GET /notes/{id}
app.MapGet("/notes/{id:int}", async (int id, IPolicyNotesService service) =>
{
    var note = await service.GetNoteByIdAsync(id);
    return note is null ? Results.NotFound() : Results.Ok(note);
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();

public partial class Program { }

