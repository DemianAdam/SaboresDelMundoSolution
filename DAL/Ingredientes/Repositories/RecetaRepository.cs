using DAL.Ingredientes.Contracts;
using DAL.Ingredientes.Models.Recetas;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Ingredientes.Repositories
{
    internal class RecetaRepository : BaseRepository, IRecetaRepository
    {
        public RecetaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<RecetaModel> GetAll()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string spSelectAllRecetas = "sp_select_all_recetas";
            return sqlConnection.Query<RecetaModel>(spSelectAllRecetas, commandType: System.Data.CommandType.StoredProcedure).AsList();
        }

        public void Insert(InsertRecetaModel recetaModel)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string spInsertReceta = "sp_insert_receta";
            sqlConnection.Execute(spInsertReceta, recetaModel, commandType: System.Data.CommandType.StoredProcedure);
        }

        public void Remove(RecetaModel recetaModel)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string spDeleteReceta = "sp_delete_receta";
            sqlConnection.Execute(spDeleteReceta, new { id = recetaModel.ComponenteRecetaId }, commandType: System.Data.CommandType.StoredProcedure);
        }

        public void Update(RecetaModel recetaModel)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string spUpdateReceta = "sp_update_receta";
            sqlConnection.Execute(spUpdateReceta, recetaModel, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
