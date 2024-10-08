using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLaboClini.Application.DTOs;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Repositories;

namespace TempLaboClini.Application.Interfaces
{
    public interface IServicioExamenService
    {
        void RegistrarPaciente(PacienteDTO pacienteDTO);

        void CrearSolicitudExamen(SolicitudExamenDTO solicitudDTO);
       
    }
}
