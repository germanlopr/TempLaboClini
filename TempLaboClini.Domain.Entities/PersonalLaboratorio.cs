using System.ComponentModel.DataAnnotations;

namespace TempLaboClini.Domain.Entities
{

    // Entidad PersonalLaboratorio (Hereda de Persona)
    public class PersonalLaboratorio : Persona
    {
        [Required, MaxLength(20)]
        public string NroRegistro { get; set; }

        [Required, MaxLength(100)]
        public string Cargo { get; set; }

        public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
    }
}