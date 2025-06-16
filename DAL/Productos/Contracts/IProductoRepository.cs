using DAL.Productos.Models;
using Microsoft.Data.SqlClient;

namespace DAL.Productos.Contracts
{
    internal interface IProductoRepository
    {
        public int Insert(ProductoModel producto, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        public void Remove(ProductoModel producto, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        public void Update(ProductoModel producto, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        public List<ProductoModel> GetAll(SqlConnection sqlConnection);
    }
}