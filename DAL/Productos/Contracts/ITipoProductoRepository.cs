using DAL.Productos.Models;
using Microsoft.Data.SqlClient;

namespace DAL.Productos.Contracts
{
    public interface ITipoProductoRepository
    {
        void Insert(TipoProductoModel tipoInsumo, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        void Remove(TipoProductoModel tipoInsumo, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        void Update(TipoProductoModel tipoInsumo, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        List<TipoProductoModel> GetAll(SqlConnection sqlConnection);
    }
}
