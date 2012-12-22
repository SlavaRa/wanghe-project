using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PluginCore;

namespace NumToColor
{
    public partial class ColorCube : UserControl
    {
        private Color _color;

        public event SelectColorEventHandler SelectColor;

        public ColorCube()
        {
            InitializeComponent();
            DoubleBuffered = true;
            btnEdit.Image = PluginBase.MainForm.FindImage("328");
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

        //文本的双击事件
        private void lb_color_DoubleClick(object sender, EventArgs e)
        {
            SelectColorEventArgs e2 = new SelectColorEventArgs();
            e2.color = _color;
            OnSelectColor(e2);
        }

        protected void OnSelectColor(SelectColorEventArgs e)
        {
            if (SelectColor!=null)
            {
                SelectColor(this,e);
            }
            this.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SelectColorEventArgs e2 = new SelectColorEventArgs();
            e2.color = _color;
            OnSelectColor(e2);
        }

        //public event 
    }

    //选取颜色的事件委托
    public delegate void SelectColorEventHandler(Object sender,SelectColorEventArgs e);
    //选取颜色的事件参数
    public class SelectColorEventArgs : EventArgs
    {
        public Color color;
        public SelectColorEventArgs()
        {

        }
    }
}
