using BLL.Compras.Contracts;
using BLL.Compras.Validators;
using Entities.Transacciones.Compras;
using Interfaces;
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
        private readonly DetalleCompraValidator validator;

        public event EventHandler? OnOperationFinished;
        public DetalleCompraDbContext(IDetalleCompraService detalleCompraService,Compra compra)
        {
            this.detalleCompraService = detalleCompraService;
            this.compra = compra;
            detalleCompraService.OnOperationFinished += (sender, e) => OnOperationFinished?.Invoke(sender, e);
            this.validator = new DetalleCompraValidator(compra);
        }
        public void Add(DetalleCompra detalleCompra)
        {
            validator.Validate(detalleCompra);
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
