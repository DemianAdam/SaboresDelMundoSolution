namespace WinForm_UI.Forms.Ingredientes
{
    partial class GestorRecetas
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
            this.dgvRecetas = new DataGridView();
            this.btnModificar = new Button();
            this.btnEliminar = new Button();
            this.btnAgregar = new Button();
            this.btnModificarIngredientes = new Button();
            this.txtNombre = new TextBox();
            this.txtDescripcion = new TextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.cmbUnidadDeMedida = new ComboBox();
            this.nudPesoAproximado = new NumericUpDown();
            this.label3 = new Label();
            this.label4 = new Label();
            this.nudPorciones = new NumericUpDown();
            this.label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)this.dgvRecetas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudPesoAproximado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudPorciones).BeginInit();
            SuspendLayout();
            // 
            // dgvRecetas
            // 
            this.dgvRecetas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecetas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecetas.Dock = DockStyle.Bottom;
            this.dgvRecetas.Location = new Point(0, 101);
            this.dgvRecetas.Name = "dgvRecetas";
            this.dgvRecetas.Size = new Size(564, 280);
            this.dgvRecetas.TabIndex = 0;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(474, 11);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(78, 52);
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(390, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(78, 52);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(306, 10);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(78, 52);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificarIngredientes
            // 
            this.btnModificarIngredientes.Location = new Point(306, 68);
            this.btnModificarIngredientes.Name = "btnModificarIngredientes";
            this.btnModificarIngredientes.Size = new Size(246, 23);
            this.btnModificarIngredientes.TabIndex = 16;
            this.btnModificarIngredientes.Text = "Modificar Ingredientes";
            this.btnModificarIngredientes.UseVisualStyleBackColor = true;
            this.btnModificarIngredientes.Click += btnModificarIngredientes_Click;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new Point(12, 27);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(120, 23);
            this.txtNombre.TabIndex = 13;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new Point(12, 69);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new Size(120, 23);
            this.txtDescripcion.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new Size(51, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new Size(69, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Descripcion";
            // 
            // cmbUnidadDeMedida
            // 
            this.cmbUnidadDeMedida.FormattingEnabled = true;
            this.cmbUnidadDeMedida.Location = new Point(146, 26);
            this.cmbUnidadDeMedida.Name = "cmbUnidadDeMedida";
            this.cmbUnidadDeMedida.Size = new Size(154, 23);
            this.cmbUnidadDeMedida.TabIndex = 20;
            // 
            // nudPesoAproximado
            // 
            this.nudPesoAproximado.DecimalPlaces = 2;
            this.nudPesoAproximado.Location = new Point(226, 68);
            this.nudPesoAproximado.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            this.nudPesoAproximado.Name = "nudPesoAproximado";
            this.nudPesoAproximado.Size = new Size(74, 23);
            this.nudPesoAproximado.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(151, 8);
            this.label3.Name = "label3";
            this.label3.Size = new Size(105, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Unidad De Medida";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(146, 52);
            this.label4.Name = "label4";
            this.label4.Size = new Size(59, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Porciones";
            // 
            // nudPorciones
            // 
            this.nudPorciones.Location = new Point(146, 68);
            this.nudPorciones.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            this.nudPorciones.Name = "nudPorciones";
            this.nudPorciones.Size = new Size(74, 23);
            this.nudPorciones.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new Point(226, 52);
            this.label5.Name = "label5";
            this.label5.Size = new Size(32, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Peso";
            // 
            // GestorRecetas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 381);
            Controls.Add(this.label5);
            Controls.Add(this.nudPorciones);
            Controls.Add(this.label4);
            Controls.Add(this.label3);
            Controls.Add(this.nudPesoAproximado);
            Controls.Add(this.cmbUnidadDeMedida);
            Controls.Add(this.label2);
            Controls.Add(this.label1);
            Controls.Add(this.txtDescripcion);
            Controls.Add(this.txtNombre);
            Controls.Add(this.btnModificarIngredientes);
            Controls.Add(this.btnModificar);
            Controls.Add(this.btnEliminar);
            Controls.Add(this.btnAgregar);
            Controls.Add(this.dgvRecetas);
            Name = "GestorRecetas";
            Text = "GestorRecetas";
            Load += GestorRecetas_Load;
            ((System.ComponentModel.ISupportInitialize)this.dgvRecetas).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudPesoAproximado).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudPorciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRecetas;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnAgregar;
        private Button btnModificarIngredientes;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private Label label1;
        private Label label2;
        private ComboBox cmbUnidadDeMedida;
        private NumericUpDown nudPesoAproximado;
        private Label label3;
        private Label label4;
        private NumericUpDown nudPorciones;
        private Label label5;
    }
}