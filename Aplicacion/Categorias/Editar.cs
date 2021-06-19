using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ErrorHandler;
using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Categorias
{
    public class Editar
    {
        public class Ejecuta : IRequest{
            public Guid? CategoriaId {get;set;}
            public string Nombre {get;set;}
            public string Descripcion {get;set;}
        }

        public class EjecutaValidator : AbstractValidator<Ejecuta>{
            public EjecutaValidator(){
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x =>x.Descripcion).NotEmpty();
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
                var categoria = await _context.Categoria.FindAsync(request.CategoriaId);
                if(categoria == null){
                    throw new ExceptionHandler(HttpStatusCode.NotFound, new {doctor = "No se encontro categoria a editar"});
                }

                categoria.Nombre = request.Nombre ?? categoria.Nombre;
                categoria.Descripcion = request.Descripcion ?? categoria.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo completar la edicion");

            }
        }
    }
}