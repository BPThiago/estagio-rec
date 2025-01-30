using EstagioREC.Application.Services;
using EstagioREC.Persistence;

var builder = WebApplication.CreateBuilder(args);
// Adiciona CORS permitindo todas as origens
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configuração da persistência e aplicação
builder.Services.ConfigurePersistenceApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//DbInitializer.RetrieveFromSheets(app);

// Aplica o middleware de CORS antes dos controllers
app.UseCors("AllowAllOrigins");

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
