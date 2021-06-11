using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ErrorHandler;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Productos
{
    public class Editar
    {
        public class Ejecuta : IRequest {
            public int ProductoId {get;set;}
            public string Nombre {get;set;}
            public string Descripcion {get;set;}
            public string ImgLink {get;set;}
            public string ImgId {get;set;}
            public decimal? Precio {get;set;}
        }

        public class EjecutaValidator : AbstractValidator<Ejecuta>{
            public EjecutaValidator(){
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Precio).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Ejecuta>
        {
            private readonly TiendaContext _context;
            public Handler(TiendaContext context){
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var producto = await _context.Producto.FindAsync(request.ProductoId);
                if(producto == null){
                    throw new ExceptionHandler(HttpStatusCode.NotFound, new {doctor = "No se encontro doctor a editar"});
                }

                producto.Nombre = request.Nombre ?? producto.Nombre;
                producto.Descripcion = request.Descripcion ?? producto.Descripcion;
                producto.ImgId = request.ImgId ?? producto.ImgId;
                producto.ImgLink = request.ImgId ?? producto.ImgLink;
                producto.Precio = request.Precio ?? producto.Precio;
                
                var resultado = await _context.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo completar la edicion");
            }
        }
    }
}