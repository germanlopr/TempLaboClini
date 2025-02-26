using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempLaboClini.Application.DTOs
{
    public class FacturaDTO
    {
        public long Id { get; set; }
        public string NroFactura { get; set; }
        public decimal Monto { get; set; }
        public long SolicitudExamenId { get; set; }
        public DateTime FechaEmision { get; set; }
    }
}
