using DAL.Compartido.Contracts;
using DAL.Compartido.Models;
using DAL.Compra.Contracts;
using DAL.Compra.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Compra
{
    internal class CompraUnitOfWork : BaseRepository, ICompraUnitOfWork
    {
        private readonly IProveedorRepository proveedorRepository;
        private readonly ICompraRepository compraRepository;
        private readonly IDetalleCompraRepository detalleCompraRepository;
        private readonly IPagoRepository pagoRepository;

        public CompraUnitOfWork(IConfiguration configuration,
            IProveedorRepository proveedorRepository,
            ICompraRepository compraRepository,
            IDetalleCompraRepository detalleCompraRepository, IPagoRepository pagoRepository) : base(configuration)
        {
            this.proveedorRepository = proveedorRepository;
            this.compraRepository = compraRepository;
            this.detalleCompraRepository = detalleCompraRepository;
            this.pagoRepository = pagoRepository;
        }

        public List<CompraModel> GetAllCompras()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            return compraRepository.GetAll(sqlConnection);
        }

        public List<DetalleCompraModel> GetAllDetalleCompras()
        {
            return detalleCompraRepository.GetAll();
        }

        public List<ProveedorModel> GetAllProveedores()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            return proveedorRepository.GetAll(sqlConnection);
        }

        public void Insert(ProveedorModel compra)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            proveedorRepository.Insert(compra, sqlConnection);
        }

        public void Insert(CompraModel compra, List<DetalleCompraModel>? detalleCompraModels, List<PagoModel>? pagoModels)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            SqlTransaction? sqlTransaction = null;
            try
            {
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction();
                int id = compraRepository.Insert(compra, sqlConnection, sqlTransaction);
                if (detalleCompraModels is not null)
                {
                    foreach (var detalleCompra in detalleCompraModels)
                    {
                        detalleCompra.CompraId = id;
                        detalleCompraRepository.Insert(detalleCompra, sqlConnection, sqlTransaction);
                    }
                }
                if (pagoModels is not null)
                {
                    foreach (var pago in pagoModels)
                    {
                        pago.CompraId = id;
                        pagoRepository.Insert(pago, sqlConnection, sqlTransaction);
                    }
                }
                sqlTransaction.Commit();
            }
            catch
            {
                sqlTransaction?.Rollback();
                throw;
            }
        }

        public void Remove(ProveedorModel compra)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            proveedorRepository.Remove(compra, sqlConnection);
        }

        public void Remove(CompraModel compra)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            compraRepository.Remove(compra, sqlConnection);

        }

        public void Update(ProveedorModel compra)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            proveedorRepository.Update(compra, sqlConnection);
        }

        public void Update(CompraModel compra, List<DetalleCompraModel>? detalleCompraModels, List<PagoModel>? pagoModels)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            SqlTransaction? sqlTransaction = null;
            try
            {
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction();
                compraRepository.Update(compra, sqlConnection, sqlTransaction);
                detalleCompraRepository.RemoveByCompraId(compra.Id, sqlConnection, sqlTransaction);
                pagoRepository.RemoveByTransactionId(compra, sqlConnection, sqlTransaction);
                if (detalleCompraModels is not null)
                {
                    foreach (var detalleCompra in detalleCompraModels)
                    {
                        detalleCompraRepository.Insert(detalleCompra, sqlConnection, sqlTransaction);
                    }
                }

                if (pagoModels is not null)
                {

                    foreach (var pago in pagoModels)
                    {
                        pagoRepository.Insert(pago, sqlConnection, sqlTransaction);
                    }
                }
                sqlTransaction.Commit();
            }
            catch
            {
                sqlTransaction?.Rollback();
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
