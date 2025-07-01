namespace WinForm_UI.Forms.Ingredientes
{
    partial class RecetaCantidadesForm
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
            this.dgvIngredientes = new DataGridView();
            this.cmbComponenteReceta = new ComboBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.cmbUnidadDeMedida = new ComboBox();
            this.label3 = new Label();
            this.nudCantidad = new NumericUpDown();
            this.nudDesperdicioAceptado = new NumericUpDown();
            this.label4 = new Label();
            this.btnAgregar = new Button();
            this.btnEliminar = new Button();
            this.btnModificar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.dgvIngredientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudDesperdicioAceptado).BeginInit();
            SuspendLayout();
            // 
            // dgvIngredientes
            // 
            this.dgvIngredientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredientes.Dock = DockStyle.Bottom;
            this.dgvIngredientes.Location = new Point(0, 110);
            this.dgvIngredientes.Name = "dgvIngredientes";
            this.dgvIngredientes.Size = new Size(377, 155);
            this.dgvIngredientes.TabIndex = 0;
            // 
            // cmbComponenteReceta
            // 
            this.cmbComponenteReceta.FormattingEnabled = true;
            this.cmbComponenteReceta.Location = new Point(12, 28);
            this.cmbComponenteReceta.Name = "cmbComponenteReceta";
            this.cmbComponenteReceta.Size = new Size(121, 23);
            this.cmbComponenteReceta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(115, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Componente Receta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new Size(104, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Unidad de Medida";
            // 
            // cmbUnidadDeMedida
            // 
            this.cmbUnidadDeMedida.FormattingEnabled = true;
            this.cmbUnidadDeMedida.Location = new Point(12, 73);
            this.cmbUnidadDeMedida.Name = "cmbUnidadDeMedida";
            this.cmbUnidadDeMedida.Size = new Size(121, 23);
            this.cmbUnidadDeMedida.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(139, 10);
            this.label3.Name = "label3";
            this.label3.Size = new Size(55, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cantidad";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new Point(139, 28);
            this.nudCantidad.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new Size(120, 23);
            this.nudCantidad.TabIndex = 7;
            // 
            // nudDesperdicioAceptado
            // 
            this.nudDesperdicioAceptado.Location = new Point(139, 73);
            this.nudDesperdicioAceptado.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.nudDesperdicioAceptado.Name = "nudDesperdicioAceptado";
            this.nudDesperdicioAceptado.Size = new Size(120, 23);
            this.nudDesperdicioAceptado.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(139, 55);
            this.label4.Name = "label4";
            this.label4.Size = new Size(123, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Desperdicio Aceptado";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(268, 12);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(97, 29);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(268, 41);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(97, 29);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(268, 70);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(97, 29);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += btnModificar_Click;
            // 
            // RecetaCantidadesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 265);
            Controls.Add(this.btnModificar);
            Controls.Add(this.btnEliminar);
            Controls.Add(this.btnAgregar);
            Controls.Add(this.nudDesperdicioAceptado);
            Controls.Add(this.label4);
            Controls.Add(this.nudCantidad);
            Controls.Add(this.label3);
            Controls.Add(this.label2);
            Controls.Add(this.cmbUnidadDeMedida);
            Controls.Add(this.label1);
            Controls.Add(this.cmbComponenteReceta);
            Controls.Add(this.dgvIngredientes);
            Name = "RecetaCantidadesForm";
            Text = "RecetaCantidadesForm";
            Load += RecetaCantidadesForm_Load;
            ((System.ComponentModel.ISupportInitialize)this.dgvIngredientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudDesperdicioAceptado).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvIngredientes;
        private ComboBox cmbComponenteReceta;
        private Label label1;
        private Label label2;
        private ComboBox cmbUnidadDeMedida;
        private Label label3;
        private NumericUpDown nudCantidad;
        private NumericUpDown nudDesperdicioAceptado;
        private Label label4;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnModificar;
    }
}