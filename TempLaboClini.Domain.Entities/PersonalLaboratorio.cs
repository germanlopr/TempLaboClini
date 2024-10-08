namespace TempLaboClini.Domain.Entities
{ 
    public class PersonalLaboratorio : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NroRegistro { get; set; }
        public string Clave { get; set; }
        public ICollection<Resultado> Resultados { get; set; }
    }
}