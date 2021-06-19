using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Categoria
    {
        public Guid CategoriaId{get;set;}
        public string Nombre{get;set;} 
        public string Descripcion{get;set;} 
        public ICollection<Producto> ProductoLista {get;set;}
    }
}
