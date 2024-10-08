namespace TempLaboClini.Domain.Entities
{
    public class ExamenSolicitado : BaseEntity
    {
        public ExamenSolicitado(long examenId, string estadoMuestra)
        {
            ExamenId = examenId;
            EstadoMuestra = estadoMuestra;
        }

        public long SolicitudExamenId { get; set; }
        public long ExamenId { get; set; }
        public string EstadoMuestra { get; set; }
        public string ResultadoExamen { get; set; }
        public long? PersonalLaboratorioId { get; set; }
        public DateTime? FechaResultado { get; set; }
        public SolicitudExamen SolicitudExamen { get; set; }
        public Examen Examen { get; set; }
        public ICollection<Resultado> Resultados { get; set; }
        public string ActualizarEstado { get; set; }
    }
}