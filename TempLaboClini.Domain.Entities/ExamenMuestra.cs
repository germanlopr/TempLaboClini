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


        public long PersonalLaboratorioId { get; set; }
        public long ExamenSolicitadoId { get; set; }


        public PersonalLaboratorio PersonalLaboratorio { get; set; }
        public ExamenSolicitado ExamenSolicitado { get; set; }

        public ICollection<Resultado> Resultados { get; set; }
    }
}