using System.Diagnostics.CodeAnalysis;

namespace RastreoFirplak.Domain
{
    public class Guia
    {
        public int Id { get; set; }
        public string? NumeroGuia { get; set; }
        public string? Destino { get; set; }
        public string? Correotransportador { get; set; }

        [AllowNull]
        public DateTime? FH_Recogido { get; set; }
        [AllowNull]
        public DateTime? FH_CentroOrigen { get; set; }
        [AllowNull]
        public DateTime? FH_Viajando { get; set; }
        [AllowNull]
        public DateTime? FH_CentroDestino { get; set; }
        [AllowNull]
        public DateTime? FH_ZonaDistribucion { get; set; }
        [AllowNull]
        public DateTime? FH_Entregado { get; set; }
        [AllowNull]
        public DateTime? FH_POD { get; set; }
    }
}
