using System;

namespace Dominio
{
    public class Pedido
    {
        public Guid PedidoId {get;set;}
        public Guid BoletaId {get;set;}
        public Boleta Boleta {get;set;}
        public Guid UsuarioId {get;set;}
        public Usuario Usuario {get;set;}
        public string CodigoPago {get;set;}
        public string TipoPedido {get;set;}
        public DateTime? FechaCreacion {get;set;}
    }
}