namespace WinForm_UI.Forms.Insumos
{
    partial class GestorConversiones
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
            this.dgvConversiones = new DataGridView();
            this.cmbUnidadDeMedidaFrom = new ComboBox();
            this.cmbUnidadDeMedidaTo = new ComboBox();
            this.cmbInsumo = new ComboBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.btnAgregar = new Button();
            this.btnEliminar = new Button();
            this.btnModificar = new Button();
            this.nudCantidadFrom = new NumericUpDown();
            this.nudCantidadTo = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)this.dgvConversiones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudCantidadFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudCantidadTo).BeginInit();
            SuspendLayout();
            // 
            // dgvConversiones
            // 
            this.dgvConversiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConversiones.Dock = DockStyle.Bottom;
            this.dgvConversiones.Location = new Point(0, 122);
            this.dgvConversiones.Name = "dgvConversiones";
            this.dgvConversiones.Size = new Size(486, 120);
            this.dgvConversiones.TabIndex = 0;
            // 
            // cmbUnidadDeMedidaFrom
            // 
            this.cmbUnidadDeMedidaFrom.FormattingEnabled = true;
            this.cmbUnidadDeMedidaFrom.Location = new Point(186, 27);
            this.cmbUnidadDeMedidaFrom.Name = "cmbUnidadDeMedidaFrom";
            this.cmbUnidadDeMedidaFrom.Size = new Size(121, 23);
            this.cmbUnidadDeMedidaFrom.TabIndex = 1;
            // 
            // cmbUnidadDeMedidaTo
            // 
            this.cmbUnidadDeMedidaTo.FormattingEnabled = true;
            this.cmbUnidadDeMedidaTo.Location = new Point(344, 27);
            this.cmbUnidadDeMedidaTo.Name = "cmbUnidadDeMedidaTo";
            this.cmbUnidadDeMedidaTo.Size = new Size(121, 23);
            this.cmbUnidadDeMedidaTo.TabIndex = 2;
            // 
            // cmbInsumo
            // 
            this.cmbInsumo.FormattingEnabled = true;
            this.cmbInsumo.Location = new Point(12, 27);
            this.cmbInsumo.Name = "cmbInsumo";
            this.cmbInsumo.Size = new Size(121, 23);
            this.cmbInsumo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(313, 44);
            this.label1.Name = "label1";
            this.label1.Size = new Size(25, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "-->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new Size(47, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Insumo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(236, 9);
            this.label3.Name = "label3";
            this.label3.Size = new Size(21, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "De";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(386, 7);
            this.label4.Name = "label4";
            this.label4.Size = new Size(37, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Hacia";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(6, 93);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(152, 23);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(164, 93);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(152, 23);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(322, 93);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(152, 23);
            this.btnModificar.TabIndex = 10;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // nudCantidadFrom
            // 
            this.nudCantidadFrom.Location = new Point(186, 56);
            this.nudCantidadFrom.Name = "nudCantidadFrom";
            this.nudCantidadFrom.Size = new Size(121, 23);
            this.nudCantidadFrom.TabIndex = 11;
            // 
            // nudCantidadTo
            // 
            this.nudCantidadTo.Location = new Point(344, 56);
            this.nudCantidadTo.Name = "nudCantidadTo";
            this.nudCantidadTo.Size = new Size(121, 23);
            this.nudCantidadTo.TabIndex = 12;
            // 
            // GestorConversiones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 242);
            Controls.Add(this.nudCantidadTo);
            Controls.Add(this.nudCantidadFrom);
            Controls.Add(this.btnModificar);
            Controls.Add(this.btnEliminar);
            Controls.Add(this.btnAgregar);
            Controls.Add(this.label4);
            Controls.Add(this.label3);
            Controls.Add(this.label2);
            Controls.Add(this.label1);
            Controls.Add(this.cmbInsumo);
            Controls.Add(this.cmbUnidadDeMedidaTo);
            Controls.Add(this.cmbUnidadDeMedidaFrom);
            Controls.Add(this.dgvConversiones);
            Name = "GestorConversiones";
            Text = "GestorConversiones";
            Load += GestorConversiones_Load;
            ((System.ComponentModel.ISupportInitialize)this.dgvConversiones).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudCantidadFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudCantidadTo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvConversiones;
        private ComboBox cmbUnidadDeMedidaFrom;
        private ComboBox cmbUnidadDeMedidaTo;
        private ComboBox cmbInsumo;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnModificar;
        private NumericUpDown nudCantidadFrom;
        private NumericUpDown nudCantidadTo;
    }
}