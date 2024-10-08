namespace TempLaboClini.Domain.Entities
{

    public class ValorReferencia : BaseEntity
    {
        public long PruebaId { get; set; }
        public decimal EdadMinimaAnios { get; set; }
        public decimal EdadMaximaAnios { get; set; }
        public char Sexo { get; set; }
        public decimal ValorMinimo { get; set; }
        public decimal ValorMaximo { get; set; }
        public string Unidad { get; set; }
        public string Interpretacion { get; set; }
        public Prueba Prueba { get; set; }
    }
}


