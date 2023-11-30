namespace RastreoFirplak.Application.Features.Guias.Queries
{
    public class GuiaModel
    {
        public string? NumeroGuia { get; set; }
        public string? Destino { get; set; }
        public DateTime FH_Recogido { get; set; }
        public DateTime FH_CentroOrigen { get; set; }
        public DateTime FH_Viajando { get; set; }
        public DateTime FH_CentroDestino { get; set; }
        public DateTime FH_ZonaDistribucion { get; set; }
        public DateTime FH_Entregado { get; set; }
        public DateTime FH_POD { get; set; }
    }
}
