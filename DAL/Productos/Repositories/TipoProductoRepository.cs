using DAL.Productos.Contracts;
using DAL.Productos.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL.Productos.Repositories
{
    internal class TipoProductoRepository : ITipoProductoRepository
    {
        public List<TipoProductoModel> GetAll(SqlConnection sqlConnection)
        {
            string spSelectAllTipoProducto = "sp_select_all_tipo_productos";
            List<TipoProductoModel> tiposProducto = sqlConnection.Query<TipoProductoModel>(spSelectAllTipoProducto, commandType: CommandType.StoredProcedure).AsList();
            return tiposProducto;
        }

        public void Insert(TipoProductoModel tipoProducto, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spInsertTipoProducto = "sp_insert_tipo_producto";
            connection.Execute(spInsertTipoProducto, new { tipo = tipoProducto.Tipo }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public void Remove(TipoProductoModel tipoProducto, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spDeleteTipoProducto = "sp_delete_tipo_producto";
            connection.Execute(spDeleteTipoProducto, new { id = tipoProducto.Id }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public void Update(TipoProductoModel tipoProducto, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spUpdateTipoProducto = "sp_update_tipo_producto";
            connection.Execute(spUpdateTipoProducto, new { id = tipoProducto.Id, tipo = tipoProducto.Tipo }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }
    }
}
