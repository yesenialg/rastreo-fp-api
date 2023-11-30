using RastreoFirplak.Domain;

namespace RastreoFirplak.Application.Contracts.Persistence
{
    public interface IGuiaRepository : IAsyncRepository<Guia>
    {
        public Task<Guia> GetGuiaByNumero(string numeroGuia);
    }
}
