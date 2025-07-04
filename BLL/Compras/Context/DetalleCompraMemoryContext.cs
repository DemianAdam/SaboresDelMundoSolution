﻿using BLL.Compras.Contracts;
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
    public class DetalleCompraMemoryContext : IDetalleCompraContext
    {
        private readonly Compra compra;
        private readonly DetalleCompraValidator validator;

        public event EventHandler? OnOperationFinished;
        public DetalleCompraMemoryContext(Compra compra)
        {
            this.compra = compra;
            this.validator = new DetalleCompraValidator(compra);
        }
        public void Add(DetalleCompra detalleCompra)
        {
            if (compra.Detalles is null)
            {
                compra.Detalles = new List<DetalleCompra>();
            }

            validator.Validate(detalleCompra);

            compra.Detalles.Add(detalleCompra);
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public List<DetalleCompra> GetAll()
        {
            if (compra.Detalles is null)
            {
                compra.Detalles = new List<DetalleCompra>();
            }
            return compra.Detalles;
        }

        public void Remove(DetalleCompra detalleCompra)
        {
            if (compra.Detalles is null)
            {
                return;
            }
            compra.Detalles = compra.Detalles.Where(x => x.Id != detalleCompra.Id).ToList();
            OnOperationFinished?.Invoke(this, EventArgs.Empty);
        }

        public void Update(DetalleCompra detalleCompra)
        {
            if (compra.Detalles is null)
            {
                return;
            }
            validator.Validate(detalleCompra);
            var existingDetalle = compra.Detalles.FirstOrDefault(x => x.Id == detalleCompra.Id);

            if (existingDetalle is not null)
            {
                existingDetalle.Peso = detalleCompra.Peso.Clone();
                existingDetalle.Insumo = detalleCompra.Insumo;
                existingDetalle.Costo = detalleCompra.Costo;
                OnOperationFinished?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
