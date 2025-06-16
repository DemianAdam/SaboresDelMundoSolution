using DAL.Compra.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Compra.Contracts
{
    internal interface IProveedorRepository
    {
        List<ProveedorModel> GetAll(SqlConnection sqlConnection);
        void Insert(ProveedorModel proveedor, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        void Update(ProveedorModel proveedor, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        void Remove(ProveedorModel proveedor, SqlConnection connection, SqlTransaction? sqlTransaction = null);
    }
}
