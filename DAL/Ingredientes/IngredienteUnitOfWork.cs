using DAL.Ingredientes.Contracts;
using DAL.Ingredientes.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Ingredientes
{
    internal class IngredienteUnitOfWork : BaseRepository, IIngredienteUnitOfWork
    {
        private readonly IIngredienteRepository ingredienteRepository;
        private readonly IRecetaCantidadIngredienteRepository recetaCantidadIngredienteRepository;

        public IngredienteUnitOfWork(IConfiguration configuration, IIngredienteRepository ingredienteRepository, IRecetaCantidadIngredienteRepository recetaCantidadIngredienteRepository) : base(configuration)
        {
            this.ingredienteRepository = ingredienteRepository;
            this.recetaCantidadIngredienteRepository = recetaCantidadIngredienteRepository;
        }

        public List<IngredienteModel> GetAllIngredienteModel()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            return ingredienteRepository.GetAll(sqlConnection);
        }

        public List<RecetaCantidadIngredienteModel> GetAllRecetaCantidadIngredienteModels()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            return recetaCantidadIngredienteRepository.GetAll(sqlConnection);
        }

        public void Insert(IngredienteModel ingrediente, List<RecetaCantidadIngredienteModel>? recetaCantidadIngredienteModels = null)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
                ingredienteRepository.Insert(ingrediente, sqlConnection, sqlTransaction);
                recetaCantidadIngredienteRepository.RemoveByRecetaId(ingrediente.ComponenteRecetaId, sqlConnection, sqlTransaction);
                if (recetaCantidadIngredienteModels is not null)
                {
                    foreach (var item in recetaCantidadIngredienteModels)
                    {
                        recetaCantidadIngredienteRepository.Insert(item, sqlConnection, sqlTransaction);
                    }
                }
                sqlTransaction.Commit();
            }
            catch (Exception)
            {
                sqlTransaction.Rollback();
                throw;
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

        }

        
    }
}
