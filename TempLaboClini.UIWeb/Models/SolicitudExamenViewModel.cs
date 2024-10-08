using System.ComponentModel.DataAnnotations;

namespace TempLaboClini.UIWeb.Models
{
    public class SolicitudExamenViewModel
    {
        [Required]
        [Display(Name = "Número de Identificación del Paciente")]
        public string PacienteNroIdentificacion { get; set; }

        [Required]
        [Display(Name = "ID de Aseguradora")]
        public long AseguradoraId { get; set; }

        [Required]
        [Display(Name = "ID del Médico")]
        public long MedicoId { get; set; }

        [Required]
        [Display(Name = "Número de Registro")]
        public int NroRegistro { get; set; }

        [Required]
        [Display(Name = "Ingreso Por")]
        public string IngresoPor { get; set; }

        [Required]
        [Display(Name = "Fecha de Solicitud")]
        public DateTime FechaSolicitud { get; set; }
    }
}
