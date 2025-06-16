using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_UI
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            NumericUpDown nud = new NumericUpDown();
            nud.Location = new Point(label1.Location.X + label1.Width + label1.Margin.Right, label1.Location.Y-2);
            panel1.Controls.Add(nud);
        }
    }
}
