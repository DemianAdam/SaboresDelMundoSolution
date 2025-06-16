using DAL.Compartido.Contracts;
using DAL.Compartido.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
namespace DAL.Compartido.Repositories
{
    internal class PagoRepository : BaseRepository, IPagoRepository
    {
        public PagoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<PagoModel> GetAll()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string spSelectAllPagos = "sp_select_all_pagos";
            List<PagoModel> pagosModel = sqlConnection.Query<PagoModel>(spSelectAllPagos, commandType: CommandType.StoredProcedure).AsList();
            return pagosModel;
        }

        public List<PagoModel> GetAllByTransactionId(TransaccionModel transaccionModel)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            if (transaccionModel.CompraId is null && transaccionModel.VentaId is null)
            {
                throw new ArgumentException("Debe proporcionar un ID de compra o venta para obtener los pagos asociados.");
            }
            else if (transaccionModel.CompraId is not null)
            {
                string sp = "sp_select_all_pagos_of_compra";
                return sqlConnection.Query<PagoModel>(sp, new { compraId = transaccionModel.CompraId }, commandType: CommandType.StoredProcedure).AsList();
            }
            else
            {
                string sp = "sp_select_all_pagos_of_venta";
                return sqlConnection.Query<PagoModel>(sp, new { ventaId = transaccionModel.VentaId }, commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public void Insert(PagoModel pago, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null)
        {
            if (connection is null)
            {
                connection = new SqlConnection(_connectionString);
            }
            string spInsertPago = "sp_insert_pago";
            connection.Execute(spInsertPago, new
            {
                fecha = pago.Fecha,
                cantidad = pago.Cantidad,
                tipoPago = pago.TipoPago,
                compraId = pago.CompraId,
                ventaId = pago.VentaId
            }, sqlTransaction, commandType: CommandType.StoredProcedure);
        }

        public void Remove(PagoModel pago, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null)
        {
            if (connection is null)
            {
                connection = new SqlConnection(_connectionString);
            }
            string spDeletePago = "sp_delete_pago";
            connection.Execute(spDeletePago, new { id = pago.Id }, sqlTransaction, commandType: CommandType.StoredProcedure);
        }

        public void RemoveByTransactionId(TransaccionModel transaccionModel, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null)
        {
            if (connection is null)
            {
                connection = new SqlConnection(_connectionString);
            }
            if (transaccionModel.CompraId is not null)
            {
                string spDeletePagosOfCompra = "sp_delete_pagos_of_compra";
                connection.Execute(spDeletePagosOfCompra, new { compraId = transaccionModel.CompraId }, sqlTransaction, commandType: CommandType.StoredProcedure);
            }
            else if (transaccionModel.VentaId is not null)
            {
                string spDeletePagosOfVenta = "sp_delete_pagos_of_venta";
                connection.Execute(spDeletePagosOfVenta, new { ventaId = transaccionModel.VentaId }, sqlTransaction, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(PagoModel pago, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null)
        {
            if (connection is null)
            {
                connection = new SqlConnection(_connectionString);
            }
            string spUpdatePago = "sp_update_pago";
            connection.Execute(spUpdatePago, new
            {
                id = pago.Id,
                fecha = pago.Fecha,
                cantidad = pago.Cantidad,
                tipoPago = pago.TipoPago,
                compraId = pago.CompraId,
                ventaId = pago.VentaId
            }, sqlTransaction, commandType: CommandType.StoredProcedure);
        }
    }
}
