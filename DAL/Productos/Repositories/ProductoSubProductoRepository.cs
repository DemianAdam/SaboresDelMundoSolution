using DAL.Productos.Contracts;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL.Productos.Repositories
{
    internal class ProductoSubProductoRepository : IProductoSubProductoRepository
    {
        public List<ProductoSubProductoModel> GetAll(SqlConnection sqlConnection)
        {
            string spSelectAllProductosSubProductos = "sp_select_all_productos_Subproductos";
            List<ProductoSubProductoModel> productosSubProductosModel = sqlConnection.Query<ProductoSubProductoModel>(spSelectAllProductosSubProductos, commandType: System.Data.CommandType.StoredProcedure).AsList();
            return productosSubProductosModel;
        }

        public void Insert(ProductoSubProductoModel item, SqlConnection sqlConnection, SqlTransaction transaction)
        {
            string spInsertProductoSubProducto = "sp_insert_producto_Subproducto";
            sqlConnection.Execute(spInsertProductoSubProducto, new { ProductoId = item.ProductoID, item.SubProductoId }, transaction, commandType: CommandType.StoredProcedure);
        }

        public void RemoveAllByProductId(int id, SqlConnection sqlConnection, SqlTransaction transaction)
        {
            string spDeleteProductoSubProducto = "sp_delete_producto_Subproducto";
            sqlConnection.Execute(spDeleteProductoSubProducto, new { productoId = id }, commandType: CommandType.StoredProcedure, transaction: transaction);
        }

        public void Update(ProductoSubProductoModel item, SqlConnection sqlConnection, SqlTransaction transaction)
        {
            string spUpdateProductoSubProducto = "sp_update_producto_Subproducto";
            sqlConnection.Execute(spUpdateProductoSubProducto, new { ProductoId = item.ProductoID, item.SubProductoId }, transaction, commandType: CommandType.StoredProcedure);
        }
    }
}
