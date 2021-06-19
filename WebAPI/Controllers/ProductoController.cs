using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Productos;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistencia.DapperConexion.Producto;

namespace WebAPI.Controllers
{
    public class ProductoController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos(){
            return await Mediator.Send(new Consulta.ListProductos());
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> InsertarProducto(Nuevo.Ejecuta parametros){

            return await Mediator.Send(parametros);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id,Editar.Ejecuta data){
            data.ProductoId = id;
            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
            return await Mediator.Send(new Eliminar.Ejecuta{Id = id});
        }
        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<ProductoModel>>> GetProductosPorNombre(string nombre){
            return await Mediator.Send(new ConsultaNombre.Lista{nombre = nombre});
        }
    }
}