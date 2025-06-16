using DAL.Compra.Contracts;
using DAL.Compra.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace DAL.Compra.Repositories
{
    internal class ProveedorRepository : IProveedorRepository
    {
        public List<ProveedorModel> GetAll(SqlConnection sqlConnection)
        {
            string spSelectAllProveedores = "sp_select_all_proveedores";
            List<ProveedorModel> proveedoresModel = sqlConnection.Query<ProveedorModel>(spSelectAllProveedores, commandType: CommandType.StoredProcedure).AsList();
            return proveedoresModel;
        }

        public void Insert(ProveedorModel proveedor, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spInsertProveedor = "sp_insert_proveedor";
            connection.Execute(spInsertProveedor, new { nombre = proveedor.Nombre }, sqlTransaction, commandType: CommandType.StoredProcedure);
        }

        public void Remove(ProveedorModel proveedor, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spDeleteProveedor = "sp_delete_proveedor";
            connection.Execute(spDeleteProveedor, new { id = proveedor.Id }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public void Update(ProveedorModel proveedor, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spUpdateProveedor = "sp_update_proveedor";
            connection.Execute(spUpdateProveedor, new { id = proveedor.Id, nombre = proveedor.Nombre }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }
    }
}
