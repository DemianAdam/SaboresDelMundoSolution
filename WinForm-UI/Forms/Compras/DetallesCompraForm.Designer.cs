namespace WinForm_UI.Forms.Compras
{
    partial class DetallesCompraForm
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
            this.dgvDetalles = new DataGridView();
            this.btnModificar = new Button();
            this.btnEliminar = new Button();
            this.btnAgregar = new Button();
            this.label2 = new Label();
            this.cmbInsumo = new ComboBox();
            this.label1 = new Label();
            this.nudCosto = new NumericUpDown();
            this.label3 = new Label();
            this.cmbUnidadDeMedida = new ComboBox();
            this.label4 = new Label();
            this.nudCantidad = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)this.dgvDetalles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudCosto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Dock = DockStyle.Bottom;
            this.dgvDetalles.Location = new Point(0, 125);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.Size = new Size(269, 240);
            this.dgvDetalles.TabIndex = 0;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(179, 96);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(75, 23);
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(98, 96);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(75, 23);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(18, 96);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(75, 23);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += btnAgregar_Click;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new Size(47, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Insumo";
            // 
            // cmbInsumo
            // 
            this.cmbInsumo.FormattingEnabled = true;
            this.cmbInsumo.Location = new Point(12, 25);
            this.cmbInsumo.Name = "cmbInsumo";
            this.cmbInsumo.Size = new Size(121, 23);
            this.cmbInsumo.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(139, 7);
            this.label1.Name = "label1";
            this.label1.Size = new Size(38, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Costo";
            // 
            // nudCosto
            // 
            this.nudCosto.DecimalPlaces = 2;
            this.nudCosto.Location = new Point(139, 25);
            this.nudCosto.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.nudCosto.Name = "nudCosto";
            this.nudCosto.Size = new Size(120, 23);
            this.nudCosto.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new Size(104, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Unidad de Medida";
            // 
            // cmbUnidadDeMedida
            // 
            this.cmbUnidadDeMedida.FormattingEnabled = true;
            this.cmbUnidadDeMedida.Location = new Point(12, 69);
            this.cmbUnidadDeMedida.Name = "cmbUnidadDeMedida";
            this.cmbUnidadDeMedida.Size = new Size(121, 23);
            this.cmbUnidadDeMedida.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(139, 51);
            this.label4.Name = "label4";
            this.label4.Size = new Size(55, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "PesoAproximado";
            // 
            // nudCantidad
            // 
            this.nudCantidad.DecimalPlaces = 2;
            this.nudCantidad.Location = new Point(139, 69);
            this.nudCantidad.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new Size(120, 23);
            this.nudCantidad.TabIndex = 18;
            // 
            // DetallesCompraForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(269, 365);
            Controls.Add(this.label4);
            Controls.Add(this.nudCantidad);
            Controls.Add(this.label3);
            Controls.Add(this.cmbUnidadDeMedida);
            Controls.Add(this.btnModificar);
            Controls.Add(this.btnEliminar);
            Controls.Add(this.btnAgregar);
            Controls.Add(this.label2);
            Controls.Add(this.cmbInsumo);
            Controls.Add(this.label1);
            Controls.Add(this.nudCosto);
            Controls.Add(this.dgvDetalles);
            Name = "DetallesCompraForm";
            Text = "DetallesCompraForm";
            Load += DetallesCompraForm_Load;
            ((System.ComponentModel.ISupportInitialize)this.dgvDetalles).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudCosto).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDetalles;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnAgregar;
        private Label label2;
        private ComboBox cmbInsumo;
        private Label label1;
        private NumericUpDown nudCosto;
        private Label label3;
        private ComboBox cmbUnidadDeMedida;
        private Label label4;
        private NumericUpDown nudCantidad;
    }
}