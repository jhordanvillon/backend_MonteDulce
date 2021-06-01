using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Boleta
    {
            public Guid BoletaId{get;set;} 
           public Guid UsuarioId{get;set;} 
           public ICollection<ItemBoleta> Itemlink{get;set;}
      
            public DateTime FechaCreacion {get;set;}

    }
}