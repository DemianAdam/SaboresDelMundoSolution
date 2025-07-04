﻿using BLL.Compras.Contracts;
using BLL.Compartido.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_UI.Helpers;
using BLL.Compras.Context;
using WinForm_UI.Contracts;
using System.Diagnostics;
using WinForm_UI.Events;
using Interfaces;
using Entities.Transacciones.Compras;
using System.Collections.ObjectModel;

namespace WinForm_UI.Forms.Compras
{
    public partial class GestorCompras : Form, IDataForm<Compra>
    {
        private readonly IEventBus eventBus;
        private readonly IFormFactoryService formFactoryService;
        private readonly IProveedorService proveedorService;
        private readonly ICompraService compraService;
        private readonly IContextFactory contextFactory;
        
        public List<ColumnConfiguration> ColumnsConfiguration => new List<ColumnConfiguration>
        {
            new (nameof(Compra.Fecha), 0),
            new (nameof(Compra.Proveedor),1),
            new (nameof(Compra.TotalPago), 2 , "Total Pagado"),
            new (nameof(Compra.MontoTotal), 3, "Monto Total"),
            new (nameof(Compra.EstaPagado), 4, "Esta Pagado?"),
            new (nameof(Compra.TotalDeuda), 5, "Deuda Total")
        };

        public GestorCompras(IEventBus eventBus, IFormFactoryService formFactoryService, IProveedorService proveedorService, ICompraService compraService, IContextFactory contextFactory)
        {
            InitializeComponent();
            this.eventBus = eventBus;
            this.formFactoryService = formFactoryService;
            this.proveedorService = proveedorService;
            this.compraService = compraService;
            this.contextFactory = contextFactory;
            this.eventBus.Subscribe<ProveedorChangedEvent>(ProveedorChanged);
            compraService.OnOperationFinished += CompraService_OnOperationFinished;
        }

        private void CompraService_OnOperationFinished(object? sender, EventArgs e)
        {
            UpdateData();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.eventBus.Unsubscribe<ProveedorChangedEvent>(ProveedorChanged);
            base.OnFormClosed(e);
        }
        private void ProveedorChanged(ProveedorChangedEvent @event)
        {
            ActualizarProveedores();
        }

        private void ActualizarProveedores()
        {
            FormHelper.UpdateControl(cmbProveedores, proveedorService, nameof(Proveedor.Nombre));
        }

        private void GestorCompras_Load(object sender, EventArgs e)
        {
            cmbProveedores.Enabled = cboxTieneProveedor.Checked;
            dtpFecha.Value = DateTime.Now;
            ActualizarProveedores();
            UpdateData();
        }

        private void cboxTieneProveedor_CheckedChanged(object sender, EventArgs e)
        {
            cmbProveedores.Enabled = cboxTieneProveedor.Checked;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now.DayOfYear == dtpFecha.Value.DayOfYear ? DateTime.Now : dtpFecha.Value;
            Compra compra = GetObjectFromInputs();
            compra.Fecha = date;

            if (MessageBox.Show("Queres agregar los detalles ahora?", "Agregar Detalles", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var context = contextFactory.CreateContext<DetalleCompraMemoryContext>(compra);
                DetallesCompraForm form = formFactoryService.CreateForm<DetallesCompraForm>(context);
                form.ShowDialog();
            }

            if (MessageBox.Show("Queres pagar la compra ahora?", "Pagar Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var context = contextFactory.CreateContext<PagoMemoryContext>(compra);
                PagarCompraForm form = formFactoryService.CreateForm<PagarCompraForm>(context);
                form.ShowDialog();
            }

            try
            {
                compraService.Insert(compra);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar la compra. Verifique los datos ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Compra? compra = dgvCompras.GetSelected<Compra>();
            if (compra is null)
            {
                MessageBox.Show("Debe seleccionar una compra para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"¿Está seguro de eliminar la compra con ID {compra.Id}?\nSe eliminaran los pagos asociados y los detalles de compra", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                compraService.Remove(compra);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Compra? compra = dgvCompras.GetSelected<Compra>();
            if (compra is null)
            {
                MessageBox.Show("Debe seleccionar una compra para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Compra updatedCompra = GetObjectFromInputs(compra.Id);
            compraService.Update(updatedCompra);
        }

        private void btnModificarPagos_Click(object sender, EventArgs e)
        {
            Compra? compra = dgvCompras.GetSelected<Compra>();
            if (compra is null)
            {
                MessageBox.Show("Debe seleccionar una compra para pagar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (compra.EstaPagado && MessageBox.Show("La compra ya está pagada. Desea continuar igualmente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            var context = contextFactory.CreateContext<PagoDbContext>(compra);
            PagarCompraForm form = new PagarCompraForm(context);
            form.ShowDialog();
        }

        private void btnModificarDetalles_Click(object sender, EventArgs e)
        {
            Compra? compra = dgvCompras.GetSelected<Compra>();
            if (compra is null)
            {
                MessageBox.Show("Debe seleccionar una compra para modificar los detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var context = contextFactory.CreateContext<DetalleCompraDbContext>(compra);
            DetallesCompraForm form = formFactoryService.CreateForm<DetallesCompraForm>(context);
            form.ShowDialog();
        }

        public void UpdateData()
        {
            FormHelper.UpdateControl(dgvCompras, compraService, ColumnsConfiguration);
        }

        public Compra GetObjectFromInputs(int id = -1)
        {
            return new Compra
            {
                Id = id,
                Fecha = dtpFecha.Value,
                MontoTotal = nudCostoTotal.Value,
                Proveedor = cboxTieneProveedor.Checked ? cmbProveedores.GetSelected<Proveedor>() : null
            };
        }
    }
}
