using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class ItemBoleta
    {
        public Guid ItemBoletaId {get;set;}
        public Guid BoletaId {get;set;}
        public Boleta Boleta {get;set;}
        public int Cantidad {get;set;}
        public Guid ProductoId {get;set;}
        public Producto Producto {get;set;}
    }
}