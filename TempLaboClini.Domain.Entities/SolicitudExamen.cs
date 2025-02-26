using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TempLaboClini.Domain.Entities
{
    public class SolicitudExamen : BaseEntity
    {

        [Required]
        public int NroRegistro { get; set; }

        [Required]
        public long PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public virtual Paciente Paciente { get; set; }

        [Required]
        public long AseguradoraId { get; set; }

        [ForeignKey("AseguradoraId")]
        public virtual Aseguradora Aseguradora { get; set; }

        [Required]
        public long MedicoId { get; set; }

        [ForeignKey("MedicoId")]
        public virtual Medico Medico { get; set; }

        [Required, MaxLength(16)]
        public string IngresoPor { get; set; }

        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaRecepcion { get; set; }

        public virtual ICollection<ExamenSolicitado> ExamenesSolicitados { get; set; } = new List<ExamenSolicitado>();

    }
}