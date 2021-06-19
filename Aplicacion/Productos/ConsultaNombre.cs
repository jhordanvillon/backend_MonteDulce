using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ErrorHandler;
using MediatR;
using Persistencia.DapperConexion.Producto;

namespace Aplicacion.Productos
{
    public class ConsultaNombre
    {
        public class Lista : IRequest<List<ProductoModel>>{
            public string nombre {get;set;}
        }
        public class Handler : IRequestHandler<Lista, List<ProductoModel>>
        {
            private readonly IProducto _productoRepositorio;
            public Handler(IProducto productoRepositorio){
                _productoRepositorio = productoRepositorio;
            }
            public async Task<List<ProductoModel>> Handle(Lista request, CancellationToken cancellationToken)
            {
                var productos = await _productoRepositorio.ObtenerPorNombre(request.nombre);
                if(productos == null){
                    throw new ExceptionHandler(HttpStatusCode.NotFound,new {mensaje = "No se encontro producto"});
                }
                return productos.ToList();
            }
        }
    }
}