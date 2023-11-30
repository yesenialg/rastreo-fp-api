using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RastreoFirplak.Application.Contracts.Persistence;
using RastreoFirplak.Domain;
using RastreoFirplak.Infrastructure.Persistence;

namespace RastreoFirplak.Infrastructure.Repositories
{
    public class GuiaRepository : RepositoryBase<Guia>, IGuiaRepository
    {
        public GuiaRepository(EnviosDbContext context) : base(context)
        {
        }
        public async Task<Guia> GetGuiaByNumero(string numeroGuia)
        {
            return await _context.Guias!.Where(o => o.NumeroGuia == numeroGuia).FirstOrDefaultAsync();
        }
    }
}
