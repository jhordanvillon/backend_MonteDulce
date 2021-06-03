using System;

namespace Dominio
{
    public class ItemBoleta
    {
        public Guid BoletaId {get;set;}
        public Boleta Boleta {get;set;}
        public Guid ProductoId{get;set;}
        public Producto Producto { get; set; }
        public int Cantidad{get;set;}
    }
}