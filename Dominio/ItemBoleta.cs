using System;

namespace Dominio
{
    public class ItemBoleta
    {
        public Guid ItemBoletaId {get;set;}
        public Guid ProductoId{get;set;}
        public int Cantidad{get;set;}
    }
}