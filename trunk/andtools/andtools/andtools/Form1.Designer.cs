namespace andtools
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this._btnref = new System.Windows.Forms.Button();
            this._lbinfo = new System.Windows.Forms.Label();
            this._btnsavepath = new System.Windows.Forms.Button();
            this._btnselapk = new System.Windows.Forms.Button();
            this._txtsavepath = new System.Windows.Forms.TextBox();
            this._txtapk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this._btnopenpath = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._btnopenpath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this._btnref);
            this.groupBox1.Controls.Add(this._lbinfo);
            this.groupBox1.Controls.Add(this._btnsavepath);
            this.groupBox1.Controls.Add(this._btnselapk);
            this.groupBox1.Controls.Add(this._txtsavepath);
            this.groupBox1.Controls.Add(this._txtapk);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "反编译";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "状态：";
            // 
            // _btnref
            // 
            this._btnref.Location = new System.Drawing.Point(555, 87);
            this._btnref.Name = "_btnref";
            this._btnref.Size = new System.Drawing.Size(89, 23);
            this._btnref.TabIndex = 6;
            this._btnref.Text = "反编译";
            this._btnref.UseVisualStyleBackColor = true;
            this._btnref.Click += new System.EventHandler(this._btnref_Click);
            // 
            // _lbinfo
            // 
            this._lbinfo.AutoSize = true;
            this._lbinfo.Location = new System.Drawing.Point(101, 98);
            this._lbinfo.Name = "_lbinfo";
            this._lbinfo.Size = new System.Drawing.Size(41, 12);
            this._lbinfo.TabIndex = 5;
            this._lbinfo.Text = "就绪！";
            // 
            // _btnsavepath
            // 
            this._btnsavepath.Location = new System.Drawing.Point(597, 50);
            this._btnsavepath.Name = "_btnsavepath";
            this._btnsavepath.Size = new System.Drawing.Size(47, 23);
            this._btnsavepath.TabIndex = 4;
            this._btnsavepath.Text = "...";
            this._btnsavepath.UseVisualStyleBackColor = true;
            this._btnsavepath.Click += new System.EventHandler(this._savepath_Click);
            // 
            // _btnselapk
            // 
            this._btnselapk.Location = new System.Drawing.Point(597, 23);
            this._btnselapk.Name = "_btnselapk";
            this._btnselapk.Size = new System.Drawing.Size(47, 23);
            this._btnselapk.TabIndex = 3;
            this._btnselapk.Text = "...";
            this._btnselapk.UseVisualStyleBackColor = true;
            this._btnselapk.Click += new System.EventHandler(this._btnselapk_Click);
            // 
            // _txtsavepath
            // 
            this._txtsavepath.Location = new System.Drawing.Point(103, 51);
            this._txtsavepath.Name = "_txtsavepath";
            this._txtsavepath.Size = new System.Drawing.Size(488, 21);
            this._txtsavepath.TabIndex = 2;
            // 
            // _txtapk
            // 
            this._txtapk.Location = new System.Drawing.Point(103, 24);
            this._txtapk.Name = "_txtapk";
            this._txtapk.Size = new System.Drawing.Size(488, 21);
            this._txtapk.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "文件保存路径：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "APK路径：";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(651, 151);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "编译";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "e";
            this.openFileDialog1.Filter = "APK files(*.apk)|*.apk";
            // 
            // _btnopenpath
            // 
            this._btnopenpath.Location = new System.Drawing.Point(458, 87);
            this._btnopenpath.Name = "_btnopenpath";
            this._btnopenpath.Size = new System.Drawing.Size(84, 23);
            this._btnopenpath.TabIndex = 8;
            this._btnopenpath.Text = "打开文件夹";
            this._btnopenpath.UseVisualStyleBackColor = true;
            this._btnopenpath.Click += new System.EventHandler(this._btnopenpath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 299);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AndTools";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtapk;
        private System.Windows.Forms.TextBox _txtsavepath;
        private System.Windows.Forms.Button _btnsavepath;
        private System.Windows.Forms.Button _btnselapk;
        private System.Windows.Forms.Label _lbinfo;
        private System.Windows.Forms.Button _btnref;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button _btnopenpath;
    }
}

