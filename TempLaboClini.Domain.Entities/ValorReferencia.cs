using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TempLaboClini.Domain.Entities
{

    public class ValorReferencia : BaseEntity
    {

        [Required]
        public long PruebaId { get; set; }

        [ForeignKey("PruebaId")]
        public virtual Prueba Prueba { get; set; }

        [Required, MaxLength(50)]
        public string TipoReferencia { get; set; }

        [Required, MaxLength(50)]
        public string ValorMinimo { get; set; }

        [Required, MaxLength(50)]
        public string ValorMaximo { get; set; }

        public decimal EdadMinimaAnios { get; set; }
        public decimal EdadMaximaAnios { get; set; }
        public char Sexo { get; set; }

        public string Unidad { get; set; }
        public string Interpretacion { get; set; }
    }
}


