using Microsoft.EntityFrameworkCore;
using EstagioREC.Persistence.Data;
using EstagioREC.Persistence.Repository.Implementations;
using EstagioREC.Persistence.Repository.Interfaces;
using EstagioREC.Persistence;
using EstagioREC.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistenceApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

DbInitializer.RetrieveFromSheets(app);
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();