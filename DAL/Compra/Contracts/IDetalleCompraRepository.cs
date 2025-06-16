using DAL.Compra.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Compra.Contracts
{
    public interface IDetalleCompraRepository
    {
        List<DetalleCompraModel> GetAll();
        void Insert(DetalleCompraModel detalleCompra, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null);
        void Update(DetalleCompraModel detalleCompra, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null);
        void Remove(DetalleCompraModel detalleCompra, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null);

        void RemoveByCompraId(int compraId, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null);
    }
}
