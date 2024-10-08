namespace TempLaboClini.Domain.Entities
{
    public class Muestra : BaseEntity 
    {   
        public string NombreMuestra { get; set; }
        public ICollection<ExamenMuestra> ExamenesMuestras { get; set; }
    }
}

