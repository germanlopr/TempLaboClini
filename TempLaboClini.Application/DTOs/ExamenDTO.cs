
using TempLaboClini.Domain.Entities;

namespace TempLaboClini.Application.DTOs
{
    public class ExamenDTO
    {
        public long AseguradoraId { get; internal set; }
        public long MedicoId { get; internal set; }
        public string IngresoPor { get; internal set; }
        public IEnumerable<Examen> ExamenesId { get; internal set; }
    }
}