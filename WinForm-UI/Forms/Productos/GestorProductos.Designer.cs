namespace WinForm_UI.Productos
{
    partial class GestorProductos
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
            this.dgvProductos = new DataGridView();
            this.txtNombre = new TextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.nudPrecio = new NumericUpDown();
            this.btnAgregar = new Button();
            this.dgvSubProductos = new DataGridView();
            this.btnModificar = new Button();
            this.btnEliminar = new Button();
            this.label3 = new Label();
            this.label4 = new Label();
            this.cmbTipoProducto = new ComboBox();
            this.label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)this.dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvSubProductos).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Dock = DockStyle.Bottom;
            this.dgvProductos.Location = new Point(0, 194);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new Size(659, 223);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new Point(10, 32);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(100, 23);
            this.txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(51, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(10, 65);
            this.label2.Name = "label2";
            this.label2.Size = new Size(40, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Costo";
            // 
            // nudPrecio
            // 
            this.nudPrecio.Location = new Point(10, 88);
            this.nudPrecio.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new Size(98, 23);
            this.nudPrecio.TabIndex = 5;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(118, 9);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(98, 46);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvSubProductos
            // 
            this.dgvSubProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvSubProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubProductos.Location = new Point(222, 30);
            this.dgvSubProductos.Name = "dgvSubProductos";
            this.dgvSubProductos.Size = new Size(436, 134);
            this.dgvSubProductos.TabIndex = 7;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(118, 65);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(98, 46);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(118, 118);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(98, 46);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += btnEliminar_Click;
            // 
            // label3
            // 
            this.label3.Anchor = AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(271, 176);
            this.label3.Name = "label3";
            this.label3.Size = new Size(113, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Todos los Productos";
            // 
            // label4
            // 
            this.label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(401, 12);
            this.label4.Name = "label4";
            this.label4.Size = new Size(84, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Sub Productos";
            // 
            // cmbTipoProducto
            // 
            this.cmbTipoProducto.FormattingEnabled = true;
            this.cmbTipoProducto.Location = new Point(8, 141);
            this.cmbTipoProducto.Name = "cmbTipoProducto";
            this.cmbTipoProducto.Size = new Size(100, 23);
            this.cmbTipoProducto.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new Point(10, 123);
            this.label5.Name = "label5";
            this.label5.Size = new Size(30, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tipo";
            // 
            // GestorProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 417);
            Controls.Add(this.label5);
            Controls.Add(this.cmbTipoProducto);
            Controls.Add(this.label4);
            Controls.Add(this.label3);
            Controls.Add(this.btnEliminar);
            Controls.Add(this.btnModificar);
            Controls.Add(this.dgvSubProductos);
            Controls.Add(this.btnAgregar);
            Controls.Add(this.nudPrecio);
            Controls.Add(this.label2);
            Controls.Add(this.label1);
            Controls.Add(this.txtNombre);
            Controls.Add(this.dgvProductos);
            MinimumSize = new Size(675, 435);
            Name = "GestorProductos";
            Text = "Gestor CantidadTipoProductos";
            Load += CrearProducto_Load;
            ((System.ComponentModel.ISupportInitialize)this.dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvSubProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProductos;
        private TextBox txtNombre;
        private Label label1;
        private Label label2;
        private NumericUpDown nudPrecio;
        private Button btnAgregar;
        private DataGridView dgvSubProductos;
        private Button btnModificar;
        private Button btnEliminar;
        private Label label3;
        private Label label4;
        private ComboBox cmbTipoProducto;
        private Label label5;
    }
}