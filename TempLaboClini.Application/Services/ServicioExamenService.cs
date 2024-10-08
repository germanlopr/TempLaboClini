using TempLaboClini.Application.DTOs;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;
using TempLaboClini.Infrastructure.Repositories;

namespace TempLaboClini.Application.Services
{
    public class ServicioExamenService
    {
        
           private readonly PacienteRepository _pacienteRepository;
           private readonly IRepository<SolicitudExamen> _solicitudExamenRepository;
           private readonly IRepository<Examen> _examenRepository;  
           private readonly IRepository<ExamenSolicitado> _examenSolicitadoRepository;


        public ServicioExamenService(
                        PacienteRepository pacienteRepository,
                        IRepository<SolicitudExamen> solicitudExamenRepository,
                        IRepository<Examen> examenRepository,
                        IRepository<ExamenSolicitado> examenSolicitadoRepository) // Agregado el repositorio de ExamenSolicitado
        {
            _pacienteRepository = pacienteRepository;
            _solicitudExamenRepository = solicitudExamenRepository;
            _examenRepository = examenRepository;
            _examenSolicitadoRepository = examenSolicitadoRepository; // Inyectamos el nuevo repositorio
        }

        public void RegistrarPaciente(PacienteDTO pacienteDTO)
            {
                var pacienteExistente = _pacienteRepository.GetByIdentificacion(pacienteDTO.NroIdentificacion);

                if (pacienteExistente != null)
                {
                    throw new InvalidOperationException("El paciente ya está registrado.");
                }

                var paciente = new Paciente
                {
                    NroIdentificacion = pacienteDTO.NroIdentificacion,
                    Nombre = pacienteDTO.Nombre,
                    PrimerApellido = pacienteDTO.PrimerApellido,
                    SegundoApellido = pacienteDTO.SegundoApellido,
                    Sexo = pacienteDTO.Sexo,
                    FechaNacimiento = pacienteDTO.FechaNacimiento,
                    Direccion = new Direccion
                    {
                        DireccionCompleta = pacienteDTO.DireccionCompleta,
                        Ciudad = pacienteDTO.Ciudad,
                        Departamento = pacienteDTO.Departamento,
                        Pais = pacienteDTO.Pais,
                        Telefono = pacienteDTO.Telefono,
                        CodigoZonaPostal = pacienteDTO.CodigoZonaPostal
                    },
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    Eliminado = false
                };

                _pacienteRepository.Add(paciente);
            }


        public void CrearSolicitudExamen(SolicitudExamenDTO solicitudDTO)
        {
            // Buscar paciente por identificación
            var paciente = _pacienteRepository.GetByIdentificacion(solicitudDTO.PacienteNroIdentificacion);
            if (paciente == null)
            {
                throw new InvalidOperationException("El paciente no está registrado.");
            }

            // Crear entidad SolicitudExamen
            var solicitudExamen = new SolicitudExamen
            {
                PacienteId = paciente.Id,
                AseguradoraId = solicitudDTO.AseguradoraId,
                MedicoId = solicitudDTO.MedicoId,
                NroRegistro = solicitudDTO.NroRegistro,
                IngresoPor = solicitudDTO.IngresoPor,
                FechaSolicitud = DateTime.Now,
                FechaRecepcion = DateTime.Now,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                Eliminado = false,

                // Crear lista de ExamenesSolicitados utilizando el constructor de ExamenSolicitado
                ExamenesSolicitados = solicitudDTO.ExamenesSolicitados
                    .Select(e => new ExamenSolicitado(e.ExamenId, e.EstadoMuestra)
                    {
                        // Inicializar propiedades adicionales después del constructor
                        FechaCreacion = DateTime.Now,
                        FechaModificacion = DateTime.Now,
                        Eliminado = false
                    }).ToList()
            };

            // Agregar la solicitud de examen al repositorio
            _solicitudExamenRepository.Add(solicitudExamen);
        }


        public void RegistrarResultadoExamen(long examenSolicitadoId, ResultadoDTO resultadoDTO)
        {
            // Obtener el examen solicitado por su ID
            var examenSolicitado = _examenSolicitadoRepository.GetById(examenSolicitadoId);
            if (examenSolicitado == null)
            {
                throw new InvalidOperationException("El examen solicitado no existe.");
            }

            // Crear la entidad Resultado con la información proporcionada en el DTO
            var resultado = new Resultado
            {
                ExamenSolicitadoId = examenSolicitado.Id,
                PersonalLaboratorioId = resultadoDTO.PersonalLaboratorioId,
                ResultadoTexto = resultadoDTO.ResultadoTexto,
                Observaciones = resultadoDTO.Observaciones,
                ValorReferenciaId = resultadoDTO.ValorReferenciaId,
                FechaResultado = DateTime.Now,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                Eliminado = false
            };

            // Asegurarse de que la lista de Resultados no sea nula
            if (examenSolicitado.Resultados == null)
            {
                examenSolicitado.Resultados = new List<Resultado>();
            }

            // Agregar el nuevo resultado a la colección de Resultados
            examenSolicitado.Resultados.Add(resultado);

            // Actualizar la entidad ExamenSolicitado en el repositorio
            _examenSolicitadoRepository.Update(examenSolicitado);
        }


    }

}
