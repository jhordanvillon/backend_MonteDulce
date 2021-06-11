using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Boleta
    {
        public Guid BoletaId {get;set;}
        [Column(TypeName = "decimal(18,4)")]
        public decimal Igv {get;set;}
        public ICollection<DetalleBoleta> ProductoLink{get;set;}
    }
}