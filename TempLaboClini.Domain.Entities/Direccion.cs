using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempLaboClini.Domain.Entities

{
    [Table("Direccion")]
    public class Direccion : BaseEntity
    {
        [StringLength(20)]
        public string TipoVia { get; set; } // Carrera, Calle, etc.

        [StringLength(100)]
        public string NombreVia { get; set; }

        public int NumeroPuerta { get; set; }

        [StringLength(20)]
        public string? Bloque { get; set; }

        [StringLength(20)]
        public string? Manzana { get; set; }

        [StringLength(20)]
        public string? Casa { get; set; }

        [StringLength(20)]
        public string? Apartamento { get; set; }

        [StringLength(50)]
        public string? Edificio { get; set; }

        [StringLength(20)]
        public string? Piso { get; set; }

        [StringLength(40)]
        public string Ciudad { get; set; }

        [StringLength(100)]
        public string Pais { get; set; }

        [StringLength(100)]
        public string Departamento { get; set; }

        [StringLength(10)]
        public string? CodigoPostal { get; set; }

        [StringLength(80)]
        public string? Telefono { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        // Relaciones (usar virtual para lazy loading si es necesario)
        public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
        public virtual ICollection<Aseguradora> Aseguradoras { get; set; } = new List<Aseguradora>();

        //// Constructor sin parámetros (obligatorio para EF)
        //public Direccion() { }

        //// Constructor parametrizado
        //public Direccion(
        //    string tipoVia,
        //    string nombreVia,
        //    int numeroPuerta,
        //    string? bloque = null,
        //    string? manzana = null,
        //    string? casa = null,
        //    string? apartamento = null,
        //    string ciudad = "",
        //    string departamento = "",
        //    string? codigoPostal = null // Usar null en lugar de ""
        //)
        //{
        //    TipoVia = tipoVia;
        //    NombreVia = nombreVia;
        //    NumeroPuerta = numeroPuerta;
        //    Bloque = bloque;
        //    Manzana = manzana;
        //    Casa = casa;
        //    Apartamento = apartamento;
        //    Ciudad = ciudad;
        //    Departamento = departamento; // Nombre de parámetro corregido
        //    CodigoPostal = codigoPostal;
        //}

        //public override string ToString()
        //{
        //    return $"{TipoVia} {NombreVia} {NumeroPuerta}, {Bloque ?? ""}, {Manzana ?? ""}, {Casa ?? ""}, {Apartamento ?? ""}, {Ciudad}, {Departamento}, {CodigoPostal}";
        //}
    }
}
