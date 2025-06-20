using DAL.Insumos.Contracts;
using DAL.Insumos.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Insumos.Repositories
{
    internal class InsumoRepository : IInsumoRepository
    {
        public bool Exists(InsumoModel insumoModel, SqlConnection sqlConnection)
        {
            string spExistsInsumo = "sp_exists_insumo";
            return sqlConnection.ExecuteScalar<bool>(spExistsInsumo, new { nombre = insumoModel.Nombre, descripcion = insumoModel.Descripcion }, commandType: CommandType.StoredProcedure);
        }

        public List<InsumoModel> GetAll(SqlConnection sqlConnection, SqlTransaction? sqlTransaction = null)
        {
            string spSelectAllInsumos = "sp_select_all_insumos";
            List<InsumoModel> insumos = sqlConnection.Query<InsumoModel>(spSelectAllInsumos, transaction: sqlTransaction, commandType: CommandType.StoredProcedure).AsList();
            return insumos;
        }

        public void Insert(InsumoModel insumo, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spInsertInsumo = "sp_insert_insumo";
            connection.Execute(spInsertInsumo, new { nombre = insumo.Nombre, descripcion = insumo.Descripcion, tipoInsumoId = insumo.TipoInsumoId }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public void Remove(InsumoModel insumo, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {

            string spDeleteInsumo = "sp_delete_insumo";
            connection.Execute(spDeleteInsumo, new { id = insumo.Id }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public void Update(InsumoModel insumo, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spUpdateInsumo = "sp_update_insumo";
            connection.Execute(spUpdateInsumo, new { id = insumo.Id, nombre = insumo.Nombre, descripcion = insumo.Descripcion, tipoInsumoId = insumo.TipoInsumoId }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }
    }
}
