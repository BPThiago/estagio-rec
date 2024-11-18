using Microsoft.EntityFrameworkCore;
using EstagioREC.Data;
using EstagioREC.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<EstagioDb>(opt => opt.UseInMemoryDatabase("Estagio"));

builder.Services.AddScoped<IOrientadorRepository, OrientadorRepository>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();

var app = builder.Build();

DbInitializer.RetrieveFromSheets(app);
app.MapControllers();

app.Run();