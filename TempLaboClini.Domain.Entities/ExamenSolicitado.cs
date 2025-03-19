namespace TempLaboClini.Domain.Entities
{

    public class ExamenSolicitado : BaseEntity
    {
        // Claves foráneas
        public long SolicitudExamenId { get; set; }
        public long ExamenId { get; set; }
        public long? PersonalLaboratorioId { get; set; } // Puede ser nulo si aún no ha sido asignado

        // Propiedades adicionales
        public string EstadoMuestra { get; set; } // Ejemplo: "Pendiente", "Procesada"
        public string ResultadoExamen { get; set; } // Almacena el resultado del examen
        public DateTime? FechaResultado { get; set; } // Fecha opcional cuando se obtiene el resultado

        // Relaciones de navegación
        public SolicitudExamen SolicitudExamen { get; set; }
        public Examen Examen { get; set; }
        public PersonalLaboratorio PersonalLaboratorio { get; set; }

        // Relación uno a muchos con Resultado
        public ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();

        // Relación uno a muchos con ExamenesMuestras
        public ICollection<ExamenMuestra> ExamenesMuestras { get; set; }
    }


}