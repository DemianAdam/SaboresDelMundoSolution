using BLL.Configuraciones.Contracts;
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

namespace WinForm_UI.Configuraciones
{
    public partial class GestorUnidadDeMedida : Form
    {
        private readonly IUnidadDeMedidaService unidadDeMedidaService;
        private readonly IEventBus eventBus;
        public GestorUnidadDeMedida(IUnidadDeMedidaService unidadDeMedidaService, IEventBus eventBus)
        {
            InitializeComponent();
            this.unidadDeMedidaService = unidadDeMedidaService;
            this.eventBus = eventBus;
            this.unidadDeMedidaService.OnOperationFinished += UnidadDeMedidaService_OnOperationFinished;
        }

        private void UnidadDeMedidaService_OnOperationFinished(object? sender, EventArgs e)
        {
            ActualizarUnidadDeMedidaGrid();
        }

        private void ActualizarUnidadDeMedidaGrid()
        {
            FormHelper.UpdateControl(dgvUnidadDeMedida, unidadDeMedidaService);
        }

        private void GestorUnidadDeMedida_Load(object sender, EventArgs e)
        {
            ActualizarUnidadDeMedidaGrid();
        }

        private void dgvUnidadDeMedida_SelectionChanged(object sender, EventArgs e)
        {
            txtTipo.Text = dgvUnidadDeMedida.GetSelected<UnidadDeMedida>()?.Unidad;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                MessageBox.Show("Debe ingresar un tipo de unidad de medida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var unidadDeMedida = new UnidadDeMedida { Unidad = txtTipo.Text };
                unidadDeMedidaService.Insert(unidadDeMedida);
                txtTipo.Clear();
                eventBus.Publish(new UnidadDeMedidaChangedEvent(unidadDeMedida, ActionType.Add));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la unidad de medida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var unidadDeMedida = dgvUnidadDeMedida.GetSelected<UnidadDeMedida>();
            if (unidadDeMedida == null)
            {
                MessageBox.Show("Debe seleccionar una unidad de medida para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                MessageBox.Show("Debe ingresar un tipo de unidad de medida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                unidadDeMedida.Unidad = txtTipo.Text;
                unidadDeMedidaService.Update(unidadDeMedida);
                txtTipo.Clear();
                eventBus.Publish(new UnidadDeMedidaChangedEvent(unidadDeMedida, ActionType.Update));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la unidad de medida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var unidadDeMedida = dgvUnidadDeMedida.GetSelected<UnidadDeMedida>();
            if (unidadDeMedida == null)
            {
                MessageBox.Show("Debe seleccionar una unidad de medida para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show($"¿Está seguro que desea eliminar la unidad de medida '{unidadDeMedida.Unidad}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                unidadDeMedidaService.Remove(unidadDeMedida);
                txtTipo.Clear();
                eventBus.Publish(new UnidadDeMedidaChangedEvent(unidadDeMedida, ActionType.Remove));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la unidad de medida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
