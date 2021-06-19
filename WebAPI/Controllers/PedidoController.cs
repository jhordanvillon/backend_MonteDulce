using System.Threading.Tasks;
using Aplicacion.Pedidos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class PedidoController : MiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> InsertarPedido(Nuevo.Ejecuta parametros){
            return await Mediator.Send(parametros);
        }
    }
}