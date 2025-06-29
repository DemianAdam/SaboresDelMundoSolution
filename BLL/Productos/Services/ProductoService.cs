using BLL.Productos.Contracts;
using DAL.Productos;
using DAL.Productos.Contracts;
using DAL.Productos.Models;
using Entities.Productos;
using Mapper;
using Mapper.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Productos.Services
{
    internal class ProductoService : IProductoService
    {
        private readonly IProductoUnitOfWork _repository;
        public event EventHandler? OnOperationFinished;

        public ProductoService(IProductoUnitOfWork repository)
        {
            this._repository = repository;
        }

        public List<Producto> GetAll()
        {
            List<ProductoModel> productoModels = _repository.GetAllProductoModel();
            List<TipoProductoModel> tipoProductoModels = _repository.GetAllTiposProductos();
            List<PromocionCantidadTipoProductoModel> promocionCantidadProductosModels = _repository.GetAllPromocionCantidadProductosModels();
            List<ProductoSubProductoModel> productoSubProductoModels = _repository.GetAllProductoSubProductoModels();

            List<Producto> productos = productoModels.ToProductos(tipoProductoModels, promocionCantidadProductosModels);

            return productos.AssignSubProductos(productoSubProductoModels);
        }

        public List<Producto> GetAvailableSubProducts(Producto producto)
        {
            return GetAll()
                .Where(p =>
                {
                    if (p.Id == producto.Id)
                        return false;
                    if (p.TieneSubProducto(producto) || producto.TieneSubProducto(p))
                    {
                        return false;
                    }
                    return true;
                })
                .ToList();
        }

        public void Insert(Producto producto)
        {
            ProductoModel productoModel = producto.ToModel();
            List<ProductoSubProductoModel>? productoSubProductoModels = producto.GetSubProductosModel();
            List<PromocionCantidadTipoProductoModel>? promocionCantidadProductosModels = producto.GetPromocionCantidadProductosModel();
            _repository.Insert(productoModel, productoSubProductoModels, promocionCantidadProductosModels);
            OnOperationFinished?.Invoke(producto, EventArgs.Empty);
        }

        public void Remove(Producto producto)
        {
            ProductoModel productoModel = producto.ToModel();
            _repository.Remove(productoModel);
            OnOperationFinished?.Invoke(producto, EventArgs.Empty);
        }

        public void Update(Producto producto)
        {
            ProductoModel productoModel = producto.ToModel();
            List<ProductoSubProductoModel>? productoSubProductoModels = producto.GetSubProductosModel();
            List<PromocionCantidadTipoProductoModel>? promocionCantidadProductosModels = producto.GetPromocionCantidadProductosModel();
            _repository.Update(productoModel, productoSubProductoModels, promocionCantidadProductosModels);
            OnOperationFinished?.Invoke(producto, EventArgs.Empty);
        }
    }
}
