namespace WinForm_UI
{
    partial class Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new MenuStrip();
            this.productosToolStripMenuItem = new ToolStripMenuItem();
            this.gestorProductosToolStripMenuItem = new ToolStripMenuItem();
            this.tiposDeProductosToolStripMenuItem = new ToolStripMenuItem();
            this.insumosToolStripMenuItem = new ToolStripMenuItem();
            this.gestorInsumosToolStripMenuItem = new ToolStripMenuItem();
            this.tiposDeInsumoToolStripMenuItem = new ToolStripMenuItem();
            this.configuracionesToolStripMenuItem = new ToolStripMenuItem();
            this.unidadesDeMedidaToolStripMenuItem = new ToolStripMenuItem();
            this.comprasToolStripMenuItem = new ToolStripMenuItem();
            this.gestorComprasToolStripMenuItem = new ToolStripMenuItem();
            this.gestorProveedoresToolStripMenuItem = new ToolStripMenuItem();
            this.statusStrip1 = new StatusStrip();
            this.slblTime = new ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.statusStrip2 = new StatusStrip();
            this.toolStripStatusLabel2 = new ToolStripStatusLabel();
            this.recetasToolStripMenuItem = new ToolStripMenuItem();
            this.gestorDeRecetasToolStripMenuItem = new ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = DockStyle.Left;
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.productosToolStripMenuItem, this.insumosToolStripMenuItem, this.configuracionesToolStripMenuItem, this.comprasToolStripMenuItem, this.recetasToolStripMenuItem });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(126, 450);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.gestorProductosToolStripMenuItem, this.tiposDeProductosToolStripMenuItem });
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new Size(113, 19);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // gestorProductosToolStripMenuItem
            // 
            this.gestorProductosToolStripMenuItem.Name = "gestorProductosToolStripMenuItem";
            this.gestorProductosToolStripMenuItem.Size = new Size(175, 22);
            this.gestorProductosToolStripMenuItem.Text = "Gestor Productos";
            this.gestorProductosToolStripMenuItem.Click += gestorProductosToolStripMenuItem_Click;
            // 
            // tiposDeProductosToolStripMenuItem
            // 
            this.tiposDeProductosToolStripMenuItem.Name = "tiposDeProductosToolStripMenuItem";
            this.tiposDeProductosToolStripMenuItem.Size = new Size(175, 22);
            this.tiposDeProductosToolStripMenuItem.Text = "Tipos de Productos";
            this.tiposDeProductosToolStripMenuItem.Click += tiposDeProductosToolStripMenuItem_Click;
            // 
            // insumosToolStripMenuItem
            // 
            this.insumosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.gestorInsumosToolStripMenuItem, this.tiposDeInsumoToolStripMenuItem });
            this.insumosToolStripMenuItem.Name = "insumosToolStripMenuItem";
            this.insumosToolStripMenuItem.Size = new Size(113, 19);
            this.insumosToolStripMenuItem.Text = "Insumos";
            // 
            // gestorInsumosToolStripMenuItem
            // 
            this.gestorInsumosToolStripMenuItem.Name = "gestorInsumosToolStripMenuItem";
            this.gestorInsumosToolStripMenuItem.Size = new Size(161, 22);
            this.gestorInsumosToolStripMenuItem.Text = "Gestor Insumos";
            this.gestorInsumosToolStripMenuItem.Click += gestorInsumosToolStripMenuItem_Click;
            // 
            // tiposDeInsumoToolStripMenuItem
            // 
            this.tiposDeInsumoToolStripMenuItem.Name = "tiposDeInsumoToolStripMenuItem";
            this.tiposDeInsumoToolStripMenuItem.Size = new Size(161, 22);
            this.tiposDeInsumoToolStripMenuItem.Text = "Tipos de Insumo";
            this.tiposDeInsumoToolStripMenuItem.Click += tiposDeInsumoToolStripMenuItem_Click;
            // 
            // configuracionesToolStripMenuItem
            // 
            this.configuracionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.unidadesDeMedidaToolStripMenuItem });
            this.configuracionesToolStripMenuItem.Name = "configuracionesToolStripMenuItem";
            this.configuracionesToolStripMenuItem.Size = new Size(113, 19);
            this.configuracionesToolStripMenuItem.Text = "Configuraciones";
            // 
            // unidadesDeMedidaToolStripMenuItem
            // 
            this.unidadesDeMedidaToolStripMenuItem.Name = "unidadesDeMedidaToolStripMenuItem";
            this.unidadesDeMedidaToolStripMenuItem.Size = new Size(182, 22);
            this.unidadesDeMedidaToolStripMenuItem.Text = "Unidades de Medida";
            this.unidadesDeMedidaToolStripMenuItem.Click += unidadesDeMedidaToolStripMenuItem_Click;
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.gestorComprasToolStripMenuItem, this.gestorProveedoresToolStripMenuItem });
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new Size(113, 19);
            this.comprasToolStripMenuItem.Text = "Compras";
            // 
            // gestorComprasToolStripMenuItem
            // 
            this.gestorComprasToolStripMenuItem.Name = "gestorComprasToolStripMenuItem";
            this.gestorComprasToolStripMenuItem.Size = new Size(176, 22);
            this.gestorComprasToolStripMenuItem.Text = "Gestor Compras";
            this.gestorComprasToolStripMenuItem.Click += gestorComprasToolStripMenuItem_Click;
            // 
            // gestorProveedoresToolStripMenuItem
            // 
            this.gestorProveedoresToolStripMenuItem.Name = "gestorProveedoresToolStripMenuItem";
            this.gestorProveedoresToolStripMenuItem.Size = new Size(176, 22);
            this.gestorProveedoresToolStripMenuItem.Text = "Gestor Proveedores";
            this.gestorProveedoresToolStripMenuItem.Click += gestorProveedoresToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new ToolStripItem[] { this.slblTime });
            this.statusStrip1.Location = new Point(126, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new Size(674, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slblTime
            // 
            this.slblTime.Name = "slblTime";
            this.slblTime.Size = new Size(659, 17);
            this.slblTime.Spring = true;
            this.slblTime.Text = "toolStripStatusLabel2";
            this.slblTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += timerClock_Tick;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Dock = DockStyle.Top;
            this.statusStrip2.Items.AddRange(new ToolStripItem[] { this.toolStripStatusLabel2 });
            this.statusStrip2.Location = new Point(126, 0);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new Size(674, 22);
            this.statusStrip2.TabIndex = 10;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new Size(33, 17);
            this.toolStripStatusLabel2.Text = "Caja:";
            // 
            // recetasToolStripMenuItem
            // 
            this.recetasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.gestorDeRecetasToolStripMenuItem });
            this.recetasToolStripMenuItem.Name = "recetasToolStripMenuItem";
            this.recetasToolStripMenuItem.Size = new Size(113, 19);
            this.recetasToolStripMenuItem.Text = "Recetas";
            // 
            // gestorDeRecetasToolStripMenuItem
            // 
            this.gestorDeRecetasToolStripMenuItem.Name = "gestorDeRecetasToolStripMenuItem";
            this.gestorDeRecetasToolStripMenuItem.Size = new Size(180, 22);
            this.gestorDeRecetasToolStripMenuItem.Text = "Gestor de Recetas";
            this.gestorDeRecetasToolStripMenuItem.Click += gestorDeRecetasToolStripMenuItem_Click;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(this.statusStrip2);
            Controls.Add(this.statusStrip1);
            Controls.Add(this.menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = this.menuStrip1;
            Name = "Principal";
            Text = "Form1";
            Load += Principal_Load;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem gestorProductosToolStripMenuItem;
        private ToolStripMenuItem tiposDeProductosToolStripMenuItem;
        private ToolStripMenuItem insumosToolStripMenuItem;
        private ToolStripMenuItem gestorInsumosToolStripMenuItem;
        private ToolStripMenuItem tiposDeInsumoToolStripMenuItem;
        private ToolStripMenuItem configuracionesToolStripMenuItem;
        private ToolStripMenuItem unidadesDeMedidaToolStripMenuItem;
        private ToolStripMenuItem comprasToolStripMenuItem;
        private ToolStripMenuItem gestorComprasToolStripMenuItem;
        private ToolStripMenuItem gestorProveedoresToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel slblTime;
        private System.Windows.Forms.Timer timerClock;
        private StatusStrip statusStrip2;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripMenuItem recetasToolStripMenuItem;
        private ToolStripMenuItem gestorDeRecetasToolStripMenuItem;
    }
}
