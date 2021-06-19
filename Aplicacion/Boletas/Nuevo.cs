using System;
using System.Collections.Generic;
using System.Threading;
using Dominio;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.Boletas
{
    public class Nuevo
    {
        public class Ejecuta : IRequest{
            public List<ItemBoletaRequest> Items {get;set;}
        }

        public class Handler : IRequestHandler<Ejecuta>
        {
            private readonly TiendaContext _context;
            public Handler(TiendaContext context){
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //crear boleta
                Guid _boletaId = Guid.NewGuid();
                var boleta = new Dominio.Boleta{
                    BoletaId = _boletaId,
                    FechaCreacion = DateTime.UtcNow
                };
                _context.Boleta.Add(boleta);

                //guardar items de boleta
                if(request.Items != null){
                    foreach (var item in request.Items)
                    {
                        var itemBoleta = new ItemBoleta{
                            ItemBoletaId = Guid.NewGuid(),
                            BoletaId = _boletaId,
                            ProductoId = item.ProductoId,
                            Cantidad = item.Cantidad
                        };
                        _context.ItemBoleta.Add(itemBoleta);
                    }
                }

                var valor = await _context.SaveChangesAsync();//Devolver un estado de la transaccion 0 = no se hizo transacciones
                if(valor > 0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo crear la boleta");
            }
        }
    }
}