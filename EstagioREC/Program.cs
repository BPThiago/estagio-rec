using EstagioREC.Data;
using EstagioREC.Repository.Implementations;
using EstagioREC.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("Estagio"));

builder.Services.AddScoped<IOrientadorRepository, OrientadorRepository>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEstagioRepository, EstagioRepository>();

var app = builder.Build();

// Inicialização do banco de dados
DbInitializer.RetrieveFromSheets(app);
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
