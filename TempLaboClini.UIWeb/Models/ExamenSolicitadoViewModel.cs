using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TempLaboClini.UIWeb.Models
{
    // ViewModels
    public class ExamenSolicitadoViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "La solicitud de examen es requerida")]
        [Display(Name = "Solicitud de Examen")]
        public long SolicitudExamenId { get; set; }

        [Required(ErrorMessage = "El examen es requerido")]
        [Display(Name = "Examen")]
        public long ExamenId { get; set; }

        [Required(ErrorMessage = "El estado de la muestra es requerido")]
        [Display(Name = "Estado de la Muestra")]
        [StringLength(50, ErrorMessage = "El estado de la muestra no debe exceder los 50 caracteres")]
        public string EstadoMuestra { get; set; }

        [Display(Name = "Resultado del Examen")]
        [DataType(DataType.MultilineText)]
        public string ResultadoExamen { get; set; }

        [Display(Name = "Personal de Laboratorio")]
        public long? PersonalLaboratorioId { get; set; }

        [Display(Name = "Fecha de Resultado")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? FechaResultado { get; set; }

        [Display(Name = "Nombre del Examen")]
        public string NombreExamen { get; set; }

        [Display(Name = "Estado")]
        public string ActualizarEstado { get; set; }

        // Propiedades para la UI
        public SelectList PersonalLaboratorio { get; set; }
        public SelectList Examenes { get; set; }
        public List<ResultadoViewModel> Resultados { get; set; }

        // Estados de muestra predefinidos para dropdown
        public SelectList EstadosMuestra => new SelectList(new[]
        {
        "Pendiente",
        "Recibida",
        "En Proceso",
        "Analizada",
        "Rechazada"
    });

        public ExamenSolicitadoViewModel()
        {
            Resultados = new List<ResultadoViewModel>();
        }
    }
}