using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistencia.DapperConexion.Producto
{
    public interface IProducto
    {
        Task<IEnumerable<ProductoModel>> ObtenerPorNombre(string nombre);
    }
}