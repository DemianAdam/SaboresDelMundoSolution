using DAL.Productos.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Productos.Contracts
{
    public interface IPromocionCantidadProductosRepository
    {
        public List<PromocionCantidadTipoProductoModel> GetAll(SqlConnection sqlConnection);
        void RemoveAllByProductoId(int id, SqlConnection sqlConnection, SqlTransaction transaction);
        public void Insert(PromocionCantidadTipoProductoModel promocionCantidadProductosModel, SqlConnection sqlConnection, SqlTransaction sqlTransaction);
    }
}
