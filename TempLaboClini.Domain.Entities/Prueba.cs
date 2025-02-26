

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TempLaboClini.Domain.Entities
{
    public class Prueba : BaseEntity
    {
        [Required]
        public long ExamenId { get; set; }

        [ForeignKey("ExamenId")]
        public virtual Examen Examen { get; set; }

        [Required, MaxLength(50)]
        public string NombrePrueba { get; set; }

        [Required]
        public bool Agrupado { get; set; }

        public virtual ICollection<ValorReferencia> ValoresReferencia { get; set; } = new List<ValorReferencia>();

    }


}