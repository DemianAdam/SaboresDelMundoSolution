using Microsoft.Data.SqlClient;

namespace DAL.Productos.Contracts
{
    public interface IProductoSubProductoRepository
    {
        public List<ProductoSubProductoModel> GetAll(SqlConnection sqlConnection);
        public void Insert(ProductoSubProductoModel item, SqlConnection sqlConnection, SqlTransaction transaction);
        void RemoveAllByProductId(int id, SqlConnection sqlConnection, SqlTransaction transaction);
        public void Update(ProductoSubProductoModel item, SqlConnection sqlConnection, SqlTransaction transaction);
    }
}
