using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempLaboClini.Domain.Entities
{
    public class Persona : BaseEntity
    {
        public string NroIdentificacion { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; }

        [Required, MaxLength(50)]
        public string Apellido { get; set; }

        [MaxLength(50)]
        public string SegundoApellido { get; set; }

        [Required]
        public long DireccionId { get; set; }

        [ForeignKey("DireccionId")]
        public virtual Direccion Direccion { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}
