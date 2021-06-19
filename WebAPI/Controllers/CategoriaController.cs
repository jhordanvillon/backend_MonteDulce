using System;
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
        public async Task<ActionResult<List<CategoriaDto>>> GetCategorias(){
            return await Mediator.Send(new Consulta.ListaCategoria());
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> InsertarCategoria(Nuevo.Ejecuta parametros){
            return await Mediator.Send(parametros);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id,Editar.Ejecuta data){
            data.CategoriaId = id;
            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
            return await Mediator.Send(new Eliminar.Ejecuta{Id = id});
        }

    }
}