using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomRendererTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            graphics = CreateGraphics();
        }

        protected Graphics graphics;

        int pixels = 0;

        private void OnButtonClick(object sender, EventArgs e)
        {
            graphics.FillRectangle(Brushes.Red, (pixels*2)%(this.Width+1), (pixels*2)/this.Width, 2, 2);
            pixels++;
        }
    }
}
