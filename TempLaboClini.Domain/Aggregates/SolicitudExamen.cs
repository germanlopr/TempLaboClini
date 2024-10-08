using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Events;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Aggregates
{
    public class SolicitudExamen : AggregateRoot
    {
        public long PacienteId { get; private set; }
        public long AseguradoraId { get; private set; }
        public long MedicoId { get; private set; }
        public int NroRegistro { get; private set; }
        public string IngresoPor { get; private set; }
        public DateTime FechaSolicitud { get; private set; }
        public DateTime FechaRecepcion { get; private set; }
        public Paciente Paciente { get; private set; }
        public Aseguradora Aseguradora { get; private set; }
        public Medico Medico { get; private set; }
        public ICollection<ExamenSolicitado> ExamenesSolicitados { get; private set; }
        public ICollection<Factura> Facturas { get; private set; }
        public bool Pagada { get; private set; }

        // Constructor de la Solicitud de Examen
        public SolicitudExamen(long pacienteId, long aseguradoraId, long medicoId, string ingresoPor)
        {
            PacienteId = pacienteId;
            AseguradoraId = aseguradoraId;
            MedicoId = medicoId;
            IngresoPor = ingresoPor;
            ExamenesSolicitados = new List<ExamenSolicitado>();
            Facturas = new List<Factura>();
            FechaSolicitud = DateTime.Now;
            Pagada = false;

            // Disparar el evento de dominio "SolicitudExamenCreada"
            DispararEvento(new SolicitudExamenCreada(this));
        }

        // Método para recibir las muestras de la solicitud
        public void RecibirMuestra()
        {
            FechaRecepcion = DateTime.Now;

            // Disparar el evento "MuestraRecibida"
            DispararEvento(new MuestraRecibida(this));
        }

        // Método para agregar un examen solicitado
        public void AgregarExamenSolicitado(long examenId, string estadoMuestra)
        {
            var examenSolicitado = new ExamenSolicitado(examenId, estadoMuestra);
            ExamenesSolicitados.Add(examenSolicitado);

            // Disparar el evento "ExamenSolicitadoAgregado"
            DispararEvento(new ExamenSolicitadoAgregado(this, examenId));
        }

        // Método para actualizar el estado de un examen solicitado (por ejemplo, cuando se recibe el resultado)
        public void ActualizarEstadoExamenSolicitado(long examenSolicitadoId, string nuevoEstado)
        {
            var examenSolicitado = ExamenesSolicitados.FirstOrDefault(e => e.Id == examenSolicitadoId);
            if (examenSolicitado != null)
            {
                examenSolicitado.ActualizarEstado = nuevoEstado;
                //TODO:Revisar este evento, y el metodo completo en vez de actualizar estado finalizar
                if (examenSolicitado.ActualizarEstado != null && examenSolicitado.ActualizarEstado == "Finalizado")
                    DispararEvento(new ExamenFinalizado(examenSolicitadoId,DateTime.Now));

                // Disparar el evento "EstadoExamenActualizado"
                DispararEvento(new EstadoExamenActualizado(this, examenSolicitadoId, nuevoEstado));
            }
        }

        // Método para generar la factura
        public void GenerarFactura(decimal monto)
        {
            var factura = new Factura(monto);
            Facturas.Add(factura);

            // Disparar el evento "FacturaGenerada"
            DispararEvento(new FacturaGenerada(this, factura.NroFactura));
        }

        // Método para marcar la solicitud como pagada
        public void MarcarComoPagada()
        {
            //TODO:Colocar Logica para que indique si lleva a factura por pagar
            //pagada, etc.
            
            Pagada = true;

            // Disparar el evento "SolicitudPagada"
            DispararEvento(new SolicitudPagada(this));
        }

        // Método para disparar eventos de dominio
        private void DispararEvento(IDomainEvent domainEvent)
        {
            // Implementar la lógica para notificar el evento (puede ser a través de un EventDispatcher, Mediator, etc.)
            AddDomainEvent(domainEvent);
        }
    }

}
