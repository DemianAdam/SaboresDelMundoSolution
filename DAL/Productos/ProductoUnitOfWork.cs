using DAL.Productos.Contracts;
using DAL.Productos.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL.Productos
{
    internal class ProductoUnitOfWork : BaseRepository, IProductoUnitOfWork
    {
        private readonly IProductoRepository productoRepository;
        private readonly IProductoSubProductoRepository productoSubProductoRepository;
        private readonly IPromocionCantidadProductosRepository promocionCantidadProductosRepository;
        private readonly ITipoProductoRepository tipoProductoRepository;

        public ProductoUnitOfWork(IConfiguration configuration, IProductoRepository productoRepository, IProductoSubProductoRepository productoSubProductoRepository, IPromocionCantidadProductosRepository promocionCantidadProductosRepository, ITipoProductoRepository tipoProductoRepository) : base(configuration)
        {
            this.productoRepository = productoRepository;
            this.productoSubProductoRepository = productoSubProductoRepository;
            this.promocionCantidadProductosRepository = promocionCantidadProductosRepository;
            this.tipoProductoRepository = tipoProductoRepository;
        }

        public List<ProductoModel> GetAllProductoModel()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            return productoRepository.GetAll(sqlConnection);
        }

        public List<ProductoSubProductoModel> GetAllProductoSubProductoModels()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            return productoSubProductoRepository.GetAll(sqlConnection);
        }

        public List<PromocionCantidadTipoProductoModel> GetAllPromocionCantidadProductosModels()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            return promocionCantidadProductosRepository.GetAll(sqlConnection);
        }

        public List<TipoProductoModel> GetAllTiposProductos()
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            return tipoProductoRepository.GetAll(sqlConnection);
        }

        public void Insert(ProductoModel producto, List<ProductoSubProductoModel>? productoSubProductoModels = null, List<PromocionCantidadTipoProductoModel>? promocionCantidadProductosModels = null)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            SqlTransaction transaction = sqlConnection.BeginTransaction();

            try
            {
                productoRepository.Insert(producto, sqlConnection, transaction);
                if (productoSubProductoModels is not null)
                {
                    foreach (var item in productoSubProductoModels)
                    {
                        productoSubProductoRepository.Insert(item, sqlConnection, transaction);
                    }
                }
                if (promocionCantidadProductosModels is not null)
                {
                    foreach (var item in promocionCantidadProductosModels)
                    {
                        promocionCantidadProductosRepository.Insert(item, sqlConnection, transaction);
                    }
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw; // Re-throw the exception to be handled by the caller
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public void Insert(TipoProductoModel tipoProducto)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            tipoProductoRepository.Insert(tipoProducto, sqlConnection);
        }

        public void Remove(ProductoModel producto)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            productoRepository.Remove(producto, sqlConnection);
        }

        public void Remove(TipoProductoModel tipoProducto)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            tipoProductoRepository.Remove(tipoProducto, sqlConnection);
        }

        public void Update(ProductoModel producto, List<ProductoSubProductoModel>? productoSubProductoModels = null, List<PromocionCantidadTipoProductoModel>? promocionCantidadProductosModels = null)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            SqlTransaction transaction = sqlConnection.BeginTransaction();
            try
            {
                productoRepository.Update(producto, sqlConnection, transaction);
                productoSubProductoRepository.RemoveAllByProductId(producto.Id, sqlConnection, transaction);
                promocionCantidadProductosRepository.RemoveAllByProductoId(producto.Id, sqlConnection, transaction);
                if (productoSubProductoModels is not null)
                {
                    foreach (var item in productoSubProductoModels)
                    {
                        productoSubProductoRepository.Insert(item, sqlConnection, transaction);
                    }
                }

                if (promocionCantidadProductosModels is not null)
                {
                    foreach (var item in promocionCantidadProductosModels)
                    {
                        promocionCantidadProductosRepository.Insert(item, sqlConnection, transaction);
                    }
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
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

        public void Update(TipoProductoModel tipoProducto)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            tipoProductoRepository.Update(tipoProducto, sqlConnection);
        }
    }
}
