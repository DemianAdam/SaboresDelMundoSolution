using Entities;
using WinForm_UI.Helpers;
using WinForm_UI.Productos;
using WinForm_UI.Forms.Insumos;
using WinForm_UI.Configuraciones;
using WinForm_UI.Forms.Compras;
using WinForm_UI.Contracts;
using WinForm_UI.Forms.Ingredientes;

namespace WinForm_UI
{
    public partial class Principal : Form
    {
        private readonly IFormFactoryService formFactoryService;

        public Principal(IFormFactoryService formFactoryService)
        {
            InitializeComponent();
            this.formFactoryService = formFactoryService;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            timerClock.Start();
            slblTime.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm-ss");
        }

        private void gestorProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestorProductos gestorProductos = formFactoryService.CreateForm<GestorProductos>();
            this.AddMdiChild(gestorProductos);
        }

        private void tiposDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestorTipoProducto gestorTipoProductos = formFactoryService.CreateForm<GestorTipoProducto>();
            gestorTipoProductos.ShowDialog();
        }

        private void gestorInsumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestorInsumos gestorInsumos = formFactoryService.CreateForm<GestorInsumos>();
            this.AddMdiChild(gestorInsumos);
        }

        private void tiposDeInsumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestorTipoInsumo gestorTipoInsumo = formFactoryService.CreateForm<GestorTipoInsumo>();
            gestorTipoInsumo.ShowDialog();
        }

        private void unidadesDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestorUnidadDeMedida gestorUnidadesMedida = formFactoryService.CreateForm<GestorUnidadDeMedida>();
            this.AddMdiChild(gestorUnidadesMedida);
        }

        private void gestorComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestorCompras gestorCompras = formFactoryService.CreateForm<GestorCompras>();
            this.AddMdiChild(gestorCompras);
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            slblTime.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm-ss");
        }

        private void gestorProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestorProveedores gestorProveedores = formFactoryService.CreateForm<GestorProveedores>();
            this.AddMdiChild(gestorProveedores);
        }

        private void gestorDeRecetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestorRecetas gestorRecetas = formFactoryService.CreateForm<GestorRecetas>();
            this.AddMdiChild(gestorRecetas);
        }

        private void conversionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestorConversiones gestorConversiones = formFactoryService.CreateForm<GestorConversiones>();
            this.AddMdiChild(gestorConversiones);
        }
    }
}
