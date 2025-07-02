using BLL.Configuraciones.Contracts;
using BLL.Ingredientes.Context;
using BLL.Ingredientes.Contracts;
using Entities.Compartido;
using Entities.Configuraciones;
using Entities.Ingredientes;
using Interfaces;
using WinForm_UI.Contracts;
using WinForm_UI.Helpers;

namespace WinForm_UI.Forms.Ingredientes
{
    public partial class GestorRecetas : Form, IDataForm<Receta>, IGetInput<Peso>
    {
        private readonly IRecetaService recetaService;
        private readonly IContextFactory contextFactory;
        private readonly IFormFactoryService formFactoryService;
        private readonly IUnidadDeMedidaService unidadDeMedidaService;

        public List<ColumnConfiguration> ColumnsConfiguration => new List<ColumnConfiguration>
        {
            new ColumnConfiguration(nameof(Receta.Nombre), 0),
            new ColumnConfiguration(nameof(Receta.Descripcion), 1),
            new ColumnConfiguration(nameof(Receta.Peso), 2),
            new ColumnConfiguration(nameof(Receta.Porciones), 3)
        };

        private List<Receta> recetas => recetaService.GetAll();

        public GestorRecetas(IRecetaService recetaService, IContextFactory contextFactory, IFormFactoryService formFactoryService, IUnidadDeMedidaService unidadDeMedidaService)
        {
            InitializeComponent();
            this.recetaService = recetaService;
            this.contextFactory = contextFactory;
            this.formFactoryService = formFactoryService;
            this.unidadDeMedidaService = unidadDeMedidaService;
            this.recetaService.OnOperationFinished += RecetaService_OnOperationFinished;
        }

        private void RecetaService_OnOperationFinished(object? sender, EventArgs e)
        {
            UpdateData();
        }

        private void GestorRecetas_Load(object sender, EventArgs e)
        {
            UpdateData();
            FormHelper.UpdateControl(cmbUnidadDeMedida, unidadDeMedidaService, nameof(UnidadDeMedida.Unidad));
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
                this.recetaService.Insert(receta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la receta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Receta? GetObjectFromInputs(int id = -1)
        {
            Peso? peso = (this as IGetInput<Peso>).GetObjectFromInputs();

            if (peso is null)
            {
                return null;
            }

            Receta receta = new Receta
            {
                Id = id,
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.GetNullableText(),
                Peso = peso,
                Porciones = (int)nudPorciones.Value

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
                this.recetaService.Remove(receta);
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
                this.recetaService.Update(updatedReceta);
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
            var context = contextFactory.CreateContext<RecetaCantidadDbContext>(receta);
            RecetaCantidadesForm form = formFactoryService.CreateForm<RecetaCantidadesForm>(context);
            form.ShowDialog();
        }

        public void UpdateData()
        {
            FormHelper.UpdateControl(dgvRecetas, recetas, ColumnsConfiguration);
        }

        Peso? IGetInput<Peso>.GetObjectFromInputs(int id)
        {
            UnidadDeMedida? unidadDeMedida = FormHelper.GetSelected<UnidadDeMedida>(cmbUnidadDeMedida);
            if (unidadDeMedida is null)
            {
                MessageBox.Show("Por favor, seleccione una unidad de medida válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new Peso
            {
                UnidadDeMedida = unidadDeMedida,
                Valor = nudPesoAproximado.Value
            };
        }
    }
}
