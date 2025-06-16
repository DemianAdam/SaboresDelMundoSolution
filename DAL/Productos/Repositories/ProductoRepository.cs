using DAL.Productos.Contracts;
using DAL.Productos.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL.Productos.Repositories
{
    internal class ProductoRepository : IProductoRepository
    {
        public List<ProductoModel> GetAll(SqlConnection sqlConnection)
        {
            string spSelectAllProductos = "sp_select_all_productos";
            List<ProductoModel> productosModel = sqlConnection.Query<ProductoModel>(spSelectAllProductos, commandType: CommandType.StoredProcedure).AsList();
            return productosModel;
        }

        public int Insert(ProductoModel producto, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spInsertProducto = "sp_insert_producto";
            int id = connection.ExecuteScalar<int>(spInsertProducto, new { nombre = producto.Nombre, precio = producto.Precio, tipoProductoId = producto.TipoProductoId }, sqlTransaction, commandType: CommandType.StoredProcedure);
            producto.Id = id;
            return id;
        }
        /*public void Insert(Producto producto)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string spInsertProducto = "sp_insert_producto";
            string spInsertProductoSubProducto = "sp_insert_producto_Subproducto";
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                producto.Id = connection.ExecuteScalar<int>(spInsertProducto, new { nombre = producto.Nombre, precio = producto.Precio, tipoProductoId = producto.Tipo?.Id }, transaction, commandType: CommandType.StoredProcedure);

                foreach (var subProducto in producto.SubProductos)
                {
                    connection.Execute(spInsertProductoSubProducto, new { productoId = producto.Id, subProductoId = subProducto.Id }, transaction, commandType: CommandType.StoredProcedure);
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
        }*/

        public void Remove(ProductoModel producto, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spDeleteProducto = "sp_delete_producto";
            connection.Execute(spDeleteProducto, new { id = producto.Id }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public void Update(ProductoModel producto, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spUpdateProducto = "sp_update_producto";
            connection.Execute(spUpdateProducto, new { id = producto.Id, nombre = producto.Nombre, precio = producto.Precio, tipoProductoId = producto.TipoProductoId }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }
    }
}