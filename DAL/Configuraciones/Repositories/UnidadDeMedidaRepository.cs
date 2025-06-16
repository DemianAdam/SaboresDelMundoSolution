using DAL.Configuraciones.Contracts;
using DAL.Configuraciones.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuraciones.Repositories
{
    internal class UnidadDeMedidaRepository : BaseRepository, IUnidadDeMedidaRepository
    {
        public UnidadDeMedidaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<UnidadDeMedidaModel> GetAll()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string spSelectAllUnidadesDeMedida = "sp_select_all_unidades_de_medida";
            List<UnidadDeMedidaModel> unidadesDeMedida = sqlConnection.Query<UnidadDeMedidaModel>(spSelectAllUnidadesDeMedida, commandType: CommandType.StoredProcedure).AsList();
            return unidadesDeMedida;
        }

        public void Insert(UnidadDeMedidaModel unidadDeMedida)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string spInsertUnidadDeMedida = "sp_insert_unidad_de_medida";
            sqlConnection.Execute(spInsertUnidadDeMedida, new { unidad = unidadDeMedida.Unidad }, commandType: CommandType.StoredProcedure);
        }

        public void Remove(UnidadDeMedidaModel unidadDeMedida)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string spDeleteUnidadDeMedida = "sp_delete_unidad_de_medida";
            sqlConnection.Execute(spDeleteUnidadDeMedida, new { id = unidadDeMedida.Id }, commandType: CommandType.StoredProcedure);
        }

        public void Update(UnidadDeMedidaModel unidadDeMedida)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string spUpdateUnidadDeMedida = "sp_update_unidad_de_medida";
            sqlConnection.Execute(spUpdateUnidadDeMedida, new { id = unidadDeMedida.Id, unidad = unidadDeMedida.Unidad }, commandType: CommandType.StoredProcedure);
        }
    }
}
