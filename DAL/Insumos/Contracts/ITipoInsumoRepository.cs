using DAL.Insumos.Models;
using DAL.Productos.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Insumos.Contracts
{
    internal interface ITipoInsumoRepository
    {
        void Insert(TipoInsumoModel tipoProducto, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        void Remove(TipoInsumoModel tipoProducto, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        void Update(TipoInsumoModel tipoProducto, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        List<TipoInsumoModel> GetAll(SqlConnection sqlConnection);
    }
}
