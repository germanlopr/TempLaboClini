using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TempLaboClini.Domain.Entities
{
    public class Resultado : BaseEntity
    {

        [Required]
        public long ExamenSolicitadoId { get; set; }

        [ForeignKey("ExamenSolicitadoId")]
        public virtual ExamenSolicitado ExamenSolicitado { get; set; }

        [Required]
        public long PersonalLaboratorioId { get; set; }

        [ForeignKey("PersonalLaboratorioId")]
        public virtual PersonalLaboratorio PersonalLaboratorio { get; set; }

        [Required, MaxLength(50)]
        public string ResultadoValor { get; set; }

        [Required, MaxLength(250)]
        public string ResultadoTexto { get; set; }

        [Required, MaxLength(250)]
        public string Observaciones { get; set; }

        [Required]
        public long ValorReferenciaId { get; set; }

        [ForeignKey("ValorReferenciaId")]
        public virtual ValorReferencia ValorReferencia { get; set; }

        public DateTime FechaResultado { get; set; }
    }
}