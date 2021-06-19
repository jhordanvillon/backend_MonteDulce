using System;
using System.Collections.Generic;

namespace Aplicacion.Categorias
{
    public class CategoriaDto
    {
        public Guid CategoriaId {get;set;}
        public string Nombre{get;set;} 
        public string Descripcion{get;set;} 
        public ICollection<ProductoDto> Productos {get;set;}
        
    }
}