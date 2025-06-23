using DAL.Configuraciones.Contracts;
using DAL.Configuraciones.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuraciones.Repositories
{
    internal class ConversionRepository : BaseRepository, IConversionRepository
    {
        public ConversionRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<ConversionModel> GetAll()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string spSelectAllConveriones = "sp_select_all_conversiones";
            return sqlConnection.Query<ConversionModel>(spSelectAllConveriones).ToList();
        }

        public void Insert(ConversionModel conversion)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string spInsertConversion = "sp_insert_conversion";
            sqlConnection.Execute(spInsertConversion, new
            {
                insumoId = conversion.InsumoId,
                unidadFromId = conversion.UnidadFromId,
                unidadToId = conversion.UnidadToId,
                factor = conversion.Factor
            });
        }

        public void Remove(ConversionModel conversion)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string spDeleteConversion = "sp_delete_conversion";
            sqlConnection.Execute(spDeleteConversion, new
            {
                id = conversion.Id
            });
        }

        public void Update(ConversionModel conversion)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string spUpdateConversion = "sp_update_conversion";
            sqlConnection.Execute(spUpdateConversion, new
            {
                id = conversion.Id,
                insumoId = conversion.InsumoId,
                unidadFromId = conversion.UnidadFromId,
                unidadToId = conversion.UnidadToId,
                factor = conversion.Factor
            });
        }
    }
}
