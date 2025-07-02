using BLL.Compras.Contracts;
using BLL.Configuraciones.Contracts;
using BLL.Insumos.Contracts;
using Entities.Compartido;
using Entities.Configuraciones;
using Entities.Insumos;
using Entities.Transacciones.Compras;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_UI.Contracts;
using WinForm_UI.Events;
using WinForm_UI.Helpers;

namespace WinForm_UI.Forms.Compras
{
    public partial class DetallesCompraForm : Form, IDataForm<DetalleCompra>, IGetInput<Peso>, IGetInput<Insumo>
    {
        private readonly IInsumoService insumoService;
        private readonly IUnidadDeMedidaService unidadDeMedidaService;
        private readonly IEventBus eventBus;
        private readonly IDetalleCompraContext detalleCompraContext;
        public List<DetalleCompra> Detalles { get => detalleCompraContext.GetAll(); }

        public List<ColumnConfiguration> ColumnsConfiguration =>
            new List<ColumnConfiguration>
            {
                new ColumnConfiguration(nameof(DetalleCompra.Insumo), 0),
                new ColumnConfiguration(nameof(DetalleCompra.Peso), 1),
                new ColumnConfiguration(nameof(DetalleCompra.Costo), 2)
            };

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
            UpdateData();
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
            Insumo? insumo = (this as IGetInput<Insumo>)?.GetObjectFromInputs();
            Peso? peso = (this as IGetInput<Peso>)?.GetObjectFromInputs();
            if (insumo is null || peso is null)
            {
                return;
            }

            DetalleCompra detalle = new DetalleCompra
            {
                Insumo = insumo,
                Peso = peso,
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
            Peso? peso = (this as IGetInput<Peso>)?.GetObjectFromInputs(detalle.Id);
            Insumo? insumo = (this as IGetInput<Insumo>)?.GetObjectFromInputs(detalle.Insumo.Id);
            if (peso is null || insumo is null)
            {
                return;
            }

            detalle.Insumo = insumo;
            detalle.Peso = peso;
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


        public void UpdateData()
        {
            FormHelper.UpdateControl(dgvDetalles, Detalles,ColumnsConfiguration);
        }

        public DetalleCompra? GetObjectFromInputs(int id = -1)
        {
            Insumo? insumo = (this as IGetInput<Insumo>)?.GetObjectFromInputs();
            Peso? peso = (this as IGetInput<Peso>)?.GetObjectFromInputs();
            if (peso is null || insumo is null)
            {
                return null;
            }

            return new DetalleCompra
            {
                Id = id,
                Insumo = insumo,
                Peso = peso,
                Costo = nudCosto.Value
            };
        }

        Peso? IGetInput<Peso>.GetObjectFromInputs(int id)
        {
            UnidadDeMedida? unidadDeMedida = FormHelper.GetSelected<UnidadDeMedida>(cmbUnidadDeMedida);
            if (unidadDeMedida == null)
            {
                MessageBox.Show("Por favor, seleccione una unidad de medida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            Peso peso = new Peso
            {
                Valor = nudCantidad.Value,
                UnidadDeMedida = unidadDeMedida
            };
            return peso;
        }

        Insumo? IGetInput<Insumo>.GetObjectFromInputs(int id)
        {
            Insumo? insumo = FormHelper.GetSelected<Insumo>(cmbInsumo);
            if (insumo is null)
            {
                MessageBox.Show("Por favor, seleccione un insumo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return insumo;
        }
    }
}
