using System.ComponentModel.DataAnnotations;

namespace TempLaboClini.UIWeb.Models
{
    public class FacturaViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "El número de factura es requerido")]
        [Display(Name = "Número de Factura")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El número de factura debe tener entre 3 y 20 caracteres")]
        public string NroFactura { get; set; }

        [Required(ErrorMessage = "El monto es requerido")]
        [Display(Name = "Monto")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "La solicitud de examen es requerida")]
        [Display(Name = "Solicitud de Examen")]
        public long SolicitudExamenId { get; set; }

        [Display(Name = "Fecha de Emisión")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FechaEmision { get; set; }

        // Propiedades adicionales para la UI
        public string NombrePaciente { get; set; }
        public string NumeroSolicitud { get; set; }

        public FacturaViewModel()
        {
            FechaEmision = DateTime.Now;
        }
    }
}