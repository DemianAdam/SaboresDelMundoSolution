using BLL.Productos.Contracts;
using DAL.Productos;
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
    internal class TipoProductoService : ITipoProductoService
    {
        private readonly IProductoUnitOfWork _repository;
        public event EventHandler? OnOperationFinished;

        public TipoProductoService(IProductoUnitOfWork repository)
        {
            this._repository = repository;
        }

        public List<TipoProducto> GetAll()
        {
            return _repository.GetAllTiposProductos()
                .ToTiposProductos();
        }

        public void Insert(TipoProducto tipoProducto)
        {
           _repository.Insert(tipoProducto.ToModel());
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Remove(TipoProducto tipoProducto)
        {
            _repository.Remove(tipoProducto.ToModel());
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Update(TipoProducto tipoProducto)
        {
            _repository.Update(tipoProducto.ToModel());
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }
    }
}
