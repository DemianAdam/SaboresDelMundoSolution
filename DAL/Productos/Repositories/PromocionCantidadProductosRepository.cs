using DAL.Productos.Contracts;
using DAL.Productos.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL.Productos.Repositories
{
    internal class PromocionCantidadProductosRepository : IPromocionCantidadProductosRepository
    {
        public List<PromocionCantidadTipoProductoModel> GetAll(SqlConnection sqlConnection)
        {
            string spSelectAllPromocionesCantidadProductos = "sp_select_all_promociones_cantidad_productos";
            List<PromocionCantidadTipoProductoModel> promocionCantidadProductosModel = sqlConnection.Query<PromocionCantidadTipoProductoModel>(spSelectAllPromocionesCantidadProductos, commandType: CommandType.StoredProcedure).AsList();
            return promocionCantidadProductosModel;
        }

        public void RemoveAllByProductoId(int id, SqlConnection sqlConnection, SqlTransaction transaction)
        {
            string spDeletePromocionCantidadProductos = "sp_delete_promocion_cantidad_productos";
            sqlConnection.Execute(spDeletePromocionCantidadProductos, new { productoId = id }, commandType: CommandType.StoredProcedure, transaction: transaction);
        }

        public void Insert(PromocionCantidadTipoProductoModel promocionCantidadProductosModel, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            string spInsertPromocionCantidadProductos = "sp_insert_promocion_cantidad_productos";
            sqlConnection.Execute(spInsertPromocionCantidadProductos, new { productoId = promocionCantidadProductosModel.ProductoId, tipoProductoId = promocionCantidadProductosModel.TipoProductoId, cantidad = promocionCantidadProductosModel.Cantidad }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }
    }
}
