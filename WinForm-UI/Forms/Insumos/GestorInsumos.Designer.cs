namespace WinForm_UI.Forms.Insumos
{
    partial class GestorInsumos
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
            this.btnEliminar = new Button();
            this.btnModificar = new Button();
            this.btnAgregar = new Button();
            this.label1 = new Label();
            this.txtNombre = new TextBox();
            this.dgvInsumos = new DataGridView();
            this.label2 = new Label();
            this.txtDescripcion = new TextBox();
            this.label3 = new Label();
            this.cmbTipo = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)this.dgvInsumos).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(233, 97);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(210, 38);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(233, 50);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(210, 41);
            this.btnModificar.TabIndex = 16;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(233, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(210, 41);
            this.btnAgregar.TabIndex = 15;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += btnAgregar_Click;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 3);
            this.label1.Name = "label1";
            this.label1.Size = new Size(51, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new Point(12, 21);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(210, 23);
            this.txtNombre.TabIndex = 13;
            // 
            // dgvInsumos
            // 
            this.dgvInsumos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsumos.Dock = DockStyle.Bottom;
            this.dgvInsumos.Location = new Point(0, 153);
            this.dgvInsumos.Name = "dgvInsumos";
            this.dgvInsumos.Size = new Size(443, 205);
            this.dgvInsumos.TabIndex = 12;
            this.dgvInsumos.SelectionChanged += dgvInsumos_SelectionChanged;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new Size(69, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new Point(12, 68);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new Size(210, 23);
            this.txtDescripcion.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new Size(30, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Tipo";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new Point(12, 112);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new Size(210, 23);
            this.cmbTipo.TabIndex = 22;
            // 
            // GestorInsumos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 358);
            Controls.Add(this.cmbTipo);
            Controls.Add(this.label3);
            Controls.Add(this.label2);
            Controls.Add(this.txtDescripcion);
            Controls.Add(this.btnEliminar);
            Controls.Add(this.btnModificar);
            Controls.Add(this.btnAgregar);
            Controls.Add(this.label1);
            Controls.Add(this.txtNombre);
            Controls.Add(this.dgvInsumos);
            Name = "GestorInsumos";
            Text = "GestorInsumos";
            Load += GestorInsumos_Load;
            ((System.ComponentModel.ISupportInitialize)this.dgvInsumos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
        private Label label1;
        private TextBox txtNombre;
        private DataGridView dgvInsumos;
        private Label label2;
        private TextBox txtDescripcion;
        private Label label3;
        private ComboBox cmbTipo;
    }
}