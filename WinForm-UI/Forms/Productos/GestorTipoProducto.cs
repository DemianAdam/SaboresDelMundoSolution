using BLL.Productos.Contracts;
using Entities.Productos;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_UI.Events;
using WinForm_UI.Helpers;

namespace WinForm_UI.Productos
{
    public partial class GestorTipoProducto : Form
    {
        private readonly IEventBus eventBus;
        private readonly ITipoProductoService service;

        public GestorTipoProducto(IEventBus eventBus, ITipoProductoService service)
        {
            InitializeComponent();
            this.eventBus = eventBus;
            this.service = service;
            this.service.OnOperationFinished += Service_OnOperationFinished;
        }

        private void Service_OnOperationFinished(object? sender, EventArgs e)
        {
            FormHelper.UpdateControl<TipoProducto>(dgvTipoProducto, service);
        }

        private void GestorTipoProducto_Load(object sender, EventArgs e)
        {
            FormHelper.UpdateControl<TipoProducto>(dgvTipoProducto, service);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            TipoProducto tipoProducto = new TipoProducto()
            {
                Tipo = txtTipo.Text,
            };

            try
            {
                service.Insert(tipoProducto);
                this.eventBus.Publish(new TipoProductoChangedEvent(tipoProducto, ActionType.Add));
            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar el tipo de producto. Por favor, intente nuevamente.");
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            TipoProducto? tipoProducto = dgvTipoProducto.GetSelected<TipoProducto>();
            if (tipoProducto is null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de producto para modificar.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                MessageBox.Show("El campo 'Tipo' no puede estar vacío.");
                return;
            }

            tipoProducto.Tipo = txtTipo.Text;

            try
            {
                service.Update(tipoProducto);
                this.eventBus.Publish(new TipoProductoChangedEvent(tipoProducto, ActionType.Update));
            }
            catch (Exception)
            {
                MessageBox.Show("Error al modificar el tipo de producto. Por favor, intente nuevamente.");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            TipoProducto? tipoProducto = dgvTipoProducto.GetSelected<TipoProducto>();
            if (tipoProducto is null)
            {
                return;
            }

            try
            {
                service.Remove(tipoProducto);
                this.eventBus.Publish(new TipoProductoChangedEvent(tipoProducto, ActionType.Remove));
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void dgvTipoProducto_SelectionChanged(object sender, EventArgs e)
        {
            TipoProducto? tipoProducto = dgvTipoProducto.GetSelected<TipoProducto>();
            if (tipoProducto is not null)
            {
                txtTipo.Text = tipoProducto.Tipo;
            }
            else
            {
                txtTipo.Text = string.Empty;
            }
        }
    }
}
