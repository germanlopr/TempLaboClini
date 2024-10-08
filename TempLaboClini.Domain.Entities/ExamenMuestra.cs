namespace TempLaboClini.Domain.Entities
{
    public class ExamenMuestra
    {
        public long ExamenId { get; set; }
        public long MuestraId { get; set; }
        public Examen Examen { get; set; }
        public Muestra Muestra { get; set; }
    }
}