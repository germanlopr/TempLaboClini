using System.ComponentModel.DataAnnotations.Schema;

namespace TempLaboClini.Domain.Entities
{
    public class ExamenMuestra : BaseEntity
    {
        public long ExamenId { get; set; }
        public long MuestraId { get; set; }

        // Propiedades de navegación (agrega [ForeignKey] para claridad)
        [ForeignKey("ExamenId")]
        public Examen Examen { get; set; }

        [ForeignKey("MuestraId")]
        public Muestra Muestra { get; set; }
    }
}