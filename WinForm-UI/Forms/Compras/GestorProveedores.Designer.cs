namespace WinForm_UI.Forms.Compras
{
    partial class GestorProveedores
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
            this.dgvProveedores = new DataGridView();
            this.btnEliminar = new Button();
            this.btnModificar = new Button();
            this.btnAgregar = new Button();
            this.label1 = new Label();
            this.txtNombre = new TextBox();
            ((System.ComponentModel.ISupportInitialize)this.dgvProveedores).BeginInit();
            SuspendLayout();
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Dock = DockStyle.Bottom;
            this.dgvProveedores.Location = new Point(0, 145);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.Size = new Size(566, 256);
            this.dgvProveedores.TabIndex = 0;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(12, 114);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(210, 23);
            this.btnEliminar.TabIndex = 21;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(12, 85);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(210, 23);
            this.btnModificar.TabIndex = 20;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(12, 56);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(210, 23);
            this.btnAgregar.TabIndex = 19;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += btnAgregar_Click;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(61, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Proveedor";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new Point(12, 27);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(210, 23);
            this.txtNombre.TabIndex = 17;
            // 
            // GestorProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(566, 401);
            Controls.Add(this.btnEliminar);
            Controls.Add(this.btnModificar);
            Controls.Add(this.btnAgregar);
            Controls.Add(this.label1);
            Controls.Add(this.txtNombre);
            Controls.Add(this.dgvProveedores);
            Name = "GestorProveedores";
            Text = "GestorProveedores";
            Load += GestorProveedores_Load;
            ((System.ComponentModel.ISupportInitialize)this.dgvProveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProveedores;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
        private Label label1;
        private TextBox txtNombre;
    }
}