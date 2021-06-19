using System;
using Dominio;

namespace Aplicacion.Boletas
{
    public class ItemBoletaDto
    {
        public Guid ItemBoletaId {get;set;}
        public int Cantidad {get;set;}
        public Producto Producto {get;set;}
        

    }
}