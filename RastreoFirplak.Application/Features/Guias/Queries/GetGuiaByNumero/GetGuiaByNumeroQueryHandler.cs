using AutoMapper;
using MediatR;
using RastreoFirplak.Application.Contracts.Persistence;

namespace RastreoFirplak.Application.Features.Guias.Queries.GetGuiaById
{
    public class GetGuiaByNumeroQueryHandler : IRequestHandler<GetGuiaByNumeroQuery, GuiaModel>
    {
        private readonly IGuiaRepository _guiaRepository;
        private readonly IMapper _mapper;

        public GetGuiaByNumeroQueryHandler(IGuiaRepository guiaRepository, IMapper mapper)
        {
            _guiaRepository = guiaRepository;
            _mapper = mapper;
        }

        async Task<GuiaModel> IRequestHandler<GetGuiaByNumeroQuery, GuiaModel>.Handle(GetGuiaByNumeroQuery request, CancellationToken cancellationToken)
        {
            var guia = await _guiaRepository.GetGuiaByNumero(request.Numero);

            return _mapper.Map<GuiaModel>(guia);
        }
    }
}
