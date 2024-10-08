namespace TempLaboClini.Domain.Entities
{
    public class Examen : BaseEntity
    {
        public long AreaId { get; set; }
        public string CodigoExamen { get; set; }
        public string NombreExamen { get; set; }
        public string SignificanciaClinica { get; set; }
        public decimal PrecioExamen { get; set; }
        public string CodigoCUPS { get; set; }
        public Area Area { get; set; }
        public ICollection<ExamenMuestra> ExamenesMuestras { get; set; }
        public ICollection<Prueba> Pruebas { get; set; }
        public ICollection<ExamenSolicitado> ExamenesSolicitados { get; set; }
    }
}