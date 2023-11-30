namespace RastreoFirplak.Domain
{
    public class DocumentoEntrega
    {
        public int Id { get; set; }
        public DateTime FechaDespacho { get; set; }
        public DateTime fechaEntrega { get; set; }
        public int GuiaId { get; set; }

        public virtual Guia? Guia { get; set; }
    }
}
