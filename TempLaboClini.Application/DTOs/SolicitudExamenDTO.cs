using TempLaboClini.Domain.Entities;

namespace TempLaboClini.Application.DTOs
{
    public class SolicitudExamenDTO
    {
        public long PacienteId { get; set; }
        public string PacienteNroIdentificacion { get; set; }
        public long AseguradoraId { get; set; }
        public long MedicoId { get; set; }
        public int NroRegistro { get; set; }
        public string IngresoPor { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public Paciente Paciente { get; set; }
        public Aseguradora Aseguradora { get; set; }
        public Medico Medico { get; set; }
        public ICollection<ExamenSolicitado> ExamenesSolicitados { get; set; }
        public ICollection<Factura> Facturas { get; set; }
    }
}