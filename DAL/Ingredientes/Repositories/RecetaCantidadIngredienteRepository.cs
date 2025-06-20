using DAL.Ingredientes.Contracts;
using DAL.Ingredientes.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Ingredientes.Repositories
{
    internal class RecetaCantidadIngredienteRepository : BaseRepository, IRecetaCantidadIngredienteRepository
    {
        public RecetaCantidadIngredienteRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<RecetaCantidadIngredienteModel> GetAll(SqlConnection? sqlConnection = null)
        {
            if (sqlConnection is null) {
                sqlConnection = new SqlConnection(_connectionString);
            }

            string spSelectAllRecetaCantidadIngredientes = "sp_select_all_receta_cantidad_ingredientes";
            List<RecetaCantidadIngredienteModel> recetaCantidadIngredientesModel = sqlConnection.Query<RecetaCantidadIngredienteModel>(spSelectAllRecetaCantidadIngredientes, commandType: CommandType.StoredProcedure).AsList();
            return recetaCantidadIngredientesModel;
        }

        public void Insert(RecetaCantidadIngredienteModel recetaCantidadIngrediente, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null)
        {
            if (connection is null)
            {
                connection = new SqlConnection(_connectionString);
            }
            string spInsertRecetaCantidadIngrediente = "sp_insert_receta_cantidad_ingredientes";
            connection.Execute(spInsertRecetaCantidadIngrediente, new
            {
                recetaId = recetaCantidadIngrediente.RecetaId,
                ingredienteId = recetaCantidadIngrediente.IngredienteId,
                unidadDeMedidaId = recetaCantidadIngrediente.UnidadDeMedidaId,
                cantidad = recetaCantidadIngrediente.Cantidad,
                desperdicioAceptado = recetaCantidadIngrediente.DesperdicioAceptado
            }, sqlTransaction, commandType: CommandType.StoredProcedure);
        }

        public void Remove(RecetaCantidadIngredienteModel recetaCantidadIngrediente, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null)
        {
            if (connection is null)
            {
                connection = new SqlConnection(_connectionString);
            }
            string spDeleteRecetaCantidadIngrediente = "sp_delete_ingrediente_of_receta";
            connection.Execute(spDeleteRecetaCantidadIngrediente, new { id = recetaCantidadIngrediente.Id }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public void RemoveByRecetaId(int recetaId, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null)
        {
            if (connection is null)
            {
                connection = new SqlConnection(_connectionString);
            }
            string spDeleteRecetaCantidadIngredienteByRecetaId = "sp_delete_all_ingredientes_of_receta";
            connection.Execute(spDeleteRecetaCantidadIngredienteByRecetaId, new { recetaId }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public List<RecetaCantidadIngredienteModel> GetAllByRecetaId(int recetaId, SqlConnection? sqlConnection = null)
        {
            if (sqlConnection is null)
            {
                sqlConnection = new SqlConnection(_connectionString);
            }
            string spSelectAllRecetaCantidadIngredientesByRecetaId = "sp_select_all_receta_cantidad_ingredientes_by_receta_id";
            List<RecetaCantidadIngredienteModel> recetaCantidadIngredientesModel = sqlConnection.Query<RecetaCantidadIngredienteModel>(spSelectAllRecetaCantidadIngredientesByRecetaId, new { recetaId }, commandType: CommandType.StoredProcedure).AsList();
            return recetaCantidadIngredientesModel;
        }

        public void Update(RecetaCantidadIngredienteModel recetaCantidadIngrediente, SqlConnection? connection = null, SqlTransaction? sqlTransaction = null)
        {
            if (connection is null)
            {
                connection = new SqlConnection(_connectionString);
            }
            string spUpdateRecetaCantidadIngrediente = "sp_update_ingrediente_of_receta";
            connection.Execute(spUpdateRecetaCantidadIngrediente, new
            {
                id = recetaCantidadIngrediente.Id,
                recetaId = recetaCantidadIngrediente.RecetaId,
                ingredienteId = recetaCantidadIngrediente.IngredienteId,
                unidadDeMedidaId = recetaCantidadIngrediente.UnidadDeMedidaId,
                cantidad = recetaCantidadIngrediente.Cantidad,
                desperdicioAceptado = recetaCantidadIngrediente.DesperdicioAceptado
            }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }
    }
}
