using DAL.Compra.Contracts;
using DAL.Compra.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
namespace DAL.Compra.Repositories
{
    internal class DetalleCompraRepository : BaseRepository, IDetalleCompraRepository
    {
        public DetalleCompraRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<DetalleCompraModel> GetAll()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string spSelectAllDetallesCompras = "sp_select_all_detalles_compras";
            List<DetalleCompraModel> detallesComprasModel = sqlConnection.Query<DetalleCompraModel>(spSelectAllDetallesCompras, commandType: CommandType.StoredProcedure).AsList();
            return detallesComprasModel;
        }

        public List<DetalleCompraModel> GetAllByCompraId(CompraModel compraModel, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null)
        {
            if (connection is null)
            {
                connection = new SqlConnection(_connectionString);
            }
            string spSelectDetallesCompraByCompraId = "sp_select_detalles_compra_by_compra_id";
            List<DetalleCompraModel> detallesComprasModel = connection.Query<DetalleCompraModel>(spSelectDetallesCompraByCompraId, new { compraId = compraModel.Id }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction).AsList();
            return detallesComprasModel;
        }

        public void Insert(DetalleCompraModel detalleCompra, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null)
        {
            if (connection is null)
            {
                connection = new SqlConnection(_connectionString);
            }
            string spInsertDetalleCompra = "sp_insert_detalle_compra";
            connection.Execute(spInsertDetalleCompra, new
            {
                insumoId = detalleCompra.InsumoId,
                unidadDeMedidaId = detalleCompra.UnidadDeMedidaId,
                compraId = detalleCompra.CompraId,
                cantidad = detalleCompra.Cantidad,
                costo = detalleCompra.Costo
            }, sqlTransaction, commandType: CommandType.StoredProcedure);
        }

        public void Remove(DetalleCompraModel detalleCompra, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null)
        {
            if (connection is null)
            {
                connection = new SqlConnection(_connectionString);
            }
            string spDeleteDetalleCompra = "sp_delete_detalle_compra";
            connection.Execute(spDeleteDetalleCompra, new { id = detalleCompra.Id }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public void RemoveByCompraId(int compraId, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null)
        {
            if (connection is null)
            {
                connection = new SqlConnection(_connectionString);
            }
            string spDeleteDetalleCompraByCompraId = "sp_delete_detalle_compra_by_compra_id";
            connection.Execute(spDeleteDetalleCompraByCompraId, new { compraId }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public void Update(DetalleCompraModel detalleCompra, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null)
        {
            if (connection is null)
            {
                connection = new SqlConnection(_connectionString);
            }
            string spUpdateDetalleCompra = "sp_update_detalle_compra";
            connection.Execute(spUpdateDetalleCompra, new
            {
                id = detalleCompra.Id,
                insumoId = detalleCompra.InsumoId,
                unidadDeMedidaId = detalleCompra.UnidadDeMedidaId,
                compraId = detalleCompra.CompraId,
                cantidad = detalleCompra.Cantidad,
                costo = detalleCompra.Costo
            }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }
    }
}
