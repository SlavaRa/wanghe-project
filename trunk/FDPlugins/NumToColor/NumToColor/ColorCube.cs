using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NumToColor
{
    public partial class ColorCube : UserControl
    {
        private Color _color;

        public ColorCube()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void ShowColor(string color)
        {
            _color = ColorTranslator.FromHtml(color);
            lb_color.Text = color;
            this.Refresh();
        }

        public void clearColor()
        {
            _color = Color.Empty;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_color == Color.Empty) return;
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(_color), new Rectangle(0, 0, 50, 22));
        }

        private void ColorCube_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
