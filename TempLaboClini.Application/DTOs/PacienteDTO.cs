
namespace TempLaboClini.Application.DTOs
{
    public class PacienteDTO
    {
        public string NroIdentificacion { get; internal set; }
        public string Nombre { get; internal set; }
        public string PrimerApellido { get; internal set; }
        public string SegundoApellido { get; internal set; }
        public char Sexo { get; internal set; }
        public string HistoriaClinica { get; internal set; }
        public DateTime FechaNacimiento { get; internal set; }
        public string DireccionCompleta { get; internal set; }
        public string Ciudad { get; internal set; }
        public string Departamento { get; internal set; }
        public string Pais { get; internal set; }
        public string Telefono { get; internal set; }
        public string CodigoZonaPostal { get; internal set; }
    }
}