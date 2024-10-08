namespace TempLaboClini.Domain.Entities
{
    public class Paciente : BaseEntity
    {
        public string NroIdentificacion { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public char Sexo { get; set; }
        public string HistoriaClinica { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public long DireccionId { get; set; }
        public Direccion Direccion { get; set; }
        public ICollection<SolicitudExamen> SolicitudesExamenes { get; set; }
    }
}