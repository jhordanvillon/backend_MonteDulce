using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Boletas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BoletaController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<BoletaDto>>> GetCategorias(){
            return await Mediator.Send(new Consulta.ListaBoleta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BoletaDto>> GetCategoriaId(Guid id){
            return await Mediator.Send(new ConsultaId.BoletaUnica{Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> InsertarBoleta(Nuevo.Ejecuta parametros){
            return await Mediator.Send(parametros);
        }
    }
}