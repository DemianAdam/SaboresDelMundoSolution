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
            this.dataGridView1 = new DataGridView();
            this.comboBox1 = new ComboBox();
            this.comboBox2 = new ComboBox();
            this.comboBox3 = new ComboBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.button1 = new Button();
            this.button2 = new Button();
            this.button3 = new Button();
            this.numericUpDown1 = new NumericUpDown();
            this.numericUpDown2 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = DockStyle.Bottom;
            this.dataGridView1.Location = new Point(0, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new Size(486, 120);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(186, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(121, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new Point(344, 27);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new Size(121, 23);
            this.comboBox2.TabIndex = 2;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new Point(12, 27);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new Size(121, 23);
            this.comboBox3.TabIndex = 3;
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
            // button1
            // 
            this.button1.Location = new Point(6, 93);
            this.button1.Name = "button1";
            this.button1.Size = new Size(152, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new Point(164, 93);
            this.button2.Name = "button2";
            this.button2.Size = new Size(152, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new Point(322, 93);
            this.button3.Name = "button3";
            this.button3.Size = new Size(152, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Modificar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new Point(186, 56);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new Size(121, 23);
            this.numericUpDown1.TabIndex = 11;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new Point(344, 56);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new Size(121, 23);
            this.numericUpDown2.TabIndex = 12;
            // 
            // GestorConversiones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 242);
            Controls.Add(this.numericUpDown2);
            Controls.Add(this.numericUpDown1);
            Controls.Add(this.button3);
            Controls.Add(this.button2);
            Controls.Add(this.button1);
            Controls.Add(this.label4);
            Controls.Add(this.label3);
            Controls.Add(this.label2);
            Controls.Add(this.label1);
            Controls.Add(this.comboBox3);
            Controls.Add(this.comboBox2);
            Controls.Add(this.comboBox1);
            Controls.Add(this.dataGridView1);
            Name = "GestorConversiones";
            Text = "GestorConversiones";
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
        private Button button3;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
    }
}