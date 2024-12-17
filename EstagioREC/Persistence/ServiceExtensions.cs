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
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("Estagio"));

            services.AddScoped<IOrientadorRepository, OrientadorRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>(); // TODO: Implementar
            //services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            //services.AddScoped<IEstagioRepository, EstagioRepository>();
        }
    }
}
