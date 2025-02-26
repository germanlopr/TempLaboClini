

namespace TempLaboClini.Domain.Entities
{

    public class Aseguradora : BaseEntity
    {
        public string CodigoAseguradora { get; set; }
        public string NombreAseguradora { get; set; }
        public long DireccionId { get; set; }
        public Direccion Direccion { get; set; }
    }
}