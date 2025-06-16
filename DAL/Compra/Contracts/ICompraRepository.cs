using DAL.Compra.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Compra.Contracts
{
    internal interface ICompraRepository
    {
        List<CompraModel> GetAll(SqlConnection sqlConnection);
        int Insert(CompraModel compra, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        void Update(CompraModel compra, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        void Remove(CompraModel compra, SqlConnection connection, SqlTransaction? sqlTransaction = null);
    }
}
