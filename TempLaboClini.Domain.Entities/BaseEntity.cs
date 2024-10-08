namespace TempLaboClini.Domain.Entities
{
    public abstract class BaseEntity 
    {
        public long Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Eliminado { get; set; }
    }
}