using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Productos
{
    public class Nuevo
    {
        public class Ejecuta : IRequest{
            public Guid? CursoId {get;set;}
            public string Nombre {get;set;}
            public string Descripcion {get;set;}
            public string ImgLink {get;set;}
            public string ImgId {get;set;}
            public decimal Precio {get;set;}
        }

        public class EjecutaValidator : AbstractValidator<Ejecuta>{
            public EjecutaValidator(){
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Precio).NotEmpty();
            }
        }

        public class Hanlder : IRequestHandler<Ejecuta>
        {
            private readonly TiendaContext _context;
            public Hanlder(TiendaContext context){
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var producto = new Producto{
                    ProductoId = Guid.NewGuid(),
                    Descripcion = request.Descripcion,
                    Nombre = request.Nombre,
                    ImgLink = request.ImgLink,
                    ImgId = request.ImgId,
                    Precio = request.Precio
                };

                _context.Producto.Add(producto);
                var resultado = await _context.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar");
            }
        }
    }
}