using BLL.Configuraciones.Contracts;
using BLL.Insumos.Contracts;
using DAL.Configuraciones.Contracts;
using Entities;
using WinForm_UI.Contracts;
using WinForm_UI.Helpers;

namespace WinForm_UI.Forms.Insumos
{
    public partial class GestorConversiones : Form, IGetInput<Conversion>
    {
        private readonly IConversionService conversionService;
        private readonly IInsumoService insumoService;
        private readonly IUnidadDeMedidaService unidadDeMedidaService;

        public GestorConversiones(IConversionService conversionService, IInsumoService insumoService, IUnidadDeMedidaService unidadDeMedidaService)
        {
            InitializeComponent();
            this.conversionService = conversionService;
            this.insumoService = insumoService;
            this.unidadDeMedidaService = unidadDeMedidaService;
            this.conversionService.OnOperationFinished += (sender, e) => FormHelper.UpdateControl(dgvConversiones, conversionService);
            this.cmbUnidadDeMedidaFrom.SelectedIndexChanged += (sender, e) => ActualizarComboboxUnidadDeMedida();
        }

        public Conversion? GetObjectFromInputs(int id = -1)
        {
            Insumo? insumo = FormHelper.GetSelected<Insumo>(cmbInsumo);
            UnidadDeMedida? unidadDeMedidaFrom = FormHelper.GetSelected<UnidadDeMedida>(cmbUnidadDeMedidaFrom);
            decimal cantidadFrom = nudCantidadFrom.Value;
            UnidadDeMedida? unidadDeMedidaTo = FormHelper.GetSelected<UnidadDeMedida>(cmbUnidadDeMedidaTo);
            decimal cantidadTo = nudCantidadTo.Value;

            if (insumo == null || unidadDeMedidaFrom == null || unidadDeMedidaTo == null || cantidadFrom <= 0 || cantidadTo <= 0)
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new Conversion(id, insumo, unidadDeMedidaFrom, cantidadFrom, unidadDeMedidaTo, cantidadTo);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conversion? conversion = GetObjectFromInputs();
            if (conversion is null)
            {
                return;
            }

            try
            {
                conversionService.Insert(conversion);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la conversión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GestorConversiones_Load(object sender, EventArgs e)
        {
            FormHelper.UpdateControl(cmbInsumo, insumoService, nameof(Insumo.Nombre));
            FormHelper.UpdateControl(cmbUnidadDeMedidaFrom, unidadDeMedidaService, nameof(UnidadDeMedida.Unidad));
            ActualizarComboboxUnidadDeMedida();
            FormHelper.UpdateControl(dgvConversiones, conversionService);
        }

        private void ActualizarComboboxUnidadDeMedida()
        {
            UnidadDeMedida? selectedUnidadDeMedida = cmbUnidadDeMedidaTo.GetSelected<UnidadDeMedida>();
            UnidadDeMedida? selectedFrom = cmbUnidadDeMedidaFrom.GetSelected<UnidadDeMedida>();
            List<UnidadDeMedida> unidades = unidadDeMedidaService.GetAll();

            FormHelper.UpdateControl(cmbUnidadDeMedidaTo, unidades.Where(u => u.Id != selectedFrom?.Id).ToList(), nameof(UnidadDeMedida.Unidad));

            if (selectedUnidadDeMedida?.Id != selectedFrom?.Id)
            {
                cmbUnidadDeMedidaTo.SelectedItem = cmbUnidadDeMedidaTo.Items.Cast<UnidadDeMedida>().FirstOrDefault(u => u.Id == selectedUnidadDeMedida?.Id);
            }
        }
    }
}
