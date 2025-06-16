using BLL.Compartido.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Compras.Contracts
{
    public interface IDetalleCompraContext : IContext
    {
        public event EventHandler? OnOperationFinished;
        void Add(DetalleCompra detalleCompra);
        List<DetalleCompra> GetAll();
        void Remove(DetalleCompra detalleCompra);
        void Update(DetalleCompra detalleCompra);

    }
}
