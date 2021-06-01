using System;

namespace Dominio
{
    public class Producto
    {
       public Guid ProductoId{get;set;} 
       public string Nombre{get;set;} 
      
        public Guid CategoriaId{get;set;} 
        public decimal Precio{get;set;}
        public decimal Igv{get;set;}
        public int Cantidad{get;set;}
        public string Descripcion{get;set;} 
    }
}