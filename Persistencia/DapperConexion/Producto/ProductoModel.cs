using System;

namespace Persistencia.DapperConexion.Producto
{
    public class ProductoModel
    {
        public Guid ProductoId{get;set;} 
        public string Nombre{get;set;} 
        public string Descripcion{get;set;} 
        public string ImgLink {get;set;}
        public string ImgId {get;set;}
        public decimal Precio {get;set;}
        public Guid CategoriaId {get;set;}
    }
}