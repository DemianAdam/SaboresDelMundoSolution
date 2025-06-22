using BLL.Compras.Contracts;
using Entities;
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

namespace WinForm_UI.Forms.Compras
{
    public partial class GestorProveedores : Form
    {
        private readonly IProveedorService proveedorService;
        private readonly IEventBus eventBus;

        public GestorProveedores(IProveedorService proveedorService, IEventBus eventBus)
        {
            InitializeComponent();
            this.proveedorService = proveedorService;
            this.eventBus = eventBus;
            this.proveedorService.OnOperationFinished += ProveedorService_OnOperationFinished;
        }

        private void ProveedorService_OnOperationFinished(object? sender, EventArgs e)
        {
            ActualizarProveedores();
        }

        private void ActualizarProveedores()
        {
            FormHelper.UpdateControl(dgvProveedores, proveedorService);
        }

        private void GestorProveedores_Load(object sender, EventArgs e)
        {
            ActualizarProveedores();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor
            {
                Nombre = txtNombre.Text,
            };
            try
            {
                proveedorService.Insert(proveedor);
                txtNombre.Clear();
                this.eventBus.Publish(new ProveedorChangedEvent(proveedor, ActionType.Add));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el proveedor: {ex.Message}");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Proveedor? proveedor = FormHelper.GetSelected<Proveedor>(dgvProveedores);
            if (proveedor is null)
            {
                MessageBox.Show("Por favor, seleccione un proveedor para modificar.");
                return;
            }
            proveedor.Nombre = txtNombre.Text;
            try
            {
                proveedorService.Update(proveedor);
                this.eventBus.Publish(new ProveedorChangedEvent(proveedor, ActionType.Update));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el proveedor: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Proveedor? proveedor = FormHelper.GetSelected<Proveedor>(dgvProveedores);
            if (proveedor is null)
            {
                MessageBox.Show("Por favor, seleccione un proveedor para eliminar.");
                return;
            }
            try
            {
                proveedorService.Remove(proveedor);
                this.eventBus.Publish(new ProveedorChangedEvent(proveedor, ActionType.Remove));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el proveedor: {ex.Message}");
            }
        }
    }
}
