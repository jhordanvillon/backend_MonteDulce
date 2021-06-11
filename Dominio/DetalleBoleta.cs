using System;

namespace Dominio
{
    public class DetalleBoleta
    {
        public Guid ProductoId {get;set;}
        public Producto Producto {get;set;}
        public Guid BoletaId {get;set;}
        public Boleta Boleta;
    }
}