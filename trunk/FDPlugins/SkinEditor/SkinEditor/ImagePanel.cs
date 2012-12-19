using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace SkinEditor
{
    public partial class ImagePanel : UserControl
    {
        private string _imagePath = ""; //图片路径
        private int _gridX = 0;         //九宫格的X
        private int _gridY = 0;         //九宫格的Y
        private int _gridWidth = 0;     //九宫格的宽度
        private int _gridHeight = 0;    //九宫格的高度

        private Bitmap bitmap = null;   //绘图用bitmap

        private int PosX = 10;//X偏移量
        private int PosY = 10;//Y偏移量

        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
                checkImage(_imagePath);
            }
        }

        /// <summary>
        /// 九宫格的X
        /// </summary>
        public int GridX
        {
            get { return _gridX; }
            set { _gridX = value; }
        }
        /// <summary>
        /// 九宫格的Y
        /// </summary>
        public int GridY
        {
            get { return _gridY; }
            set { _gridY = value; }
        }
        /// <summary>
        /// 九宫格的宽度
        /// </summary>
        public int GridWidth
        {
            get { return _gridWidth; }
            set { _gridWidth = value; }
        }
        /// <summary>
        /// 九宫格的高度
        /// </summary>
        public int GridHeight
        {
            get { return _gridHeight; }
            set { _gridHeight = value; }
        }
        /// <summary>
        /// 图片预览控件
        /// </summary>
        public ImagePanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            drawImag();
            drawLine();
        }

        /// <summary>
        /// 检查 更新BitMap
        /// </summary>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        private void checkImage(string imgPath)
        {
            //文件存在
            if (File.Exists(imgPath))
            {
                bitmap = (Bitmap)Image.FromFile(imgPath, true);
                this.Invalidate();
            }
            else
            {
                if (bitmap != null)
                {
                    bitmap.Dispose();
                    bitmap = null;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// 绘图
        /// </summary>
        private void drawImag()
        {
            if (bitmap == null)
                return;

            //绘图矩形
            Rectangle rect = new Rectangle(PosX, PosY, bitmap.Width, bitmap.Height);

            Graphics g = this.CreateGraphics();

            TextureBrush b2 = new TextureBrush(bitmap);
            b2.WrapMode = WrapMode.Clamp;
            b2.TranslateTransform(PosX, PosY);
            g.FillRectangle(b2, rect);

            g.Dispose();
        }


        /// <summary>
        /// 画九宫格
        /// </summary>
        private void drawLine()
        {
            Pen p = new Pen(Color.Red, 1);
            Graphics g = this.CreateGraphics();

            //横线
            g.DrawLine(p, new Point(0, GridY + PosY), new Point(this.Width, GridY + PosY));
            g.DrawLine(p, new Point(0, GridY + PosY + GridHeight), new Point(Width, GridY + PosY + GridHeight));

            p.Color = Color.Blue;

            //竖线
            g.DrawLine(p, new Point(GridX + PosX, 0), new Point(GridX + PosX, this.Height));
            g.DrawLine(p, new Point(GridX + PosX + GridWidth, 0), new Point(GridX + PosX + GridWidth, this.Height));

            p.Dispose();
            g.Dispose();
        }


    }
}
