using Microsoft.AspNetCore.Mvc;
using TempLaboClini.Application.DTOs;
using TempLaboClini.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using TempLaboClini.UIWeb.Models;

namespace TempLaboClini.UIWeb.Controllers
{


    public class SolicitudExamenController : Controller
    {
        private readonly IServicioExamenService _servicioExamenService;

        public SolicitudExamenController(IServicioExamenService servicioExamenService)
        {
            _servicioExamenService = servicioExamenService;
        }

        // GET: ServiceOrder
        public IActionResult Index()
        {
            var solicitudes = _servicioExamenService.ObtenerTodasLasSolicitudes();
            var viewModelList = solicitudes.Select(s => new SolicitudExamenViewModel
            {
                PacienteId = s.PacienteId,
                PacienteNroIdentificacion = s.PacienteNroIdentificacion,
                AseguradoraId = s.AseguradoraId,
                MedicoId = s.MedicoId,
                NroRegistro = s.NroRegistro,
                IngresoPor = s.IngresoPor,
                FechaSolicitud = s.FechaSolicitud,
                FechaRecepcion = s.FechaRecepcion,
                NombrePaciente = s.Paciente.Nombre,
                NombreAseguradora = s.Aseguradora.NombreAseguradora,
                NombreMedico = s.Medico.Nombre
            }).ToList();

            return View(viewModelList);
        }

        // GET: ServiceOrder/Details/5
        public IActionResult Details(long id)
        {
            var solicitud = _servicioExamenService.ObtenerSolicitudPorId(id);
            if (solicitud == null)
            {
                return NotFound();
            }

            var viewModel = new SolicitudExamenViewModel
            {
                PacienteId = solicitud.PacienteId,
                PacienteNroIdentificacion = solicitud.PacienteNroIdentificacion,
                AseguradoraId = solicitud.AseguradoraId,
                MedicoId = solicitud.MedicoId,
                NroRegistro = solicitud.NroRegistro,
                IngresoPor = solicitud.IngresoPor,
                FechaSolicitud = solicitud.FechaSolicitud,
                FechaRecepcion = solicitud.FechaRecepcion,
                NombrePaciente = solicitud.Paciente.Nombre,
                NombreAseguradora = solicitud.Aseguradora.NombreAseguradora,
                NombreMedico = solicitud.Medico.Nombre,
                ExamenesSolicitados = solicitud.ExamenesSolicitados.Select(e => new ExamenSolicitadoViewModel
                {
                    ExamenId = e.ExamenId,
                    Id = e.Id
                }).ToList(),
                Facturas = solicitud.Facturas.Select(f => new FacturaViewModel
                {
                    Id = f.Id,
                    Monto = f.Monto
                }).ToList()
            };

            return View(viewModel);
        }

        // GET: ServiceOrder/Create
        public IActionResult Create()
        {
            var viewModel = new SolicitudExamenViewModel
            {
                Pacientes = new SelectList(_servicioExamenService.ObtenerPacientes(), "Id", "Nombre"),
                Aseguradoras = new SelectList(_servicioExamenService.ObtenerAseguradoras(), "Id", "Nombre"),
                Medicos = new SelectList(_servicioExamenService.ObtenerMedicos(), "Id", "Nombre")
            };

            return View(viewModel);
        }

        // POST: ServiceOrder/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(SolicitudExamenViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var solicitudDTO = new SolicitudExamenDTO
        //        {
        //            PacienteId = viewModel.PacienteId,
        //            PacienteNroIdentificacion = viewModel.PacienteNroIdentificacion,
        //            AseguradoraId = viewModel.AseguradoraId,
        //            MedicoId = viewModel.MedicoId,
        //            NroRegistro = viewModel.NroRegistro,
        //            IngresoPor = viewModel.IngresoPor,
        //            FechaSolicitud = viewModel.FechaSolicitud,
        //            FechaRecepcion = viewModel.FechaRecepcion
        //        };

        //        _servicioExamenService.CrearSolicitudExamen(solicitudDTO);
        //        return RedirectToAction(nameof(Index));
        //    }

        //    viewModel.Pacientes = new SelectList(_servicioExamenService.ObtenerPacientes(), "Id", "Nombre");
        //    viewModel.Aseguradoras = new SelectList(_servicioExamenService.ObtenerAseguradoras(), "Id", "Nombre");
        //    viewModel.Medicos = new SelectList(_servicioExamenService.ObtenerMedicos(), "Id", "Nombre");

        //    return View(viewModel);
        //}

        // GET: ServiceOrder/Edit/5
        public IActionResult Edit(long id)
        {
            var solicitud = _servicioExamenService.ObtenerSolicitudPorId(id);
            if (solicitud == null)
            {
                return NotFound();
            }

            var viewModel = new SolicitudExamenViewModel
            {
                PacienteId = solicitud.PacienteId,
                PacienteNroIdentificacion = solicitud.PacienteNroIdentificacion,
                AseguradoraId = solicitud.AseguradoraId,
                MedicoId = solicitud.MedicoId,
                NroRegistro = solicitud.NroRegistro,
                IngresoPor = solicitud.IngresoPor,
                FechaSolicitud = solicitud.FechaSolicitud,
                FechaRecepcion = solicitud.FechaRecepcion,
                Pacientes = new SelectList(_servicioExamenService.ObtenerPacientes(), "Id", "Nombre"),
                Aseguradoras = new SelectList(_servicioExamenService.ObtenerAseguradoras(), "Id", "Nombre"),
                Medicos = new SelectList(_servicioExamenService.ObtenerMedicos(), "Id", "Nombre")
            };

            return View(viewModel);
        }

        // POST: ServiceOrder/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, SolicitudExamenViewModel viewModel)
        {
            if (id != viewModel.NroRegistro)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var solicitudDTO = new SolicitudExamenDTO
                {
                    PacienteId = viewModel.PacienteId,
                    PacienteNroIdentificacion = viewModel.PacienteNroIdentificacion,
                    AseguradoraId = viewModel.AseguradoraId,
                    MedicoId = viewModel.MedicoId,
                    NroRegistro = viewModel.NroRegistro,
                    IngresoPor = viewModel.IngresoPor,
                    FechaSolicitud = viewModel.FechaSolicitud,
                    FechaRecepcion = viewModel.FechaRecepcion
                };

                _servicioExamenService.ActualizarSolicitud(solicitudDTO);
                return RedirectToAction(nameof(Index));
            }

            viewModel.Pacientes = new SelectList(_servicioExamenService.ObtenerPacientes(), "Id", "Nombre");
            viewModel.Aseguradoras = new SelectList(_servicioExamenService.ObtenerAseguradoras(), "Id", "Nombre");
            viewModel.Medicos = new SelectList(_servicioExamenService.ObtenerMedicos(), "Id", "Nombre");

            return View(viewModel);
        }
    }
}
