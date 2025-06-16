using BLL.Compras.Contracts;
using DAL.Compra;
using DAL.Compra.Models;
using Entities;
using Mapper.Transacciones.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Compras.Services
{
    internal class ProveedorService : IProveedorService
    {
        private readonly ICompraUnitOfWork compraUnitOfWork;

        public event EventHandler? OnOperationFinished;

        public ProveedorService(ICompraUnitOfWork compraUnitOfWork)
        {
            this.compraUnitOfWork = compraUnitOfWork;
        }
        public List<Proveedor> GetAll()
        {
            List<ProveedorModel> proveedores = compraUnitOfWork.GetAllProveedores();
            return proveedores.ToProveedores();
        }

        public void Insert(Proveedor proveedor)
        {
            ProveedorModel proveedorModel = proveedor.ToModel();
            compraUnitOfWork.Insert(proveedorModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Remove(Proveedor proveedor)
        {
            ProveedorModel proveedorModel = proveedor.ToModel();
            compraUnitOfWork.Remove(proveedorModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Update(Proveedor proveedor)
        {
            ProveedorModel proveedorModel = proveedor.ToModel();
            compraUnitOfWork.Update(proveedorModel);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }
    }
}
