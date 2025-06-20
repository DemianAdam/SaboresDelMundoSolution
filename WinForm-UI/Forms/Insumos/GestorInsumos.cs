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
    public partial class GestorInsumos : Form, IGetInput<Insumo>
    {
        private readonly IInsumoService insumoService;
        private readonly ITipoInsumoService tipoInsumoService;
        private readonly IEventBus eventBus;

        public GestorInsumos(IInsumoService insumoService, ITipoInsumoService tipoInsumoService, IEventBus eventBus)
        {
            InitializeComponent();
            this.insumoService = insumoService;
            this.tipoInsumoService = tipoInsumoService;
            this.eventBus = eventBus;
            this.eventBus.Subscribe<TipoInsumoChangedEvent>(TipoInsumoChanged);
            this.insumoService.OnOperationFinished += (s, e) => FormHelper.UpdateControl(dgvInsumos, insumoService);

        }

        private void TipoInsumoChanged(TipoInsumoChangedEvent @event)
        {
            ActualizarTiposInsumos();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.eventBus.Unsubscribe<TipoInsumoChangedEvent>(TipoInsumoChanged);
            base.OnFormClosed(e);
        }

        private void ActualizarTiposInsumos()
        {
            FormHelper.UpdateControl(cmbTipo, tipoInsumoService);
        }

        private void GestorInsumos_Load(object sender, EventArgs e)
        {
            ActualizarTiposInsumos();
            FormHelper.UpdateControl(dgvInsumos, insumoService);

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Insumo? insumo = GetObjectFromInputs();
            if (insumo is null)
            {
                return;
            }

            try
            {
                insumoService.Insert(insumo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el insumo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Insumo? insumo = dgvInsumos.GetSelected<Insumo>();
            if (insumo is null)
            {
                MessageBox.Show("Por favor, seleccione un insumo a modificar.");
                return;
            }
            TipoInsumo? tipoInsumo = cmbTipo.GetSelected<TipoInsumo>();
            if (tipoInsumo is null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de insumo.");
                return;
            }
            insumo = GetObjectFromInputs(insumo.Id);

            if (insumo is not null)
            {
                insumoService.Update(insumo);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Insumo? insumo = dgvInsumos.GetSelected<Insumo>();
            if (insumo is null)
            {
                MessageBox.Show("Por favor, seleccione un insumo a eliminar.");
                return;
            }
            var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este insumo?", "Confirmar eliminación", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                insumoService.Remove(insumo);
            }
        }

        private void dgvInsumos_SelectionChanged(object sender, EventArgs e)
        {
            Insumo? insumo = dgvInsumos.GetSelected<Insumo>();
            if (insumo != null)
            {
                txtNombre.Text = insumo.Nombre;
                txtDescripcion.Text = insumo.Descripcion;
                cmbTipo.SelectedItem = cmbTipo.Items.Cast<TipoInsumo>().FirstOrDefault(t => t.Id == insumo.Tipo.Id);
            }
            else
            {
                txtNombre.Clear();
                txtDescripcion.Clear();
                cmbTipo.SelectedIndex = -1;
            }
        }

        public Insumo? GetObjectFromInputs(int id = -1)
        {
            string nombre = txtNombre.Text.Trim();
            string? descripcion = txtDescripcion.GetNullableText();
            TipoInsumo? tipoInsumo = cmbTipo.GetSelected<TipoInsumo>();

            if (string.IsNullOrEmpty(nombre) || tipoInsumo is null)
            {
                MessageBox.Show("El nombre y el tipo de insumo son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new Insumo
            {
                Id = id,
                Nombre = nombre,
                Descripcion = descripcion,
                Tipo = tipoInsumo
            };
        }
    }
}
