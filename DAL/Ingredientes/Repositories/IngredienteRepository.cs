using DAL.Ingredientes.Contracts;
using DAL.Ingredientes.Models;
using DAL.Insumos.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Ingredientes.Repositories
{
    internal class IngredienteRepository : IIngredienteRepository
    {
        public List<IngredienteModel> GetAll(SqlConnection sqlConnection, SqlTransaction? sqlTransaction = null)
        {
            string spSelectAllIngredientes = "sp_select_all_ingredientes";
            List<IngredienteModel> ingredientesModel = sqlConnection.Query<IngredienteModel>(spSelectAllIngredientes, transaction: sqlTransaction, commandType: CommandType.StoredProcedure).AsList();
            return ingredientesModel;
        }

        public int Insert(IngredienteModel ingrediente, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spInsertIngrediente = "sp_insert_ingrediente";
            int id = connection.ExecuteScalar<int>(spInsertIngrediente, new { insumoId = ingrediente.InsumoId }, sqlTransaction, commandType: CommandType.StoredProcedure);
            ingrediente.ComponenteRecetaId = id;
            return id;
        }

        public void RemoveByInsumo(InsumoModel insumo, SqlConnection sqlConnection, SqlTransaction? sqlTransaction = null)
        {
            string spDeleteIngredienteByInsumo = "sp_delete_ingrediente_by_insumo";
            sqlConnection.Execute(spDeleteIngredienteByInsumo, new { insumoId = insumo.Id }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }
    }
}
