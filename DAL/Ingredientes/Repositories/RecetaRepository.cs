using DAL.Ingredientes.Contracts;
using DAL.Ingredientes.Models;
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

        public List<IngredienteModel> GetAll()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string spSelectAllRecetas = "sp_select_all_recetas";
            return sqlConnection.Query<IngredienteModel>(spSelectAllRecetas, commandType: System.Data.CommandType.StoredProcedure).AsList();
        }
    }
}
