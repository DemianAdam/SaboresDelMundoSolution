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
    internal class IngredienteRepository : IIngredienteRepository
    {
        public List<IngredienteModel> GetAll(SqlConnection sqlConnection)
        {
            string spSelectAllIngredientes = "sp_select_all_ingredientes_and_recetas";
            List<IngredienteModel> ingredientesModel = sqlConnection.Query<IngredienteModel>(spSelectAllIngredientes, commandType: CommandType.StoredProcedure).AsList();
            return ingredientesModel;
        }

        public int Insert(IngredienteModel ingrediente, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spInsertIngrediente = "sp_insert_ingrediente";
            int id = connection.ExecuteScalar<int>(spInsertIngrediente, new { nombre = ingrediente.Nombre, descripcion = ingrediente.Descripcion, esReceta = ingrediente.EsReceta }, sqlTransaction, commandType: CommandType.StoredProcedure);
            ingrediente.Id = id;
            return id;
        }

        public void Remove(IngredienteModel ingrediente, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spDeleteIngrediente = "sp_delete_ingrediente";
            connection.Execute(spDeleteIngrediente, new { id = ingrediente.Id }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }

        public void Update(IngredienteModel ingrediente, SqlConnection connection, SqlTransaction? sqlTransaction = null)
        {
            string spUpdateIngrediente = "sp_update_ingrediente";
            connection.Execute(spUpdateIngrediente, new { id = ingrediente.Id, nombre = ingrediente.Nombre, descripcion = ingrediente.Descripcion, esReceta = ingrediente.EsReceta }, commandType: CommandType.StoredProcedure, transaction: sqlTransaction);
        }
    }
}
