using AutoMapper;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.AdicionarOrientador
{
    public class AdicionarOrientadorHandler : IRequestHandler<AdicionarOrientadorRequest, AdicionarOrientadorResponse>
    {
        private readonly IOrientadorRepository _orientadorRepository;
        private readonly IMapper _mapper;

        public AdicionarOrientadorHandler(IOrientadorRepository orientadorRepository, IMapper mapper)
        {
            _orientadorRepository = orientadorRepository;
            _mapper = mapper;
        }

        public async Task<AdicionarOrientadorResponse> Handle(AdicionarOrientadorRequest request, CancellationToken cancellationToken)
        {
            var orientador = _mapper.Map<Orientador>(request);
            await _orientadorRepository.AdicionarAsync(orientador);
            return _mapper.Map<AdicionarOrientadorResponse>(orientador);
        }
    }
}
