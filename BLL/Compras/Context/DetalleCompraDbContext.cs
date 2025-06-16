using BLL.Compras.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Compras.Context
{
    public class DetalleCompraDbContext : IDetalleCompraContext
    {
        private readonly IDetalleCompraService detalleCompraService;
        private readonly Compra compra;

        public event EventHandler? OnOperationFinished;
        public DetalleCompraDbContext(IDetalleCompraService detalleCompraService,Compra compra)
        {
            this.detalleCompraService = detalleCompraService;
            this.compra = compra;
            detalleCompraService.OnOperationFinished += (sender, e) => OnOperationFinished?.Invoke(sender, e);
        }
        public void Add(DetalleCompra detalleCompra)
        {
            detalleCompraService.Insert(detalleCompra, compra);
        }
        public List<DetalleCompra> GetAll()
        {
            return detalleCompraService.GetAllByPurchaseId(compra);
        }
        public void Remove(DetalleCompra detalleCompra)
        {
            detalleCompraService.Remove(detalleCompra);
        }
        public void Update(DetalleCompra detalleCompra)
        {
            detalleCompraService.Update(detalleCompra, compra);
        }
    }
}
