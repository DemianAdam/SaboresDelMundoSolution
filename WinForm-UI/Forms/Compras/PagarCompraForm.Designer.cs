namespace WinForm_UI.Forms.Compras
{
    partial class PagarCompraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nudMonto = new NumericUpDown();
            this.label1 = new Label();
            this.cmbTipoPago = new ComboBox();
            this.dgvPagos = new DataGridView();
            this.label2 = new Label();
            this.btnAgregar = new Button();
            this.btnEliminar = new Button();
            this.btnModificar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.nudMonto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvPagos).BeginInit();
            SuspendLayout();
            // 
            // nudMonto
            // 
            this.nudMonto.DecimalPlaces = 2;
            this.nudMonto.Location = new Point(151, 30);
            this.nudMonto.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new Size(120, 23);
            this.nudMonto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(151, 12);
            this.label1.Name = "label1";
            this.label1.Size = new Size(43, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Monto";
            // 
            // cmbTipoPago
            // 
            this.cmbTipoPago.FormattingEnabled = true;
            this.cmbTipoPago.Location = new Point(12, 30);
            this.cmbTipoPago.Name = "cmbTipoPago";
            this.cmbTipoPago.Size = new Size(121, 23);
            this.cmbTipoPago.TabIndex = 3;
            // 
            // dgvPagos
            // 
            this.dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagos.Dock = DockStyle.Bottom;
            this.dgvPagos.Location = new Point(0, 95);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.Size = new Size(284, 126);
            this.dgvPagos.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new Size(76, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo de Pago";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(23, 59);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(75, 23);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(103, 59);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(75, 23);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(184, 59);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(75, 23);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += btnModificar_Click;
            // 
            // PagarCompraForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 221);
            Controls.Add(this.btnModificar);
            Controls.Add(this.btnEliminar);
            Controls.Add(this.btnAgregar);
            Controls.Add(this.label2);
            Controls.Add(this.dgvPagos);
            Controls.Add(this.cmbTipoPago);
            Controls.Add(this.label1);
            Controls.Add(this.nudMonto);
            Name = "PagarCompraForm";
            Text = "PagarCompraForm";
            Load += PagarCompraForm_Load;
            ((System.ComponentModel.ISupportInitialize)this.nudMonto).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvPagos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NumericUpDown nudMonto;
        private Label label1;
        private ComboBox cmbTipoPago;
        private DataGridView dgvPagos;
        private Label label2;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnModificar;
    }
}