﻿
namespace TempLaboClini.Domain.Entities
{
    public class Factura : BaseEntity
    {
        public string NroFactura { get; set; }
        public decimal Monto { get; set; }
        public long SolicitudExamenId { get; set; }
        public SolicitudExamen SolicitudExamen { get; set; }
    }

}
