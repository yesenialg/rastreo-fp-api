using MediatR;

namespace RastreoFirplak.Application.Features.Guias.Queries.GetGuiaById
{
    public class GetGuiaByIdQuery : IRequest<GuiaModel>
    {
        public string Id { get; set; } = string.Empty;

        public GetGuiaByIdQuery(string id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
