
namespace TempLaboClini.Application.DTOs
{
    public class ExamenSolicitadoDTO
    {
        public long Id { get; set; }
        public long SolicitudExamenId { get; set; }
        public long ExamenId { get; set; }
        public string EstadoMuestra { get; set; }
        public string ResultadoExamen { get; set; }
        public long? PersonalLaboratorioId { get; set; }
        public DateTime? FechaResultado { get; set; }
        public string NombreExamen { get; set; }
        public string ActualizarEstado { get; set; }
        public ICollection<ResultadoDTO> Resultados { get; set; }
    }
}
