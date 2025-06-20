using DAL.Insumos.Contracts;
using DAL.Insumos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;

namespace DAL.Insumos.Repositories
{
    internal class TipoInsumoRepository : BaseRepository, ITipoInsumoRepository
    {
        public TipoInsumoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<TipoInsumoModel> GetAll(SqlConnection sqlConnection, SqlTransaction? sqlTransaction = null)
        {
            string spSelectAllTipoInsumo = "sp_select_all_tipo_insumos";
            List<TipoInsumoModel> tiposInsumo = sqlConnection.Query<TipoInsumoModel>(spSelectAllTipoInsumo, transaction: sqlTransaction, commandType: CommandType.StoredProcedure).AsList();
            return tiposInsumo;
        }

        public void Insert(TipoInsumoModel tipoInsumo, SqlConnection sqlConnection, SqlTransaction? sqlTransaction = null)
        {
            string spInsertTipoInsumo = "sp_insert_tipo_insumo";
            sqlConnection.Execute(spInsertTipoInsumo, new { tipo = tipoInsumo.Tipo }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public void Remove(TipoInsumoModel tipoInsumo, SqlConnection sqlConnection, SqlTransaction? sqlTransaction = null)
        {
            string spDeleteTipoInsumo = "sp_delete_tipo_insumo";
            sqlConnection.Execute(spDeleteTipoInsumo, new { id = tipoInsumo.Id }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public void Update(TipoInsumoModel tipoInsumo, SqlConnection sqlConnection, SqlTransaction? sqlTransaction = null)
        {
            string spUpdateTipoInsumo = "sp_update_tipo_insumo";
            sqlConnection.Execute(spUpdateTipoInsumo, new { id = tipoInsumo.Id, tipo = tipoInsumo.Tipo }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }
    }
}
