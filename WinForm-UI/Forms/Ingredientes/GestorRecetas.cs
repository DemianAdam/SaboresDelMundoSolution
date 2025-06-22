using BLL;
using BLL.Ingredientes.Context;
using BLL.Ingredientes.Contracts;
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
using WinForm_UI.Contracts;
using WinForm_UI.Helpers;

namespace WinForm_UI.Forms.Ingredientes
{
    public partial class GestorRecetas : Form, IGetInput<Receta>
    {
        private readonly IIngredienteService ingredienteService;
        private readonly IRecetaService recetaService;
        private readonly IContextFactory contextFactory;
        private readonly IFormFactoryService formFactoryService;

        private List<Receta> recetas => recetaService.GetAll();
        public GestorRecetas(IIngredienteService ingredienteService, IRecetaService recetaService, IContextFactory contextFactory, IFormFactoryService formFactoryService)
        {
            InitializeComponent();
            this.ingredienteService = ingredienteService;
            this.recetaService = recetaService;
            this.contextFactory = contextFactory;
            this.formFactoryService = formFactoryService;
            this.ingredienteService.OnOperationFinished += (s, e) => FormHelper.UpdateControl(dgvRecetas, recetas);
        }

        private void GestorRecetas_Load(object sender, EventArgs e)
        {
            FormHelper.UpdateControl(dgvRecetas, recetas);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Receta? receta = GetObjectFromInputs();
            if (receta is null)
            {
                return;
            }

            try
            {
                this.ingredienteService.Insert(receta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la receta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Receta? GetObjectFromInputs(int id = -1)
        {
            Receta receta = new Receta
            {
                Id = id,
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.GetNullableText()
            };
            if (receta.Nombre == string.Empty)
            {
                MessageBox.Show("El nombre de la receta no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return receta;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Receta? receta = dgvRecetas.GetSelected<Receta>();
            if (receta is null)
            {
                MessageBox.Show("Por favor, seleccione una receta a eliminar.");
                return;
            }
            try
            {
                this.ingredienteService.Remove(receta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la receta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Receta? receta = dgvRecetas.GetSelected<Receta>();
            if (receta is null)
            {
                MessageBox.Show("Por favor, seleccione una receta a modificar.");
                return;
            }
            Receta? updatedReceta = GetObjectFromInputs(receta.Id);
            if (updatedReceta is null)
            {
                return;
            }
            try
            {
                this.ingredienteService.Update(updatedReceta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la receta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarIngredientes_Click(object sender, EventArgs e)
        {
            Receta? receta = dgvRecetas.GetSelected<Receta>();
            if (receta is null)
            {
                MessageBox.Show("Por favor, seleccione una receta para modificar sus ingredientes.");
                return;
            }
            var context = contextFactory.CreateInstance<RecetaCantidadDbContext>(receta);
            RecetaCantidadesForm form = formFactoryService.CreateForm<RecetaCantidadesForm>(context);
            form.ShowDialog();
        }
    }
}
