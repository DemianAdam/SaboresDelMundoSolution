using BLL.Compras.Contracts;
using BLL.Configuraciones.Contracts;
using BLL.Insumos.Contracts;
using Entities.Configuraciones;
using Entities.Insumos;
using Entities.Transacciones.Compras;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_UI.Events;
using WinForm_UI.Helpers;

namespace WinForm_UI.Forms.Compras
{
    public partial class DetallesCompraForm : Form
    {
        private readonly IInsumoService insumoService;
        private readonly IUnidadDeMedidaService unidadDeMedidaService;
        private readonly IEventBus eventBus;
        private readonly IDetalleCompraContext detalleCompraContext;
        public List<DetalleCompra> Detalles { get => detalleCompraContext.GetAll(); }
        public DetallesCompraForm(IInsumoService insumoService, IUnidadDeMedidaService unidadDeMedidaService, IEventBus eventBus, IDetalleCompraContext detalleCompraContext)
        {
            InitializeComponent();
            this.insumoService = insumoService;
            this.unidadDeMedidaService = unidadDeMedidaService;
            this.eventBus = eventBus;
            this.detalleCompraContext = detalleCompraContext;
            this.eventBus.Subscribe<UnidadDeMedidaChangedEvent>(UnidadDeMedidaChanged);
            detalleCompraContext.OnOperationFinished += DetalleCompraContext_OnOperationFinished;
        }

        private void DetalleCompraContext_OnOperationFinished(object? sender, EventArgs e)
        {
            FormHelper.UpdateControl(dgvDetalles, Detalles);
        }

        private void UnidadDeMedidaChanged(UnidadDeMedidaChangedEvent @event)
        {
            FormHelper.UpdateControl(cmbUnidadDeMedida, unidadDeMedidaService);
        }

        private void DetallesCompraForm_Load(object sender, EventArgs e)
        {
            Debug.WriteLine(this.Owner?.Name ?? "NULL");
            FormHelper.UpdateControl(cmbInsumo, insumoService);
            FormHelper.UpdateControl(cmbUnidadDeMedida, unidadDeMedidaService);
            FormHelper.UpdateControl(dgvDetalles, Detalles);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Insumo? insumo = FormHelper.GetSelected<Insumo>(cmbInsumo);
            UnidadDeMedida? unidad = FormHelper.GetSelected<UnidadDeMedida>(cmbUnidadDeMedida);
            if (insumo == null || unidad == null)
            {
                MessageBox.Show("Por favor, seleccione un insumo y una unidad de medida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DetalleCompra detalle = new DetalleCompra
            {
                Insumo = insumo,
                Unidad = unidad,
                Cantidad = nudCantidad.Value,
                Costo = nudCosto.Value
            };

            try
            {
                detalleCompraContext.Add(detalle);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DetalleCompra? detalle = dgvDetalles.GetSelected<DetalleCompra>();
            if (detalle is null)
            {
                MessageBox.Show("Por favor, seleccione un detalle para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                detalleCompraContext.Remove(detalle);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DetalleCompra? detalle = dgvDetalles.GetSelected<DetalleCompra>();
            if (detalle is null)
            {
                MessageBox.Show("Por favor, seleccione un detalle para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Insumo? insumo = FormHelper.GetSelected<Insumo>(cmbInsumo);
            UnidadDeMedida? unidad = FormHelper.GetSelected<UnidadDeMedida>(cmbUnidadDeMedida);
            if (insumo == null || unidad == null)
            {
                MessageBox.Show("Por favor, seleccione un insumo y una unidad de medida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            detalle.Insumo = insumo;
            detalle.Unidad = unidad;
            detalle.Cantidad = nudCantidad.Value;
            detalle.Costo = nudCosto.Value;
            try
            {
                detalleCompraContext.Update(detalle);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.eventBus.Unsubscribe<UnidadDeMedidaChangedEvent>(UnidadDeMedidaChanged);
            base.OnFormClosed(e);
        }
    }
}
