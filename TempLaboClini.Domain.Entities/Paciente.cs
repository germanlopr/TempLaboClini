using System.ComponentModel.DataAnnotations;

namespace TempLaboClini.Domain.Entities
{
    public class Paciente : Persona
    {

        [Required]
        public char Sexo { get; set; }

        [Required, MaxLength(20)]
        public string HistoriaClinica { get; set; }

        // Relación con SolicitudExamen (Un paciente puede tener muchas solicitudes)
        public virtual ICollection<SolicitudExamen> SolicitudesExamen { get; set; } = new List<SolicitudExamen>();
    }
}