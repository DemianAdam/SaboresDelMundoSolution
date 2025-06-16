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

        public InsumoUnitOfWork(IConfiguration configuration, IInsumoRepository insumoRepository, ITipoInsumoRepository tipoInsumoRepository) : base(configuration)
        {
            this.insumoRepository = insumoRepository;
            this.tipoInsumoRepository = tipoInsumoRepository;
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
            insumoRepository.Insert(insumo, sqlConnection);
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
            insumoRepository.Update(insumo, sqlConnection);
        }

        public void Update(TipoInsumoModel tipoInsumo)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            tipoInsumoRepository.Update(tipoInsumo, sqlConnection);
        }
    }
}
