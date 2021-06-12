using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Productos;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}