using BLL.Compras.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Compras.Validators
{
    internal class DetalleCompraValidator : IValidator<DetalleCompra>
    {
        private readonly Compra compra;

        public DetalleCompraValidator(Compra compra)
        {
            this.compra = compra;
        }
        public bool Validate(DetalleCompra entity)
        {
            decimal totalDetalles = compra.Detalles?.Sum(d => d.Cantidad * d.Costo) ?? 0;

            if (totalDetalles + entity.Costo > compra.MontoTotal)
            {
                return false;
            }

            return true;
        }
    }
}
