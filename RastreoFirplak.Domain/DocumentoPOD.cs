namespace RastreoFirplak.Domain
{
    public class DocumentoPOD
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public int GuiaId { get; set; }

        public virtual Guia? Guia { get; set; }
    }
}
