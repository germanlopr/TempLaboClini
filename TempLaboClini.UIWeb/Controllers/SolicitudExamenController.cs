using Microsoft.AspNetCore.Mvc;
using TempLaboClini.Application.DTOs;
using TempLaboClini.Application.Interfaces;

namespace TempLaboClini.UIWeb.Controllers
{
    public class SolicitudExamenController : ControllerBase
    {
        private readonly IServicioExamenService _servicioExamenAppService;

        public SolicitudExamenController(IServicioExamenService servicioExamenAppService)
        {
            _servicioExamenAppService = servicioExamenAppService;
        }

        // POST: api/SolicitudExamen/RegistrarPaciente
        [HttpPost("RegistrarPaciente")]
        public IActionResult RegistrarPaciente([FromBody] PacienteDTO pacienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _servicioExamenAppService.RegistrarPaciente(pacienteDTO);
                return Ok("Paciente registrado exitosamente.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/SolicitudExamen/CrearSolicitudExamen
        [HttpPost("CrearSolicitudExamen")]
        public IActionResult CrearSolicitudExamen([FromBody] SolicitudExamenDTO solicitudExamenDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _servicioExamenAppService.CrearSolicitudExamen(solicitudExamenDTO);
                return Ok("Solicitud de examen creada exitosamente.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
