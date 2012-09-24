namespace NumToColor
{
    partial class ColorCube
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_color = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_color
            // 
            this.lb_color.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_color.AutoSize = true;
            this.lb_color.Location = new System.Drawing.Point(45, 2);
            this.lb_color.Name = "lb_color";
            this.lb_color.Size = new System.Drawing.Size(47, 12);
            this.lb_color.TabIndex = 0;
            this.lb_color.Text = "0XFFFFF";
            // 
            // ColorCube
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lb_color);
            this.Name = "ColorCube";
            this.Size = new System.Drawing.Size(109, 22);
            this.DoubleClick += new System.EventHandler(this.ColorCube_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_color;
    }
}
