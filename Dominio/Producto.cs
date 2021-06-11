using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Producto
    {
        public Guid ProductoId{get;set;} 
        public string Nombre{get;set;} 
        public string Descripcion{get;set;} 
        public string ImgLink {get;set;}
        public string ImgId {get;set;}
        [Column(TypeName = "decimal(18,4)")]
        public decimal Precio {get;set;}
        public ICollection<DetalleBoleta> BoletaLink{get;set;}

        public Guid CategoriaId {get;set;}
        public Categoria Categoria {get;set;}
    }
}