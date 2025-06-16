using DAL.Compra.Contracts;
using DAL.Compra.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL.Compra.Repositories
{
    internal class CompraRepository : ICompraRepository
    {
        public List<CompraModel> GetAll(SqlConnection sqlConnection)
        {
            string spSelectAllCompras = "sp_select_all_compras";
            List<CompraModel> comprasModel = sqlConnection.Query<CompraModel>(spSelectAllCompras, commandType: CommandType.StoredProcedure).AsList();
            return comprasModel;
        }

        public int Insert(CompraModel compra, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spInsertCompra = "sp_insert_compra";
           return connection.ExecuteScalar<int>(spInsertCompra, new { proveedorId = compra.ProveedorId, fecha = compra.Fecha, total = compra.Total }, sqlTransaction, commandType: CommandType.StoredProcedure);
        }

        public void Remove(CompraModel compra, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spDeleteCompra = "sp_delete_compra";
            connection.Execute(spDeleteCompra, new { id = compra.Id }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public void Update(CompraModel compra, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spUpdateCompra = "sp_update_compra";
            connection.Execute(spUpdateCompra, new { id = compra.Id, proveedorId = compra.ProveedorId, fecha = compra.Fecha, total = compra.Total }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }
    }
}
