using EstagioREC.Persistence.Data;
using EstagioREC.Persistence.Repository.Implementations;
using EstagioREC.Persistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstagioREC.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "Estagiorec";
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "postgres";
            var connectionString = $"Server={dbHost};Database={dbName};User Id=sa;Password={dbPassword};TrustServerCertificate=True;";

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped<IOrientadorRepository, OrientadorRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEstagioRepository, EstagioRepository>();
        }
    }
}
