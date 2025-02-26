using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TempLaboClini.Domain.Entities
{

        [Table("Medico")]
        public class Medico : Persona
        {

            [Required]
            [StringLength(12)]
            public string CodigoMedico { get; set; }

            [Required]
            [StringLength(50)]
            public string Especialidad { get; set; }

            // Relación con SolicitudExamen
            public virtual ICollection<SolicitudExamen> SolicitudesExamen { get; set; } = new List<SolicitudExamen>();
        }
    
}
