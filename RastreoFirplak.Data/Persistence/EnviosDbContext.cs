using Microsoft.EntityFrameworkCore;
using RastreoFirplak.Domain;

namespace RastreoFirplak.Infrastructure.Persistence
{
    public class EnviosDbContext : DbContext
    {
        public EnviosDbContext(DbContextOptions<EnviosDbContext> options) : base(options)
        {
        }

        public DbSet<Guia>? Guias { get; set; }
        public DbSet<DocumentoPOD>? DocumentoPODs { get; set; }
        public DbSet<DocumentoEntrega>? DocumentosEntregas { get; set; }
    }
}
