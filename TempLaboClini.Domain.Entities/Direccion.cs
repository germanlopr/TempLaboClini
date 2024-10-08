using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempLaboClini.Domain.Entities
{
    [Table("Direccion")]
    public class Direccion : BaseEntity
    {

        [StringLength(30)]
        public string DireccionCompleta { get; set; }

        [StringLength(40)]
        public string Ciudad { get; set; }

        [StringLength(100)]
        public string Pais { get; set; }

        [StringLength(100)]
        public string Departamento { get; set; }

        [StringLength(10)]
        public string CodigoZonaPostal { get; set; }

        [StringLength(80)]
        public string Telefono { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

    }
}
