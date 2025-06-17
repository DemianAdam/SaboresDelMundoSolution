using DAL.Ingredientes.Contracts;
using DAL.Ingredientes.Models;
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
    internal class RecetaCantidadIngredienteRepository : IRecetaCantidadIngredienteRepository
    {
        public List<RecetaCantidadIngredienteModel> GetAll(SqlConnection sqlConnection)
        {
            string spSelectAllRecetaCantidadIngredientes = "sp_select_all_receta_cantidad_ingredientes";
            List<RecetaCantidadIngredienteModel> recetaCantidadIngredientesModel = sqlConnection.Query<RecetaCantidadIngredienteModel>(spSelectAllRecetaCantidadIngredientes, commandType: System.Data.CommandType.StoredProcedure).AsList();
            return recetaCantidadIngredientesModel;
        }

        public void Insert(RecetaCantidadIngredienteModel recetaCantidadIngrediente, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spInsertRecetaCantidadIngrediente = "sp_insert_receta_cantidad_ingrediente";
            connection.Execute(spInsertRecetaCantidadIngrediente, new { recetaId = recetaCantidadIngrediente.RecetaId, ingredienteId = recetaCantidadIngrediente.IngredienteId, unidadDeMedidaId = recetaCantidadIngrediente.UnidadDeMedidaId, cantidad = recetaCantidadIngrediente.Cantidad }, sqlTransaction, commandType: CommandType.StoredProcedure);
        }

        public void Remove(RecetaCantidadIngredienteModel recetaCantidadIngrediente, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spDeleteRecetaCantidadIngrediente = "sp_delete_ingrediente_of_receta";
            connection.Execute(spDeleteRecetaCantidadIngrediente, new { recetaId = recetaCantidadIngrediente.RecetaId, ingredienteId = recetaCantidadIngrediente.IngredienteId }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public void RemoveByRecetaId(int recetaId, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spDeleteRecetaCantidadIngredienteByRecetaId = "sp_delete_all_ingredientes_of_receta";
            connection.Execute(spDeleteRecetaCantidadIngredienteByRecetaId, new { recetaId }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public void Update(RecetaCantidadIngredienteModel recetaCantidadIngrediente, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spUpdateRecetaCantidadIngrediente = "sp_update_ingrediente_of_receta";
            connection.Execute(spUpdateRecetaCantidadIngrediente, new { recetaId = recetaCantidadIngrediente.RecetaId, ingredienteId = recetaCantidadIngrediente.IngredienteId, unidadDeMedidaId = recetaCantidadIngrediente.UnidadDeMedidaId, cantidad = recetaCantidadIngrediente.Cantidad }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }
    }
}
