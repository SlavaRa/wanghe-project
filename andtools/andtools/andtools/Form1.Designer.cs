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
            this._btnopenpath = new System.Windows.Forms.Button();
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
            this._btnsavesignapk = new System.Windows.Forms.Button();
            this._txtsignapk = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._lbinfo2 = new System.Windows.Forms.Label();
            this._btnopenapk = new System.Windows.Forms.Button();
            this._btnsign = new System.Windows.Forms.Button();
            this._btnbuild = new System.Windows.Forms.Button();
            this._btnbuildspkpath = new System.Windows.Forms.Button();
            this._btnselbuildpath = new System.Windows.Forms.Button();
            this._txtbuildapkpath = new System.Windows.Forms.TextBox();
            this._txtbuildpath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // _btnopenpath
            // 
            this._btnopenpath.Location = new System.Drawing.Point(458, 87);
            this._btnopenpath.Name = "_btnopenpath";
            this._btnopenpath.Size = new System.Drawing.Size(90, 23);
            this._btnopenpath.TabIndex = 8;
            this._btnopenpath.Text = "打开文件夹";
            this._btnopenpath.UseVisualStyleBackColor = true;
            this._btnopenpath.Click += new System.EventHandler(this._btnopenpath_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "状态：";
            // 
            // _btnref
            // 
            this._btnref.Location = new System.Drawing.Point(555, 87);
            this._btnref.Name = "_btnref";
            this._btnref.Size = new System.Drawing.Size(90, 23);
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
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "文件保存目录：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "APK路径：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._btnsavesignapk);
            this.groupBox2.Controls.Add(this._txtsignapk);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this._lbinfo2);
            this.groupBox2.Controls.Add(this._btnopenapk);
            this.groupBox2.Controls.Add(this._btnsign);
            this.groupBox2.Controls.Add(this._btnbuild);
            this.groupBox2.Controls.Add(this._btnbuildspkpath);
            this.groupBox2.Controls.Add(this._btnselbuildpath);
            this.groupBox2.Controls.Add(this._txtbuildapkpath);
            this.groupBox2.Controls.Add(this._txtbuildpath);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(651, 179);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "编译";
            // 
            // _btnsavesignapk
            // 
            this._btnsavesignapk.Location = new System.Drawing.Point(598, 82);
            this._btnsavesignapk.Name = "_btnsavesignapk";
            this._btnsavesignapk.Size = new System.Drawing.Size(47, 23);
            this._btnsavesignapk.TabIndex = 14;
            this._btnsavesignapk.Text = "...";
            this._btnsavesignapk.UseVisualStyleBackColor = true;
            this._btnsavesignapk.Click += new System.EventHandler(this._btnsavesignapk_Click);
            // 
            // _txtsignapk
            // 
            this._txtsignapk.Location = new System.Drawing.Point(104, 82);
            this._txtsignapk.Name = "_txtsignapk";
            this._txtsignapk.Size = new System.Drawing.Size(488, 21);
            this._txtsignapk.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "签名APK路径:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "状态：";
            // 
            // _lbinfo2
            // 
            this._lbinfo2.AutoSize = true;
            this._lbinfo2.Location = new System.Drawing.Point(102, 130);
            this._lbinfo2.Name = "_lbinfo2";
            this._lbinfo2.Size = new System.Drawing.Size(23, 12);
            this._lbinfo2.TabIndex = 10;
            this._lbinfo2.Text = "...";
            // 
            // _btnopenapk
            // 
            this._btnopenapk.Location = new System.Drawing.Point(362, 130);
            this._btnopenapk.Name = "_btnopenapk";
            this._btnopenapk.Size = new System.Drawing.Size(90, 23);
            this._btnopenapk.TabIndex = 9;
            this._btnopenapk.Text = "打开文件夹";
            this._btnopenapk.UseVisualStyleBackColor = true;
            this._btnopenapk.Click += new System.EventHandler(this._btnopenapk_Click);
            // 
            // _btnsign
            // 
            this._btnsign.Location = new System.Drawing.Point(458, 130);
            this._btnsign.Name = "_btnsign";
            this._btnsign.Size = new System.Drawing.Size(90, 23);
            this._btnsign.TabIndex = 8;
            this._btnsign.Text = "签名";
            this._btnsign.UseVisualStyleBackColor = true;
            this._btnsign.Click += new System.EventHandler(this._btnsign_Click);
            // 
            // _btnbuild
            // 
            this._btnbuild.Location = new System.Drawing.Point(555, 130);
            this._btnbuild.Name = "_btnbuild";
            this._btnbuild.Size = new System.Drawing.Size(90, 23);
            this._btnbuild.TabIndex = 7;
            this._btnbuild.Text = "编译";
            this._btnbuild.UseVisualStyleBackColor = true;
            this._btnbuild.Click += new System.EventHandler(this._btnbuild_Click);
            // 
            // _btnbuildspkpath
            // 
            this._btnbuildspkpath.Location = new System.Drawing.Point(598, 52);
            this._btnbuildspkpath.Name = "_btnbuildspkpath";
            this._btnbuildspkpath.Size = new System.Drawing.Size(47, 23);
            this._btnbuildspkpath.TabIndex = 6;
            this._btnbuildspkpath.Text = "...";
            this._btnbuildspkpath.UseVisualStyleBackColor = true;
            this._btnbuildspkpath.Click += new System.EventHandler(this._btnbuildspkpath_Click);
            // 
            // _btnselbuildpath
            // 
            this._btnselbuildpath.Location = new System.Drawing.Point(598, 24);
            this._btnselbuildpath.Name = "_btnselbuildpath";
            this._btnselbuildpath.Size = new System.Drawing.Size(47, 23);
            this._btnselbuildpath.TabIndex = 5;
            this._btnselbuildpath.Text = "...";
            this._btnselbuildpath.UseVisualStyleBackColor = true;
            this._btnselbuildpath.Click += new System.EventHandler(this._btnselbuildpath_Click);
            // 
            // _txtbuildapkpath
            // 
            this._txtbuildapkpath.Location = new System.Drawing.Point(103, 52);
            this._txtbuildapkpath.Name = "_txtbuildapkpath";
            this._txtbuildapkpath.Size = new System.Drawing.Size(488, 21);
            this._txtbuildapkpath.TabIndex = 3;
            // 
            // _txtbuildpath
            // 
            this._txtbuildpath.Location = new System.Drawing.Point(103, 24);
            this._txtbuildpath.Name = "_txtbuildpath";
            this._txtbuildpath.Size = new System.Drawing.Size(488, 21);
            this._txtbuildpath.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "APK保存路径：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "文件目录：";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "APK files(*.apk)|*.apk";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "APK files(*.apk)|*.apk";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 326);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AndTools";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _txtbuildapkpath;
        private System.Windows.Forms.TextBox _txtbuildpath;
        private System.Windows.Forms.Button _btnbuildspkpath;
        private System.Windows.Forms.Button _btnselbuildpath;
        private System.Windows.Forms.Button _btnbuild;
        private System.Windows.Forms.Button _btnsign;
        private System.Windows.Forms.Button _btnopenapk;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label _lbinfo2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button _btnsavesignapk;
        private System.Windows.Forms.TextBox _txtsignapk;
    }
}

