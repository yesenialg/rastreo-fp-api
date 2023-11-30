using AutoMapper;
using MediatR;
using RastreoFirplak.Application.Contracts.Persistence;

namespace RastreoFirplak.Application.Features.Guias.Queries.GetGuiaById
{
    public class GetGuiaByIdQueryHandler : IRequestHandler<GetGuiaByIdQuery, GuiaModel>
    {
        private readonly IGuiaRepository _guiaRepository;
        private readonly IMapper _mapper;

        public GetGuiaByIdQueryHandler(IGuiaRepository guiaRepository, IMapper mapper)
        {
            _guiaRepository = guiaRepository;
            _mapper = mapper;
        }

        async Task<GuiaModel> IRequestHandler<GetGuiaByIdQuery, GuiaModel>.Handle(GetGuiaByIdQuery request, CancellationToken cancellationToken)
        {
            var guia = await _guiaRepository.GetByIdAsync(int.Parse(request.Id));

            return _mapper.Map<GuiaModel>(guia);
        }
    }
}
