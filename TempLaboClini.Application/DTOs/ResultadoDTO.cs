﻿using TempLaboClini.Domain.Entities;

namespace TempLaboClini.Application.DTOs
{
    public class ResultadoDTO
    {
        public long ExamenSolicitadoId { get; set; }
        public long PersonalLaboratorioId { get; set; }
        public string ResultadoTexto { get; set; }
        public string Observaciones { get; set; }
        public long ValorReferenciaId { get; set; }
        public DateTime FechaResultado { get; set; }
        public ExamenSolicitado ExamenSolicitado { get; set; }
        public PersonalLaboratorio PersonalLaboratorio { get; set; }
        public ValorReferencia ValorReferencia { get; set; }
    }
}