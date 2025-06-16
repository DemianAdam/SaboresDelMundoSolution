namespace WinForm_UI.Productos
{
    partial class GestorTipoProducto
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
            this.dgvTipoProducto = new DataGridView();
            this.txtTipo = new TextBox();
            this.label1 = new Label();
            this.btnAgregar = new Button();
            this.btnModificar = new Button();
            this.btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.dgvTipoProducto).BeginInit();
            SuspendLayout();
            // 
            // dgvTipoProducto
            // 
            this.dgvTipoProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipoProducto.Dock = DockStyle.Bottom;
            this.dgvTipoProducto.Location = new Point(0, 149);
            this.dgvTipoProducto.Name = "dgvTipoProducto";
            this.dgvTipoProducto.Size = new Size(234, 199);
            this.dgvTipoProducto.TabIndex = 0;
            this.dgvTipoProducto.SelectionChanged += dgvTipoProducto_SelectionChanged;
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new Point(12, 27);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new Size(210, 23);
            this.txtTipo.TabIndex = 1;
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
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(12, 56);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(210, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(12, 85);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(210, 23);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(12, 114);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(210, 23);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += btnEliminar_Click;
            // 
            // GestorTipoProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 348);
            Controls.Add(this.btnEliminar);
            Controls.Add(this.btnModificar);
            Controls.Add(this.btnAgregar);
            Controls.Add(this.label1);
            Controls.Add(this.txtTipo);
            Controls.Add(this.dgvTipoProducto);
            Name = "GestorTipoProducto";
            Text = "GestorTipoProducto";
            Load += GestorTipoProducto_Load;
            ((System.ComponentModel.ISupportInitialize)this.dgvTipoProducto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTipoProducto;
        private TextBox txtTipo;
        private Label label1;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
    }
}