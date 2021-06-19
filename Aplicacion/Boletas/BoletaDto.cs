using System;
using System.Collections.Generic;

namespace Aplicacion.Boletas
{
    public class BoletaDto
    {
        public Guid BoletaId {get;set;}
        public List<ItemBoletaDto> Items {get;set;}
        public DateTime? FechaCreacion {get;set;}
    }
}