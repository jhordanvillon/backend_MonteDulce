using System;

namespace Aplicacion.Categorias
{
    public class ProductoDto
    {
        public Guid ProductoId{get;set;} 
        public string Nombre{get;set;} 
        public string Descripcion{get;set;} 
        public string ImgLink {get;set;}
        public string ImgId {get;set;}
        public decimal Precio {get;set;}
        public int Stock {get;set;}
        public Guid CategoriaId {get;set;}
    }
}