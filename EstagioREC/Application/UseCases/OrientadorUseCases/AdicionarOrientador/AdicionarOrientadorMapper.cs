using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.AdicionarOrientador
{
    public sealed class AdicionarOrientadorMapper : Profile
    {
        public AdicionarOrientadorMapper()
        {
            CreateMap<AdicionarOrientadorRequest, Orientador>();
            CreateMap<Orientador, OrientadorResponse>();
        }
    }
}
