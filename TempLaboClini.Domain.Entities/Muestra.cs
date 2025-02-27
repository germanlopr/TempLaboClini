using System.ComponentModel.DataAnnotations;

namespace TempLaboClini.Domain.Entities
{
    public class Muestra : BaseEntity 
    {
        [Required, MaxLength(40)]
        public string NombreMuestra { get; set; }

        // Relación con ExamenMuestra
        public ICollection<ExamenMuestra> ExamenesMuestras { get; set; } = new List<ExamenMuestra>();

    }
}

