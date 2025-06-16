using BLL;
using BLL.Productos.Contracts;
using Entities;
using Mapper.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_UI.Helpers;

namespace WinForm_UI.Productos
{
    public partial class GestorSubProductos : Form
    {
        private readonly IProductoService productoService;
        private readonly ITipoProductoService tipoProductoService;
        private readonly Producto producto;
        private TabControl? tabControl;
        private List<NumericUpDown> numericUpDowns = new List<NumericUpDown>();
        public GestorSubProductos(IProductoService productoService, ITipoProductoService tipoProductoService, Producto producto)
        {
            InitializeComponent();
            this.productoService = productoService;
            this.tipoProductoService = tipoProductoService;
            this.producto = producto.Clone();
        }

        private void InitializeMainTableLayoutPanel(Producto producto)
        {
            if (producto is Promocion promocion && tabControl is null)
            {
                tabControl = InitializeTabControl(promocion);
                this.tlpParent.Controls.Remove(this.tlpAsignacionSubProductos);
                this.tlpParent.Controls.Add(tabControl, 0, 1);
            }
        }

        private TabControl InitializeTabControl(Promocion promocion)
        {
            TabControl tabControl = new TabControl();
            tabControl.TabPages.Add(new TabPage("Asignación de Subproductos") { Name = "tabAsignacionSubProductos" });
            tabControl.TabPages.Add(new TabPage("Asignacion de Promociones") { Name = "tabAsignacionPromociones" });
            tabControl.Dock = DockStyle.Fill;
            tabControl.TabPages["tabAsignacionSubProductos"]?.Controls.Add(this.tlpAsignacionSubProductos);
            Control control = InitializeAsignacionDePromociones(promocion);
            tabControl.TabPages["tabAsignacionPromociones"]?.Controls.Add(control);
            return tabControl;
        }

        private FlowLayoutPanel InitializeAsignacionDePromociones(Promocion promocion)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
            List<TipoProducto> tiposProductos = ((IGetAll<TipoProducto>)tipoProductoService).GetAll().Where(tp => tp.Tipo != "Promocion").ToList();
            foreach (var item in tiposProductos)
            {
                Panel panel = new Panel();
                panel.AutoSize = true;
                panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                Label label = new Label();
                label.Text = item.Tipo;
                label.Padding = new Padding { Top = 2 };
                NumericUpDown nud = new NumericUpDown();
                int? value = promocion.CantidadTipoProductos?.FirstOrDefault(kvp => kvp.TipoProducto.Id == item.Id)?.Cantidad;
                nud.Value = value ??= 0;
                nud.Tag = item;
                numericUpDowns.Add(nud);
                nud.Location = new Point(label.Location.X + label.Width + label.Margin.Right, label.Location.Y);

                panel.Controls.Add(label);
                panel.Controls.Add(nud);
                flowLayoutPanel.Controls.Add(panel);
            }

            return flowLayoutPanel;
        }

        private void LoadDGV()
        {
            dgvSubProductosAsignados.DataSource = null;
            dgvSubProductosDisponibles.DataSource = null;
            dgvSubProductosAsignados.DataSource = producto.SubProductos;
            dgvSubProductosDisponibles.DataSource = productoService.GetAvailableSubProducts(producto);
        }

        private void GestorSubProductos_Load(object sender, EventArgs e)
        {
            this.LoadDGV();
            this.txtNombre.Text = producto.Nombre;
            this.nudPrecio.Value = producto.Precio;
            FormHelper.UpdateControl(cmbTipoProducto, tipoProductoService);
            cmbTipoProducto.SelectedItem = cmbTipoProducto.Items
                .Cast<TipoProducto>()
                .FirstOrDefault(tp => tp.Id == producto.Tipo?.Id);
            InitializeMainTableLayoutPanel(producto);
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            var subProducto = dgvSubProductosDisponibles.GetSelected<Producto>();
            if (producto.SubProductos is null)
            {
                producto.SubProductos = new List<Producto>();
            }
            if (subProducto != null)
            {
                producto.SubProductos.Add(subProducto);
                this.LoadDGV();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            var subProducto = dgvSubProductosAsignados.GetSelected<Producto>();
            if (subProducto != null && producto.SubProductos is not null)
            {
                producto.SubProductos.Remove(subProducto);
                this.LoadDGV();
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            Producto updatedProducto;
            TipoProducto? tipoProducto = FormHelper.GetSelected<TipoProducto>(cmbTipoProducto);

            if (tipoProducto == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tipoProducto.Tipo == "Promocion")
            {
                Promocion promocion = producto.ToPromocion();
                ActualizarPromocion(promocion);
                updatedProducto = promocion;
            }
            else
            {
                updatedProducto = producto.Clone();
            }

            updatedProducto.Nombre = txtNombre.Text;
            updatedProducto.Precio = nudPrecio.Value;
            updatedProducto.Tipo = tipoProducto;

            productoService.Update(updatedProducto);
            MessageBox.Show("Producto actualizado correctamente", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ActualizarPromocion(Promocion promocion)
        {
            if (numericUpDowns.All(x => x.Value == 0))
            {
                return;
            }

            promocion.CantidadTipoProductos = new List<CantidadTipoProducto>();

            foreach (var item in numericUpDowns)
            {
                if (item.Tag is not TipoProducto tipoProducto)
                {
                    continue;
                }

                int cantidad = (int)item.Value;
                if (cantidad == 0)
                {
                    promocion.RemoveAllTipoProductoById(tipoProducto);
                }
                else
                {
                    promocion.AddOrUpdateTipoProducto(tipoProducto, cantidad);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTipoProducto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TipoProducto? tipoProducto = cmbTipoProducto.GetSelected<TipoProducto>();
            if (tipoProducto == null)
            {
                return;
            }

            if (tipoProducto.Tipo == "Promocion" && tabControl is null)
            {
                tabControl = InitializeTabControl(producto.ToPromocion());
                this.tlpParent.Controls.Remove(this.tlpAsignacionSubProductos);
                this.tlpParent.Controls.Add(tabControl, 0, 1);
            }
            else
            {
                if (tabControl != null)
                {
                    this.tlpParent.Controls.Remove(tabControl);
                    this.tlpParent.Controls.Add(this.tlpAsignacionSubProductos, 0, 1);
                    tabControl.Dispose();
                    tabControl = null;
                }
            }
        }
    }
}
