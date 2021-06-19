using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Categorias
{
    public class Nuevo
    {
        public class Ejecuta : IRequest{
            public string Nombre {get;set;}
            public string Descripcion {get;set;}
        }

        public class EjecutaValidation : AbstractValidator<Ejecuta>{
            public EjecutaValidation(){
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
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
                var categoria = new Categoria{
                    CategoriaId = Guid.NewGuid(),
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion
                };

                _context.Categoria.Add(categoria);
                var resultado = await _context.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar");
            }
        }
    }
}