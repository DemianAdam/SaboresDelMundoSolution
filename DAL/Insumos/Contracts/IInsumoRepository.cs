using DAL.Insumos.Models;
using Microsoft.Data.SqlClient;

namespace DAL.Insumos.Contracts
{
    internal interface IInsumoRepository
    {
        void Insert(InsumoModel insumo, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        void Remove(InsumoModel insumo, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        void Update(InsumoModel insumo, SqlConnection connection, SqlTransaction? sqlTransaction = null);
        List<InsumoModel> GetAll(SqlConnection sqlConnection, SqlTransaction? sqlTransaction = null);
        bool Exists(InsumoModel insumoModel, SqlConnection sqlConnection);
    }
}
