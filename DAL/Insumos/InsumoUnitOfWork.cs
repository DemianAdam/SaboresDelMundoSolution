using DAL.Ingredientes.Contracts;
using DAL.Ingredientes.Models;
using DAL.Insumos.Contracts;
using DAL.Insumos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Insumos
{
    internal class InsumoUnitOfWork : BaseRepository, IInsumoUnitOfWork
    {
        private readonly IInsumoRepository insumoRepository;
        private readonly ITipoInsumoRepository tipoInsumoRepository;
        private readonly IIngredienteRepository ingredienteRepository;

        public InsumoUnitOfWork(IConfiguration configuration, IInsumoRepository insumoRepository, ITipoInsumoRepository tipoInsumoRepository, IIngredienteRepository ingredienteRepository) : base(configuration)
        {
            this.insumoRepository = insumoRepository;
            this.tipoInsumoRepository = tipoInsumoRepository;
            this.ingredienteRepository = ingredienteRepository;
        }

        public bool Exists(InsumoModel insumoModel)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            return insumoRepository.Exists(insumoModel, sqlConnection);
        }

        public List<InsumoModel> GetAllInsumos()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            return insumoRepository.GetAll(sqlConnection);
        }

        public List<TipoInsumoModel> GetAllTiposInsumos()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            return tipoInsumoRepository.GetAll(sqlConnection);
        }

        public void Insert(InsumoModel insumo)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                bool InsumoExists = insumoRepository.Exists(insumo, sqlConnection, sqlTransaction);
                TipoInsumoModel? tipoIngrediente = tipoInsumoRepository.GetAll(sqlConnection, sqlTransaction).FirstOrDefault(t => t.Tipo == "Ingrediente");

                if (InsumoExists)
                {
                    throw new Exception("El insumo ya existe.");
                }
                if (tipoIngrediente is null)
                {
                    throw new Exception("Tipo de insumo no encontrado.");
                }

                insumoRepository.Insert(insumo, sqlConnection, sqlTransaction);

                if (insumo.TipoInsumoId == tipoIngrediente.Id)
                {
                    ingredienteRepository.Insert(new IngredienteModel
                    {
                        InsumoId = insumo.Id,
                    }, sqlConnection, sqlTransaction);
                }


                sqlTransaction.Commit();
            }
            catch (Exception)
            {
                sqlTransaction.Rollback();
                throw;
            }
        }

        public void Insert(TipoInsumoModel tipoInsumo)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            tipoInsumoRepository.Insert(tipoInsumo, sqlConnection);
        }

        public void Remove(InsumoModel insumo)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            insumoRepository.Remove(insumo, sqlConnection);
        }

        public void Remove(TipoInsumoModel tipoInsumo)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            tipoInsumoRepository.Remove(tipoInsumo, sqlConnection);
        }

        public void Update(InsumoModel insumo)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                InsumoModel? actualInsumoModel = insumoRepository.GetAll(sqlConnection, sqlTransaction).FirstOrDefault(i => i.Id == insumo.Id);
                TipoInsumoModel? tipoIngrediente = tipoInsumoRepository.GetAll(sqlConnection, sqlTransaction).FirstOrDefault(t => t.Tipo == "Ingrediente");
                if (actualInsumoModel is null)
                {
                    throw new Exception("Insumo no encontrado.");
                }
                if (tipoIngrediente is null)
                {
                    throw new Exception("Tipo de insumo no encontrado.");
                }

                if (insumo.TipoInsumoId != tipoIngrediente.Id)
                {
                    ingredienteRepository.RemoveByInsumo(insumo, sqlConnection, sqlTransaction);
                }

                if (actualInsumoModel.TipoInsumoId != tipoIngrediente.Id && insumo.TipoInsumoId == tipoIngrediente.Id)
                {
                    ingredienteRepository.Insert(new IngredienteModel
                    {
                        InsumoId = insumo.Id,
                    }, sqlConnection, sqlTransaction);
                }


                insumoRepository.Update(insumo, sqlConnection, sqlTransaction);
                sqlTransaction.Commit();
            }
            catch (Exception)
            {
                sqlTransaction.Rollback();
                throw;
            }
        }

        public void Update(TipoInsumoModel tipoInsumo)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            tipoInsumoRepository.Update(tipoInsumo, sqlConnection);
        }
    }
}
