

namespace TempLaboClini.Domain.Entities
{
    public class Prueba : BaseEntity
    {
        public long ExamenId { get; set; }
        public string NombrePrueba { get; set; }
        public bool Agrupado { get; set; }
        public Examen Examen { get; set; }
        public ICollection<ValorReferencia> ValoresReferencia { get; set; }
    }
}