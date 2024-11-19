using Microsoft.EntityFrameworkCore;
using EstagioREC.Data;
using EstagioREC.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("Estagio"));

builder.Services.AddScoped<IOrientadorRepository, OrientadorRepository>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();

var app = builder.Build();

DbInitializer.RetrieveFromSheets(app);
app.MapControllers();

app.Run();