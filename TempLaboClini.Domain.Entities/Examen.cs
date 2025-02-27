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

        // Relaci�n con �rea
        public Area Area { get; set; } = null!;

        // Relaci�n muchos a muchos con Muestra (a trav�s de ExamenMuestra)
        public ICollection<ExamenMuestra> ExamenesMuestras { get; set; } = new List<ExamenMuestra>();

        // Relaci�n con Prueba (Uno a Muchos)
        public ICollection<Prueba> Pruebas { get; set; } = new List<Prueba>();

        // Relaci�n con ExamenSolicitado (Uno a Muchos)
        public ICollection<ExamenSolicitado> ExamenesSolicitados { get; set; } = new List<ExamenSolicitado>();

    }

}