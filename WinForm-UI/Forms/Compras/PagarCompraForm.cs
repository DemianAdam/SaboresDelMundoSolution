using BLL.Compartido.Contracts;
using Entities.Transacciones;
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

namespace WinForm_UI.Forms.Compras
{
    public partial class PagarCompraForm : Form
    {
        private readonly IPagoContext pagoContext;
        public List<Pago> Pagos { get => pagoContext.GetAll(); }

        public PagarCompraForm(IPagoContext pagoContext)
        {
            InitializeComponent();
            this.pagoContext = pagoContext;
            pagoContext.OnOperationFinished += (s, e) => FormHelper.UpdateControl(dgvPagos, Pagos);
        }

        private void PagarCompraForm_Load(object sender, EventArgs e)
        {
            cmbTipoPago.DataSource = Enum.GetValues(typeof(TipoPago));
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Pago pago = new Pago
            {
                Cantidad = nudMonto.Value,
                Tipo = FormHelper.GetSelected<TipoPago>(cmbTipoPago),
                Fecha = DateTime.Now
            };



            try
            {
                pagoContext.Add(pago);
                //MessageBox.Show("Pago agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Pago? pago = dgvPagos.GetSelected<Pago>();
            if (pago is null)
            {
                MessageBox.Show("Por favor, seleccione un pago para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                pagoContext.Remove(pago);
               // MessageBox.Show("Pago eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Pago? pago = dgvPagos.GetSelected<Pago>();
            if (pago == null)
            {
                MessageBox.Show("Por favor, seleccione un pago para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pago.Cantidad = nudMonto.Value;
            pago.Tipo = FormHelper.GetSelected<TipoPago>(cmbTipoPago);
            pago.Fecha = DateTime.Now;
            try
            {
                pagoContext.Update(pago);
               // MessageBox.Show("Pago modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
