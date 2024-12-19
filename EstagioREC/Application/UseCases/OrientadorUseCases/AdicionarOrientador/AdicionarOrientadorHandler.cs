using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.AdicionarOrientador
{
    public class AdicionarOrientadorHandler : IRequestHandler<AdicionarOrientadorRequest, OrientadorResponse>
    {
        private readonly IOrientadorRepository _orientadorRepository;
        private readonly IMapper _mapper;

        public AdicionarOrientadorHandler(IOrientadorRepository orientadorRepository, IMapper mapper)
        {
            _orientadorRepository = orientadorRepository;
            _mapper = mapper;
        }

        public async Task<OrientadorResponse> Handle(AdicionarOrientadorRequest request, CancellationToken cancellationToken)
        {
            var orientador = _mapper.Map<Orientador>(request);
            await _orientadorRepository.AdicionarAsync(orientador, cancellationToken);
            return _mapper.Map<OrientadorResponse>(orientador);
        }
    }
}
