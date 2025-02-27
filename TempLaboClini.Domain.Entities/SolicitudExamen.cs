using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TempLaboClini.Domain.Entities
{
    public class SolicitudExamen : BaseEntity
    {

        [Required]
        public int NroRegistro { get; set; }

        public virtual Paciente Paciente { get; set; } 
        public virtual Aseguradora Aseguradora { get; set; }
        public virtual Medico Medico { get; set; }

        [Required]
        public long MedicoId { get; set; }
        [Required]
        public long PacienteId { get; set; }
        [Required]
        public long AseguradoraId { get; set; }

   
        [Required, MaxLength(16)]
        public string IngresoPor { get; set; }

        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaRecepcion { get; set; }

        public virtual ICollection<ExamenSolicitado> ExamenesSolicitados { get; set; } = new List<ExamenSolicitado>();

    }
}