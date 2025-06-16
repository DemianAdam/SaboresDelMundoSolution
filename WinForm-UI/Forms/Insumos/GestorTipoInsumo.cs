using BLL.Insumos.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_UI.Contracts;
using WinForm_UI.Events;
using WinForm_UI.Helpers;

namespace WinForm_UI.Forms.Insumos
{
    public partial class GestorTipoInsumo : Form
    {
        private readonly ITipoInsumoService tipoInsumoService;
        private readonly IEventBus eventBus;

        public GestorTipoInsumo(ITipoInsumoService tipoInsumoService, IEventBus eventBus)
        {
            InitializeComponent();
            this.tipoInsumoService = tipoInsumoService;
            this.eventBus = eventBus;
            this.tipoInsumoService.OnOperationFinished += TipoInsumoService_OnOperationFinished;
        }

        private void TipoInsumoService_OnOperationFinished(object? sender, EventArgs e)
        {
            FormHelper.UpdateControl<TipoInsumo>(dgvTipoInsumo, tipoInsumoService);
        }

        private void GestorTipoInsumo_Load(object sender, EventArgs e)
        {
            FormHelper.UpdateControl<TipoInsumo>(dgvTipoInsumo, tipoInsumoService);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            TipoInsumo tipoInsumo = new TipoInsumo()
            {
                Tipo = txtTipo.Text,
            };
            try
            {
                tipoInsumoService.Insert(tipoInsumo);
                eventBus.Publish(new TipoInsumoChangedEvent(tipoInsumo, ActionType.Add));
            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar el tipo de insumo. Por favor, intente nuevamente.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            TipoInsumo? tipoInsumo = dgvTipoInsumo.GetSelected<TipoInsumo>();
            if (tipoInsumo is null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de insumo para modificar.");
                return;
            }
            tipoInsumo.Tipo = txtTipo.Text;
            try
            {
                tipoInsumoService.Update(tipoInsumo);
                eventBus.Publish(new TipoInsumoChangedEvent(tipoInsumo, ActionType.Update));
            }
            catch (Exception)
            {
                MessageBox.Show("Error al modificar el tipo de insumo. Por favor, intente nuevamente.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            TipoInsumo? tipoInsumo = dgvTipoInsumo.GetSelected<TipoInsumo>();
            if (tipoInsumo is null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de insumo para eliminar.");
                return;
            }
            try
            {
                tipoInsumoService.Remove(tipoInsumo);
                eventBus.Publish(new TipoInsumoChangedEvent(tipoInsumo, ActionType.Remove));
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el tipo de insumo. Por favor, intente nuevamente.");
            }
        }

        private void dgvTipoInsumo_SelectionChanged(object sender, EventArgs e)
        {
            TipoInsumo? tipoInsumo = dgvTipoInsumo.GetSelected<TipoInsumo>();
            if (tipoInsumo is not null)
            {
                txtTipo.Text = tipoInsumo.Tipo;
            }
            else
            {
                txtTipo.Clear();
            }
        }
    }
}
