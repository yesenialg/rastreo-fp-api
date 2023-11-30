using MediatR;

namespace RastreoFirplak.Application.Features.Guias.Queries.GetGuiaById
{
    public class GetGuiaByNumeroQuery : IRequest<GuiaModel>
    {
        public string Numero { get; set; } = string.Empty;

        public GetGuiaByNumeroQuery(string numero)
        {
            Numero = numero ?? throw new ArgumentNullException(nameof(numero));
        }
    }
}
