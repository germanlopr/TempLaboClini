using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TempLaboClini.Domain.Entities
{
    public class Examen : BaseEntity
    {
        public long AreaId { get; set; }
        public string CodigoSOAT { get; set; }

        public string Nombre { get; set; }
        public string SignificanciaClinica { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal Precio { get; set; }

        public string CodigoCUPS { get; set; }

        // Relación con Área
        public Area Area { get; set; } = null!;

        // Relación muchos a muchos con Muestra (a través de ExamenMuestra)
        public ICollection<ExamenMuestra> ExamenesMuestras { get; set; } = new List<ExamenMuestra>();

        // Relación con Prueba (Uno a Muchos)
        public ICollection<Prueba> Pruebas { get; set; } = new List<Prueba>();

        // Relación con ExamenSolicitado (Uno a Muchos)
        public ICollection<ExamenSolicitado> ExamenesSolicitados { get; set; } = new List<ExamenSolicitado>();

    }

}