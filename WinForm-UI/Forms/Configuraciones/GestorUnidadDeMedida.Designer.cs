namespace WinForm_UI.Configuraciones
{
    partial class GestorUnidadDeMedida
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
            this.txtTipo = new TextBox();
            this.dgvUnidadDeMedida = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)this.dgvUnidadDeMedida).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(12, 109);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(210, 23);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(12, 80);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(210, 23);
            this.btnModificar.TabIndex = 10;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(12, 51);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(210, 23);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += btnAgregar_Click;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new Size(104, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Unidad de Medida";
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new Point(12, 22);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new Size(210, 23);
            this.txtTipo.TabIndex = 7;
            // 
            // dgvUnidadDeMedida
            // 
            this.dgvUnidadDeMedida.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnidadDeMedida.Dock = DockStyle.Bottom;
            this.dgvUnidadDeMedida.Location = new Point(0, 138);
            this.dgvUnidadDeMedida.Name = "dgvUnidadDeMedida";
            this.dgvUnidadDeMedida.Size = new Size(238, 223);
            this.dgvUnidadDeMedida.TabIndex = 6;
            this.dgvUnidadDeMedida.SelectionChanged += dgvUnidadDeMedida_SelectionChanged;
            // 
            // GestorUnidadDeMedida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(238, 361);
            Controls.Add(this.btnEliminar);
            Controls.Add(this.btnModificar);
            Controls.Add(this.btnAgregar);
            Controls.Add(this.label1);
            Controls.Add(this.txtTipo);
            Controls.Add(this.dgvUnidadDeMedida);
            Name = "GestorUnidadDeMedida";
            Text = "GestorUnidadDeMedida";
            Load += GestorUnidadDeMedida_Load;
            ((System.ComponentModel.ISupportInitialize)this.dgvUnidadDeMedida).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
        private Label label1;
        private TextBox txtTipo;
        private DataGridView dgvUnidadDeMedida;
    }
}