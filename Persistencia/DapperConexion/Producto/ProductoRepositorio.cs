using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Persistencia.DapperConexion.Producto
{
    public class ProductoRepositorio : IProducto
    {
        private readonly IFactoryConnection _factoryConnection;
        public ProductoRepositorio(IFactoryConnection factoryConnection){
            _factoryConnection = factoryConnection;
        }

        public async Task<IEnumerable<ProductoModel>> ObtenerPorNombre(string nombre)
        {
            IEnumerable<ProductoModel> productos = null;
            var storedProcedure = "dbo.buscarPorNombre";
            try
            {
                var connection = _factoryConnection.GetConnection();
                productos = await connection.QueryAsync<ProductoModel>(
                    storedProcedure,
                    new {
                        nombre = nombre
                    },
                    commandType:CommandType.StoredProcedure
                );
            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta",e);
            }
            finally{
                _factoryConnection.CloseConnection();
            }
            return productos;
        }
    }
}