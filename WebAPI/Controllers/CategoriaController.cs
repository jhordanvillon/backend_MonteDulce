using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Categorias;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CategoriaController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetCategorias(){
            return await Mediator.Send(new Consulta.ListaCategoria());
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> InsertarCategoria(Nuevo.Ejecuta parametros){

            return await Mediator.Send(parametros);
        }
    }
}