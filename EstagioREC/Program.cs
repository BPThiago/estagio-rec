using EstagioREC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EstagioDb>(opt => opt.UseInMemoryDatabase("Estagio"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

DbInitializer.RetrieveFromSheets(app);

app.MapGet("/orientadores", async (EstagioDb db) =>
    await db.Orientadores.ToListAsync());


app.MapGet("/orientadores/{id}", async (int id, EstagioDb db) =>
    await db.Orientadores.FindAsync(id)
        is Orientador orientador
            ? Results.Ok(orientador)
            : Results.NotFound());

app.MapPost("/orientadores", async (Orientador orientador, EstagioDb db) =>
{
    db.Orientadores.Add(orientador);
    await db.SaveChangesAsync();

    return Results.Created($"/orientadores/{orientador.Id}", orientador);
});

app.Run();