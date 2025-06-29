using BLL.Compras.Contracts;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Compras.Validators
{
    internal class DetalleCompraValidator
    {
        private readonly Compra compra;

        public DetalleCompraValidator(Compra compra)
        {
            this.compra = compra;
        }
        public void Validate(DetalleCompra entity)
        {
            decimal totalDetalles = compra.Detalles?.Sum(d => d.Costo) ?? 0;

            if (totalDetalles + entity.Costo > compra.MontoTotal)
            {
                throw new ArgumentException("El total de los detalles no puede superar el monto total de la compra.", nameof(entity));
            }
        }
    }
}
