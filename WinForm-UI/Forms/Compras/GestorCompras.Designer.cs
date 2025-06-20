namespace WinForm_UI.Forms.Compras
{
    partial class GestorCompras
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
            this.dgvCompras = new DataGridView();
            this.nudCostoTotal = new NumericUpDown();
            this.lblTotal = new Label();
            this.dtpFecha = new DateTimePicker();
            this.label1 = new Label();
            this.cmbProveedores = new ComboBox();
            this.label2 = new Label();
            this.cboxTieneProveedor = new CheckBox();
            this.btnAgregar = new Button();
            this.btnEliminar = new Button();
            this.btnModificarPagos = new Button();
            this.btnModificarDetalles = new Button();
            this.btnModificar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.dgvCompras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudCostoTotal).BeginInit();
            SuspendLayout();
            // 
            // dgvCompras
            // 
            this.dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompras.Dock = DockStyle.Bottom;
            this.dgvCompras.Location = new Point(0, 101);
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.Size = new Size(524, 280);
            this.dgvCompras.TabIndex = 0;
            // 
            // nudCostoTotal
            // 
            this.nudCostoTotal.DecimalPlaces = 2;
            this.nudCostoTotal.Location = new Point(141, 27);
            this.nudCostoTotal.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.nudCostoTotal.Name = "nudCostoTotal";
            this.nudCostoTotal.Size = new Size(120, 23);
            this.nudCostoTotal.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new Point(141, 9);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new Size(102, 15);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Costo MontoTotal";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = DateTimePickerFormat.Short;
            this.dtpFecha.Location = new Point(12, 27);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new Size(120, 23);
            this.dtpFecha.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(38, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha";
            // 
            // cmbProveedores
            // 
            this.cmbProveedores.FormattingEnabled = true;
            this.cmbProveedores.Location = new Point(12, 71);
            this.cmbProveedores.Name = "cmbProveedores";
            this.cmbProveedores.Size = new Size(121, 23);
            this.cmbProveedores.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new Size(61, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Proveedor";
            // 
            // cboxTieneProveedor
            // 
            this.cboxTieneProveedor.AutoSize = true;
            this.cboxTieneProveedor.Checked = true;
            this.cboxTieneProveedor.CheckState = CheckState.Checked;
            this.cboxTieneProveedor.Location = new Point(139, 73);
            this.cboxTieneProveedor.Name = "cboxTieneProveedor";
            this.cboxTieneProveedor.Size = new Size(111, 19);
            this.cboxTieneProveedor.TabIndex = 7;
            this.cboxTieneProveedor.Text = "Tiene Proveedor";
            this.cboxTieneProveedor.UseVisualStyleBackColor = true;
            this.cboxTieneProveedor.CheckedChanged += cboxTieneProveedor_CheckedChanged;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(267, 12);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(78, 52);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(351, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(78, 52);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificarPagos
            // 
            this.btnModificarPagos.Location = new Point(274, 70);
            this.btnModificarPagos.Name = "btnModificarPagos";
            this.btnModificarPagos.Size = new Size(112, 23);
            this.btnModificarPagos.TabIndex = 11;
            this.btnModificarPagos.Text = "Modificar Pagos";
            this.btnModificarPagos.UseVisualStyleBackColor = true;
            this.btnModificarPagos.Click += btnModificarPagos_Click;
            // 
            // btnModificarDetalles
            // 
            this.btnModificarDetalles.Location = new Point(392, 70);
            this.btnModificarDetalles.Name = "btnModificarDetalles";
            this.btnModificarDetalles.Size = new Size(112, 23);
            this.btnModificarDetalles.TabIndex = 10;
            this.btnModificarDetalles.Text = "Modificar Detalles";
            this.btnModificarDetalles.UseVisualStyleBackColor = true;
            this.btnModificarDetalles.Click += btnModificarDetalles_Click;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(435, 13);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(78, 52);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += btnModificar_Click;
            // 
            // GestorCompras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 381);
            Controls.Add(this.btnModificar);
            Controls.Add(this.btnModificarPagos);
            Controls.Add(this.btnModificarDetalles);
            Controls.Add(this.btnEliminar);
            Controls.Add(this.btnAgregar);
            Controls.Add(this.cboxTieneProveedor);
            Controls.Add(this.label2);
            Controls.Add(this.cmbProveedores);
            Controls.Add(this.label1);
            Controls.Add(this.dtpFecha);
            Controls.Add(this.lblTotal);
            Controls.Add(this.nudCostoTotal);
            Controls.Add(this.dgvCompras);
            Name = "GestorCompras";
            Text = "Gestor de Compras";
            Load += GestorCompras_Load;
            ((System.ComponentModel.ISupportInitialize)this.dgvCompras).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudCostoTotal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCompras;
        private NumericUpDown nudCostoTotal;
        private Label lblTotal;
        private DateTimePicker dtpFecha;
        private Label label1;
        private ComboBox cmbProveedores;
        private Label label2;
        private CheckBox cboxTieneProveedor;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnModificarPagos;
        private Button btnModificarDetalles;
        private Button btnModificar;
    }
}