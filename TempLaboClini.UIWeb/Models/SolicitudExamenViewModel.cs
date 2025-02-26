using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TempLaboClini.UIWeb.Models
{
    public class SolicitudExamenViewModel
    {
        [Required(ErrorMessage = "El ID del paciente es requerido")]
        [Display(Name = "ID del Paciente")]
        public long PacienteId { get; set; }

        [Required(ErrorMessage = "El número de identificación del paciente es requerido")]
        [Display(Name = "Número de Identificación")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "El número de identificación debe tener entre 5 y 20 caracteres")]
        public string PacienteNroIdentificacion { get; set; }

        [Required(ErrorMessage = "La aseguradora es requerida")]
        [Display(Name = "Aseguradora")]
        public long AseguradoraId { get; set; }

        [Required(ErrorMessage = "El médico es requerido")]
        [Display(Name = "Médico")]
        public long MedicoId { get; set; }

        [Required(ErrorMessage = "El número de registro es requerido")]
        [Display(Name = "Número de Registro")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de registro debe ser mayor a 0")]
        public int NroRegistro { get; set; }

        [Required(ErrorMessage = "El campo Ingreso Por es requerido")]
        [Display(Name = "Ingresado Por")]
        [StringLength(50, ErrorMessage = "El campo Ingreso Por no debe exceder los 50 caracteres")]
        public string IngresoPor { get; set; }

        [Required(ErrorMessage = "La fecha de solicitud es requerida")]
        [Display(Name = "Fecha de Solicitud")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FechaSolicitud { get; set; }

        [Required(ErrorMessage = "La fecha de recepción es requerida")]
        [Display(Name = "Fecha de Recepción")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FechaRecepcion { get; set; }

        // Propiedades de navegación para mostrar información en las vistas
        public string NombrePaciente { get; set; }
        public string NombreAseguradora { get; set; }
        public string NombreMedico { get; set; }

        // Listas para los dropdowns en las vistas
        public SelectList Pacientes { get; set; }
        public SelectList Aseguradoras { get; set; }
        public SelectList Medicos { get; set; }

        // Colecciones para mostrar los exámenes y facturas
        public List<ExamenSolicitadoViewModel> ExamenesSolicitados { get; set; }
        public List<FacturaViewModel> Facturas { get; set; }

        public SolicitudExamenViewModel()
        {
            ExamenesSolicitados = new List<ExamenSolicitadoViewModel>();
            Facturas = new List<FacturaViewModel>();
            FechaSolicitud = DateTime.Now;
            FechaRecepcion = DateTime.Now;
        }
    }
}
