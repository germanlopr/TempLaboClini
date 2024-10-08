namespace TempLaboClini.Domain.Entities
{
    public class Medico : BaseEntity
    {
        public string CodigoMedico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public ICollection<SolicitudExamen> SolicitudesExamenes { get; set; }
    }
}