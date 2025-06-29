using BLL.Productos.Contracts;
using Entities.Productos;
using Interfaces;
using System.Data;
using WinForm_UI.Contracts;
using WinForm_UI.Events;
using WinForm_UI.Helpers;

namespace WinForm_UI.Productos
{
    public partial class GestorProductos : Form
    {
        private readonly IEventBus eventBus;
        private readonly IProductoService productoService;
        private readonly ITipoProductoService tipoProductoService;
        private readonly IFormFactoryService formFactoryService;

        public GestorProductos(IEventBus eventBus,IProductoService productoService, ITipoProductoService tipoProductoService, IFormFactoryService formFactoryService)
        {
            InitializeComponent();
            this.eventBus = eventBus;
            this.productoService = productoService;
            this.tipoProductoService = tipoProductoService;
            this.formFactoryService = formFactoryService;
            this.eventBus.Subscribe<TipoProductoChangedEvent>(OnProductoChanged);
            this.productoService.OnOperationFinished += Service_OnOperationFinished;
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.eventBus.Unsubscribe<TipoProductoChangedEvent>(OnProductoChanged);
            base.OnFormClosed(e);
        }

        private void OnProductoChanged(TipoProductoChangedEvent @event)
        {
            ActualizarTiposProductos();
        }

        private void Service_OnOperationFinished(object? sender, EventArgs e)
        {
            ActualizarProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            TipoProducto? tipoProducto = cmbTipoProducto.GetSelected<TipoProducto>();

            if (tipoProducto is null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de producto.");
                return;
            }

            Producto producto = new Producto
            {
                Nombre = txtNombre.Text,
                Precio = nudPrecio.Value,
                SubProductos = ObtenerProductosSeleccionados(),
                Tipo = tipoProducto
            };

            productoService.Insert(producto);
        }

        private List<Producto> ObtenerProductosSeleccionados()
        {
            return dgvProductos.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => row.DataBoundItem)
                .OfType<Producto>()
                .ToList();
        }

        private void CrearProducto_Load(object sender, EventArgs e)
        {
            ActualizarProductos();
            ActualizarTiposProductos();
        }
        public void ActualizarProductos()
        {
            FormHelper.UpdateControl<Producto>(dgvProductos, productoService);
        }

        private void ActualizarTiposProductos()
        {
            FormHelper.UpdateControl<TipoProducto>(cmbTipoProducto, tipoProductoService);
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvProductos.SelectedRows.Count == 1)
            {
                Producto? productoSeleccionado = this.dgvProductos.SelectedRows[0].DataBoundItem as Producto;
                this.dgvSubProductos.DataSource = productoSeleccionado?.SubProductos;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto? producto = dgvProductos.GetSelected<Producto>();

            if (producto != null)
            {
                productoService.Remove(producto);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Producto? producto = dgvProductos.GetSelected<Producto>();

            if (producto != null)
            {
                GestorSubProductos gestorSubProductos = formFactoryService.CreateForm<GestorSubProductos>(productoService, producto);
                gestorSubProductos.ShowDialog();
            }
        }
    }
}
