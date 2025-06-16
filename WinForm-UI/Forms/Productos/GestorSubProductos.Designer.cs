namespace WinForm_UI.Productos
{
    partial class GestorSubProductos
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
            this.nudPrecio = new NumericUpDown();
            this.label2 = new Label();
            this.label1 = new Label();
            this.txtNombre = new TextBox();
            this.btnAplicar = new Button();
            this.btnCancelar = new Button();
            this.tlpParent = new TableLayoutPanel();
            this.tlpFooter = new TableLayoutPanel();
            this.tlpAsignacionSubProductos = new TableLayoutPanel();
            this.tlpSubProductosDisponibles = new TableLayoutPanel();
            this.dgvSubProductosDisponibles = new DataGridView();
            this.label4 = new Label();
            this.tlpBotonesAsignar = new TableLayoutPanel();
            this.btnRemover = new Button();
            this.btnAsignar = new Button();
            this.tlpSubProductosAsignados = new TableLayoutPanel();
            this.dgvSubProductosAsignados = new DataGridView();
            this.label3 = new Label();
            this.tlpHeader = new TableLayoutPanel();
            this.tlpInputPrecio = new TableLayoutPanel();
            this.tlpInputNombre = new TableLayoutPanel();
            this.tlpTipo = new TableLayoutPanel();
            this.label5 = new Label();
            this.cmbTipoProducto = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)this.nudPrecio).BeginInit();
            this.tlpParent.SuspendLayout();
            this.tlpFooter.SuspendLayout();
            this.tlpAsignacionSubProductos.SuspendLayout();
            this.tlpSubProductosDisponibles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvSubProductosDisponibles).BeginInit();
            this.tlpBotonesAsignar.SuspendLayout();
            this.tlpSubProductosAsignados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvSubProductosAsignados).BeginInit();
            this.tlpHeader.SuspendLayout();
            this.tlpInputPrecio.SuspendLayout();
            this.tlpInputNombre.SuspendLayout();
            this.tlpTipo.SuspendLayout();
            SuspendLayout();
            // 
            // nudPrecio
            // 
            this.nudPrecio.Dock = DockStyle.Fill;
            this.nudPrecio.Location = new Point(3, 18);
            this.nudPrecio.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new Size(378, 23);
            this.nudPrecio.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = DockStyle.Fill;
            this.label2.Location = new Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(378, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Costo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = DockStyle.Fill;
            this.label1.Location = new Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(406, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Dock = DockStyle.Fill;
            this.txtNombre.Location = new Point(3, 18);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(406, 23);
            this.txtNombre.TabIndex = 6;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Dock = DockStyle.Fill;
            this.btnAplicar.Location = new Point(725, 3);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new Size(80, 44);
            this.btnAplicar.TabIndex = 16;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += btnAplicar_Click;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = DockStyle.Fill;
            this.btnCancelar.Location = new Point(639, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(80, 44);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += btnCancelar_Click;
            // 
            // tlpParent
            // 
            this.tlpParent.ColumnCount = 1;
            this.tlpParent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tlpParent.Controls.Add(this.tlpFooter, 0, 2);
            this.tlpParent.Controls.Add(this.tlpAsignacionSubProductos, 0, 1);
            this.tlpParent.Controls.Add(this.tlpHeader, 0, 0);
            this.tlpParent.Dock = DockStyle.Fill;
            this.tlpParent.Location = new Point(0, 0);
            this.tlpParent.Name = "tlpParent";
            this.tlpParent.RowCount = 3;
            this.tlpParent.RowStyles.Add(new RowStyle());
            this.tlpParent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tlpParent.RowStyles.Add(new RowStyle());
            this.tlpParent.Size = new Size(814, 348);
            this.tlpParent.TabIndex = 18;
            // 
            // tlpFooter
            // 
            this.tlpFooter.ColumnCount = 3;
            this.tlpFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tlpFooter.ColumnStyles.Add(new ColumnStyle());
            this.tlpFooter.ColumnStyles.Add(new ColumnStyle());
            this.tlpFooter.Controls.Add(this.btnAplicar, 2, 0);
            this.tlpFooter.Controls.Add(this.btnCancelar, 1, 0);
            this.tlpFooter.Dock = DockStyle.Fill;
            this.tlpFooter.Location = new Point(3, 295);
            this.tlpFooter.Name = "tlpFooter";
            this.tlpFooter.RowCount = 1;
            this.tlpFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tlpFooter.Size = new Size(808, 50);
            this.tlpFooter.TabIndex = 0;
            // 
            // tlpAsignacionSubProductos
            // 
            this.tlpAsignacionSubProductos.ColumnCount = 3;
            this.tlpAsignacionSubProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.47826F));
            this.tlpAsignacionSubProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.043478F));
            this.tlpAsignacionSubProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.47826F));
            this.tlpAsignacionSubProductos.Controls.Add(this.tlpSubProductosDisponibles, 2, 0);
            this.tlpAsignacionSubProductos.Controls.Add(this.tlpBotonesAsignar, 1, 0);
            this.tlpAsignacionSubProductos.Controls.Add(this.tlpSubProductosAsignados, 0, 0);
            this.tlpAsignacionSubProductos.Dock = DockStyle.Fill;
            this.tlpAsignacionSubProductos.Location = new Point(3, 59);
            this.tlpAsignacionSubProductos.Name = "tlpAsignacionSubProductos";
            this.tlpAsignacionSubProductos.RowCount = 1;
            this.tlpAsignacionSubProductos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tlpAsignacionSubProductos.Size = new Size(808, 230);
            this.tlpAsignacionSubProductos.TabIndex = 1;
            // 
            // tlpSubProductosDisponibles
            // 
            this.tlpSubProductosDisponibles.ColumnCount = 1;
            this.tlpSubProductosDisponibles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tlpSubProductosDisponibles.Controls.Add(this.dgvSubProductosDisponibles, 0, 1);
            this.tlpSubProductosDisponibles.Controls.Add(this.label4, 0, 0);
            this.tlpSubProductosDisponibles.Dock = DockStyle.Fill;
            this.tlpSubProductosDisponibles.Location = new Point(459, 3);
            this.tlpSubProductosDisponibles.Name = "tlpSubProductosDisponibles";
            this.tlpSubProductosDisponibles.RowCount = 2;
            this.tlpSubProductosDisponibles.RowStyles.Add(new RowStyle());
            this.tlpSubProductosDisponibles.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tlpSubProductosDisponibles.Size = new Size(346, 224);
            this.tlpSubProductosDisponibles.TabIndex = 2;
            // 
            // dgvSubProductosDisponibles
            // 
            this.dgvSubProductosDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubProductosDisponibles.Dock = DockStyle.Fill;
            this.dgvSubProductosDisponibles.Location = new Point(3, 18);
            this.dgvSubProductosDisponibles.Name = "dgvSubProductosDisponibles";
            this.dgvSubProductosDisponibles.Size = new Size(340, 203);
            this.dgvSubProductosDisponibles.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = DockStyle.Fill;
            this.label4.Location = new Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(340, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "SubProductos";
            // 
            // tlpBotonesAsignar
            // 
            this.tlpBotonesAsignar.ColumnCount = 1;
            this.tlpBotonesAsignar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tlpBotonesAsignar.Controls.Add(this.btnRemover, 0, 2);
            this.tlpBotonesAsignar.Controls.Add(this.btnAsignar, 0, 1);
            this.tlpBotonesAsignar.Dock = DockStyle.Fill;
            this.tlpBotonesAsignar.Location = new Point(354, 3);
            this.tlpBotonesAsignar.Name = "tlpBotonesAsignar";
            this.tlpBotonesAsignar.RowCount = 4;
            this.tlpBotonesAsignar.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tlpBotonesAsignar.RowStyles.Add(new RowStyle());
            this.tlpBotonesAsignar.RowStyles.Add(new RowStyle());
            this.tlpBotonesAsignar.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tlpBotonesAsignar.Size = new Size(99, 224);
            this.tlpBotonesAsignar.TabIndex = 0;
            // 
            // btnRemover
            // 
            this.btnRemover.Dock = DockStyle.Fill;
            this.btnRemover.Location = new Point(3, 115);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new Size(93, 23);
            this.btnRemover.TabIndex = 15;
            this.btnRemover.Text = "Remover ->";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += btnRemover_Click;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Dock = DockStyle.Fill;
            this.btnAsignar.Location = new Point(3, 86);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new Size(93, 23);
            this.btnAsignar.TabIndex = 14;
            this.btnAsignar.Text = "<- Asignar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += btnAsignar_Click;
            // 
            // tlpSubProductosAsignados
            // 
            this.tlpSubProductosAsignados.ColumnCount = 1;
            this.tlpSubProductosAsignados.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tlpSubProductosAsignados.Controls.Add(this.dgvSubProductosAsignados, 0, 1);
            this.tlpSubProductosAsignados.Controls.Add(this.label3, 0, 0);
            this.tlpSubProductosAsignados.Dock = DockStyle.Fill;
            this.tlpSubProductosAsignados.Location = new Point(3, 3);
            this.tlpSubProductosAsignados.Name = "tlpSubProductosAsignados";
            this.tlpSubProductosAsignados.RowCount = 2;
            this.tlpSubProductosAsignados.RowStyles.Add(new RowStyle());
            this.tlpSubProductosAsignados.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tlpSubProductosAsignados.Size = new Size(345, 224);
            this.tlpSubProductosAsignados.TabIndex = 1;
            // 
            // dgvSubProductosAsignados
            // 
            this.dgvSubProductosAsignados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubProductosAsignados.Dock = DockStyle.Fill;
            this.dgvSubProductosAsignados.Location = new Point(3, 18);
            this.dgvSubProductosAsignados.Name = "dgvSubProductosAsignados";
            this.dgvSubProductosAsignados.Size = new Size(339, 203);
            this.dgvSubProductosAsignados.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = DockStyle.Fill;
            this.label3.Location = new Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(339, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "SubProductos Asignados";
            // 
            // tlpHeader
            // 
            this.tlpHeader.ColumnCount = 3;
            this.tlpHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.4994F));
            this.tlpHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.16727F));
            this.tlpHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            this.tlpHeader.Controls.Add(this.tlpInputPrecio, 1, 0);
            this.tlpHeader.Controls.Add(this.tlpInputNombre, 0, 0);
            this.tlpHeader.Controls.Add(this.tlpTipo, 2, 0);
            this.tlpHeader.Dock = DockStyle.Fill;
            this.tlpHeader.Location = new Point(3, 3);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 1;
            this.tlpHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tlpHeader.Size = new Size(808, 50);
            this.tlpHeader.TabIndex = 2;
            // 
            // tlpInputPrecio
            // 
            this.tlpInputPrecio.ColumnCount = 1;
            this.tlpInputPrecio.ColumnStyles.Add(new ColumnStyle());
            this.tlpInputPrecio.Controls.Add(this.nudPrecio, 0, 1);
            this.tlpInputPrecio.Controls.Add(this.label2, 0, 0);
            this.tlpInputPrecio.Dock = DockStyle.Fill;
            this.tlpInputPrecio.Location = new Point(281, 3);
            this.tlpInputPrecio.Name = "tlpInputPrecio";
            this.tlpInputPrecio.RowCount = 2;
            this.tlpInputPrecio.RowStyles.Add(new RowStyle());
            this.tlpInputPrecio.RowStyles.Add(new RowStyle());
            this.tlpInputPrecio.Size = new Size(253, 44);
            this.tlpInputPrecio.TabIndex = 1;
            // 
            // tlpInputNombre
            // 
            this.tlpInputNombre.ColumnCount = 1;
            this.tlpInputNombre.ColumnStyles.Add(new ColumnStyle());
            this.tlpInputNombre.Controls.Add(this.txtNombre, 0, 1);
            this.tlpInputNombre.Controls.Add(this.label1, 0, 0);
            this.tlpInputNombre.Dock = DockStyle.Fill;
            this.tlpInputNombre.Location = new Point(3, 3);
            this.tlpInputNombre.Name = "tlpInputNombre";
            this.tlpInputNombre.RowCount = 2;
            this.tlpInputNombre.RowStyles.Add(new RowStyle());
            this.tlpInputNombre.RowStyles.Add(new RowStyle());
            this.tlpInputNombre.Size = new Size(272, 44);
            this.tlpInputNombre.TabIndex = 0;
            // 
            // tlpTipo
            // 
            this.tlpTipo.ColumnCount = 1;
            this.tlpTipo.ColumnStyles.Add(new ColumnStyle());
            this.tlpTipo.Controls.Add(this.label5, 0, 0);
            this.tlpTipo.Controls.Add(this.cmbTipoProducto, 0, 1);
            this.tlpTipo.Dock = DockStyle.Fill;
            this.tlpTipo.Location = new Point(540, 3);
            this.tlpTipo.Name = "tlpTipo";
            this.tlpTipo.RowCount = 2;
            this.tlpTipo.RowStyles.Add(new RowStyle());
            this.tlpTipo.RowStyles.Add(new RowStyle());
            this.tlpTipo.Size = new Size(265, 44);
            this.tlpTipo.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = DockStyle.Fill;
            this.label5.Location = new Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(259, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tipo";
            // 
            // cmbTipoProducto
            // 
            this.cmbTipoProducto.Dock = DockStyle.Fill;
            this.cmbTipoProducto.FormattingEnabled = true;
            this.cmbTipoProducto.Location = new Point(3, 18);
            this.cmbTipoProducto.Name = "cmbTipoProducto";
            this.cmbTipoProducto.Size = new Size(259, 23);
            this.cmbTipoProducto.TabIndex = 1;
            this.cmbTipoProducto.SelectionChangeCommitted += cmbTipoProducto_SelectionChangeCommitted;
            // 
            // GestorSubProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 348);
            Controls.Add(this.tlpParent);
            Name = "GestorSubProductos";
            Text = "GestorSubProductos";
            Load += GestorSubProductos_Load;
            ((System.ComponentModel.ISupportInitialize)this.nudPrecio).EndInit();
            this.tlpParent.ResumeLayout(false);
            this.tlpFooter.ResumeLayout(false);
            this.tlpAsignacionSubProductos.ResumeLayout(false);
            this.tlpSubProductosDisponibles.ResumeLayout(false);
            this.tlpSubProductosDisponibles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvSubProductosDisponibles).EndInit();
            this.tlpBotonesAsignar.ResumeLayout(false);
            this.tlpSubProductosAsignados.ResumeLayout(false);
            this.tlpSubProductosAsignados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvSubProductosAsignados).EndInit();
            this.tlpHeader.ResumeLayout(false);
            this.tlpInputPrecio.ResumeLayout(false);
            this.tlpInputPrecio.PerformLayout();
            this.tlpInputNombre.ResumeLayout(false);
            this.tlpInputNombre.PerformLayout();
            this.tlpTipo.ResumeLayout(false);
            this.tlpTipo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private NumericUpDown nudPrecio;
        private Label label2;
        private Label label1;
        private TextBox txtNombre;
        private Button btnAplicar;
        private Button btnCancelar;
        private TableLayoutPanel tlpParent;
        private TableLayoutPanel tlpFooter;
        private TableLayoutPanel tlpHeader;
        private TableLayoutPanel tlpInputNombre;
        private TableLayoutPanel tlpInputPrecio;
        private TableLayoutPanel tlpAsignacionSubProductos;
        private TableLayoutPanel tlpSubProductosDisponibles;
        private DataGridView dgvSubProductosDisponibles;
        private Label label4;
        private TableLayoutPanel tlpBotonesAsignar;
        private Button btnRemover;
        private Button btnAsignar;
        private TableLayoutPanel tlpSubProductosAsignados;
        private DataGridView dgvSubProductosAsignados;
        private Label label3;
        private TableLayoutPanel tlpTipo;
        private Label label5;
        private ComboBox cmbTipoProducto;
    }
}