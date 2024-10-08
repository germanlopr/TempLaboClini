namespace TempLaboClini.Domain.Entities
{
    public class Area : BaseEntity
    {
        public string CodigoArea { get; set; }
        public string NombreArea { get; set; }
        public ICollection<Examen> Examenes { get; set; }
    }
}
