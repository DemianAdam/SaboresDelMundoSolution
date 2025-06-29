using BLL.Configuraciones.Contracts;
using BLL.Ingredientes.Contracts;
using Entities.Configuraciones;
using Entities.Ingredientes;
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
    public partial class RecetaCantidadesForm : Form, IGetInput<CantidadIngrediente>
    {
        private readonly IRecetaService recetaService;
        private readonly IRecetaCantidadContext recetaCantidadContext;
        private readonly IUnidadDeMedidaService unidadDeMedidaService;

        public List<CantidadIngrediente> CantidadIngredientes { get => recetaCantidadContext.GetAll(); }
        public List<ComponenteReceta> ComponentesDisponibles { get => recetaService.GetAvailableIngredientes(recetaCantidadContext.Receta); }
        public RecetaCantidadesForm(IRecetaService recetaService, IRecetaCantidadContext recetaCantidadContext, IUnidadDeMedidaService unidadDeMedidaService)
        {
            InitializeComponent();
            this.recetaService = recetaService;
            this.recetaCantidadContext = recetaCantidadContext;
            this.unidadDeMedidaService = unidadDeMedidaService;
            recetaCantidadContext.OnOperationFinished += (s, e) => FormHelper.UpdateControl(dgvIngredientes, CantidadIngredientes);
        }

        private void RecetaCantidadesForm_Load(object sender, EventArgs e)
        {
            FormHelper.UpdateControl(dgvIngredientes, CantidadIngredientes);
            FormHelper.UpdateControl(cmbComponenteReceta, ComponentesDisponibles, nameof(Component.ToString));
            FormHelper.UpdateControl(cmbUnidadDeMedida, unidadDeMedidaService, nameof(UnidadDeMedida.Unidad));
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CantidadIngrediente? cantidadIngrediente = GetObjectFromInputs();
            if (cantidadIngrediente is null)
            {
                return;
            }

            recetaCantidadContext.Add(cantidadIngrediente);
        }

        public CantidadIngrediente? GetObjectFromInputs(int id = -1)
        {
            ComponenteReceta? componenteReceta = cmbComponenteReceta.GetSelected<ComponenteReceta>();
            UnidadDeMedida? unidadDeMedida = cmbUnidadDeMedida.GetSelected<UnidadDeMedida>();
            if (componenteReceta is null || unidadDeMedida is null)
            {
                MessageBox.Show("Debe seleccionar un componenteReceta y una unidad de medida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            CantidadIngrediente cantidadIngrediente = new CantidadIngrediente
            {
                Id = id,
                ComponenteReceta = componenteReceta.Clone(),
                Cantidad = nudCantidad.Value,
                UnidadDeMedida = unidadDeMedida.Clone(),
                DesperdicioAceptado = nudDesperdicioAceptado.Value,
                Costo = componenteReceta is Receta receta
                    ? receta.CostoUnitario * nudCantidad.Value
                    : 0 // Assuming costo is calculated differently for other types of ComponenteReceta
            };

            return cantidadIngrediente;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CantidadIngrediente? cantidadIngrediente = dgvIngredientes.GetSelected<CantidadIngrediente>();
            if (cantidadIngrediente is null)
            {
                MessageBox.Show("Debe seleccionar una cantidad de componenteReceta para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            recetaCantidadContext.Remove(cantidadIngrediente);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            CantidadIngrediente? cantidadIngrediente = dgvIngredientes.GetSelected<CantidadIngrediente>();
            if (cantidadIngrediente is null)
            {
                MessageBox.Show("Debe seleccionar una cantidad de componenteReceta para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CantidadIngrediente? updatedCantidad = GetObjectFromInputs(cantidadIngrediente.Id);
            if (updatedCantidad is null)
            {
                return;
            }
            recetaCantidadContext.Update(updatedCantidad);
        }
    }
}
