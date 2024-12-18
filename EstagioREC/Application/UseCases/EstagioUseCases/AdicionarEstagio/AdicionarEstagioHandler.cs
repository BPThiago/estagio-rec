using AutoMapper;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.AdicionarEstagio
{
    public class AdicionarEstagioHandler : IRequestHandler<AdicionarEstagioRequest, AdicionarEstagioResponse>
    {
        private readonly IEstagioRepository _estagioRepository;
        private readonly IMapper _mapper;

        public AdicionarEstagioHandler(IEstagioRepository estagioRepository, IMapper mapper)
        {
            _estagioRepository = estagioRepository;
            _mapper = mapper;
        }

        public async Task<AdicionarEstagioResponse> Handle(AdicionarEstagioRequest request,
            CancellationToken cancellationToken)
        {
            var estagio = _mapper.Map<Estagio>(request);
            await _estagioRepository.AdicionarAsync(estagio, cancellationToken);
            return _mapper.Map<AdicionarEstagioResponse>(estagio);
        }
    }
}


