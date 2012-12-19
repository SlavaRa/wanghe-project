namespace SkinEditor
{
    partial class SkinEditorForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lstSkin = new System.Windows.Forms.ListView();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.type = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gp = new System.Windows.Forms.GroupBox();
            this.btnSelectName = new System.Windows.Forms.Button();
            this.chkName = new System.Windows.Forms.CheckBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.chkLink = new System.Windows.Forms.CheckBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.chkHeight = new System.Windows.Forms.CheckBox();
            this.chkWidth = new System.Windows.Forms.CheckBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.chkY = new System.Windows.Forms.CheckBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.chkX = new System.Windows.Forms.CheckBox();
            this.lbNodeName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.skinName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.GroupBox();
            this.hSub = new System.Windows.Forms.Button();
            this.hPlus = new System.Windows.Forms.Button();
            this.wSub = new System.Windows.Forms.Button();
            this.wPlus = new System.Windows.Forms.Button();
            this.ySub = new System.Windows.Forms.Button();
            this.yPlus = new System.Windows.Forms.Button();
            this.xSub = new System.Windows.Forms.Button();
            this.xPlus = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.chkComment = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstNode = new System.Windows.Forms.ListView();
            this.nodeName = new System.Windows.Forms.ColumnHeader();
            this.nodeValue = new System.Windows.Forms.ColumnHeader();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imgPanel = new SkinEditor.ImagePanel();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.gp.SuspendLayout();
            this.btnCopy.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.txtFilter);
            this.groupBox1.Controls.Add(this.lstSkin);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 497);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Skin.xml";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(175, 464);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(47, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(5, 464);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(164, 21);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lstSkin
            // 
            this.lstSkin.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.type});
            this.lstSkin.ContextMenuStrip = this.contextMenuStrip1;
            this.lstSkin.FullRowSelect = true;
            this.lstSkin.GridLines = true;
            this.lstSkin.HideSelection = false;
            this.lstSkin.Location = new System.Drawing.Point(3, 17);
            this.lstSkin.MultiSelect = false;
            this.lstSkin.Name = "lstSkin";
            this.lstSkin.Size = new System.Drawing.Size(222, 439);
            this.lstSkin.TabIndex = 0;
            this.lstSkin.UseCompatibleStateImageBehavior = false;
            this.lstSkin.View = System.Windows.Forms.View.Details;
            this.lstSkin.SelectedIndexChanged += new System.EventHandler(this.lstSkin_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 155;
            // 
            // type
            // 
            this.type.Text = "Type";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // gp
            // 
            this.gp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gp.Controls.Add(this.imgPanel);
            this.gp.Location = new System.Drawing.Point(246, 12);
            this.gp.Name = "gp";
            this.gp.Size = new System.Drawing.Size(539, 368);
            this.gp.TabIndex = 1;
            this.gp.TabStop = false;
            this.gp.Text = "图片";
            // 
            // btnSelectName
            // 
            this.btnSelectName.Location = new System.Drawing.Point(233, 240);
            this.btnSelectName.Name = "btnSelectName";
            this.btnSelectName.Size = new System.Drawing.Size(32, 23);
            this.btnSelectName.TabIndex = 20;
            this.btnSelectName.Text = "...";
            this.btnSelectName.UseVisualStyleBackColor = true;
            this.btnSelectName.Click += new System.EventHandler(this.btnSelectName_Click);
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Location = new System.Drawing.Point(10, 239);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(54, 16);
            this.chkName.TabIndex = 18;
            this.chkName.Text = "name:";
            this.chkName.UseVisualStyleBackColor = true;
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(72, 208);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(98, 21);
            this.txtLink.TabIndex = 17;
            this.txtLink.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLink_KeyDown);
            this.txtLink.Leave += new System.EventHandler(this.txtLink_Leave);
            // 
            // chkLink
            // 
            this.chkLink.AutoSize = true;
            this.chkLink.Location = new System.Drawing.Point(10, 210);
            this.chkLink.Name = "chkLink";
            this.chkLink.Size = new System.Drawing.Size(54, 16);
            this.chkLink.TabIndex = 16;
            this.chkLink.Text = "link:";
            this.chkLink.UseVisualStyleBackColor = true;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(72, 179);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(96, 21);
            this.txtHeight.TabIndex = 15;
            this.txtHeight.Text = "0";
            this.txtHeight.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(72, 150);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(96, 21);
            this.txtWidth.TabIndex = 14;
            this.txtWidth.Text = "0";
            this.txtWidth.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // chkHeight
            // 
            this.chkHeight.AutoSize = true;
            this.chkHeight.Location = new System.Drawing.Point(10, 182);
            this.chkHeight.Name = "chkHeight";
            this.chkHeight.Size = new System.Drawing.Size(66, 16);
            this.chkHeight.TabIndex = 13;
            this.chkHeight.Text = "height:";
            this.chkHeight.UseVisualStyleBackColor = true;
            // 
            // chkWidth
            // 
            this.chkWidth.AutoSize = true;
            this.chkWidth.Location = new System.Drawing.Point(10, 152);
            this.chkWidth.Name = "chkWidth";
            this.chkWidth.Size = new System.Drawing.Size(60, 16);
            this.chkWidth.TabIndex = 12;
            this.chkWidth.Text = "width:";
            this.chkWidth.UseVisualStyleBackColor = true;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(72, 121);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(95, 21);
            this.txtY.TabIndex = 11;
            this.txtY.Text = "0";
            this.txtY.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // chkY
            // 
            this.chkY.AutoSize = true;
            this.chkY.Location = new System.Drawing.Point(10, 124);
            this.chkY.Name = "chkY";
            this.chkY.Size = new System.Drawing.Size(42, 16);
            this.chkY.TabIndex = 10;
            this.chkY.Text = "y：";
            this.chkY.UseVisualStyleBackColor = true;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(72, 92);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(95, 21);
            this.txtX.TabIndex = 9;
            this.txtX.Text = "0";
            this.txtX.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // chkX
            // 
            this.chkX.AutoSize = true;
            this.chkX.Location = new System.Drawing.Point(10, 94);
            this.chkX.Name = "chkX";
            this.chkX.Size = new System.Drawing.Size(42, 16);
            this.chkX.TabIndex = 8;
            this.chkX.Text = "x：";
            this.chkX.UseVisualStyleBackColor = true;
            // 
            // lbNodeName
            // 
            this.lbNodeName.AutoSize = true;
            this.lbNodeName.Location = new System.Drawing.Point(63, 73);
            this.lbNodeName.Name = "lbNodeName";
            this.lbNodeName.Size = new System.Drawing.Size(53, 12);
            this.lbNodeName.TabIndex = 6;
            this.lbNodeName.Text = "NODENAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "节点名：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(158, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(56, 17);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(69, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // skinName
            // 
            this.skinName.Location = new System.Drawing.Point(56, 47);
            this.skinName.Name = "skinName";
            this.skinName.Size = new System.Drawing.Size(177, 21);
            this.skinName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "皮肤名：";
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Controls.Add(this.hSub);
            this.btnCopy.Controls.Add(this.hPlus);
            this.btnCopy.Controls.Add(this.wSub);
            this.btnCopy.Controls.Add(this.wPlus);
            this.btnCopy.Controls.Add(this.ySub);
            this.btnCopy.Controls.Add(this.yPlus);
            this.btnCopy.Controls.Add(this.xSub);
            this.btnCopy.Controls.Add(this.xPlus);
            this.btnCopy.Controls.Add(this.txtComment);
            this.btnCopy.Controls.Add(this.chkComment);
            this.btnCopy.Controls.Add(this.button3);
            this.btnCopy.Controls.Add(this.txtName);
            this.btnCopy.Controls.Add(this.btnSelectName);
            this.btnCopy.Controls.Add(this.skinName);
            this.btnCopy.Controls.Add(this.label1);
            this.btnCopy.Controls.Add(this.chkName);
            this.btnCopy.Controls.Add(this.btnSave);
            this.btnCopy.Controls.Add(this.txtHeight);
            this.btnCopy.Controls.Add(this.chkHeight);
            this.btnCopy.Controls.Add(this.txtLink);
            this.btnCopy.Controls.Add(this.chkLink);
            this.btnCopy.Controls.Add(this.txtY);
            this.btnCopy.Controls.Add(this.chkY);
            this.btnCopy.Controls.Add(this.btnNew);
            this.btnCopy.Controls.Add(this.lbNodeName);
            this.btnCopy.Controls.Add(this.label2);
            this.btnCopy.Controls.Add(this.txtWidth);
            this.btnCopy.Controls.Add(this.txtX);
            this.btnCopy.Controls.Add(this.chkWidth);
            this.btnCopy.Controls.Add(this.chkX);
            this.btnCopy.Location = new System.Drawing.Point(791, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(283, 494);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.TabStop = false;
            this.btnCopy.Text = "编辑";
            // 
            // hSub
            // 
            this.hSub.Location = new System.Drawing.Point(173, 177);
            this.hSub.Name = "hSub";
            this.hSub.Size = new System.Drawing.Size(27, 23);
            this.hSub.TabIndex = 32;
            this.hSub.Text = "-";
            this.hSub.UseVisualStyleBackColor = true;
            this.hSub.Click += new System.EventHandler(this.hSub_Click);
            // 
            // hPlus
            // 
            this.hPlus.Location = new System.Drawing.Point(206, 177);
            this.hPlus.Name = "hPlus";
            this.hPlus.Size = new System.Drawing.Size(27, 23);
            this.hPlus.TabIndex = 31;
            this.hPlus.Text = "+";
            this.hPlus.UseVisualStyleBackColor = true;
            this.hPlus.Click += new System.EventHandler(this.hPlus_Click);
            // 
            // wSub
            // 
            this.wSub.Location = new System.Drawing.Point(173, 150);
            this.wSub.Name = "wSub";
            this.wSub.Size = new System.Drawing.Size(27, 23);
            this.wSub.TabIndex = 30;
            this.wSub.Text = "-";
            this.wSub.UseVisualStyleBackColor = true;
            this.wSub.Click += new System.EventHandler(this.wSub_Click);
            // 
            // wPlus
            // 
            this.wPlus.Location = new System.Drawing.Point(206, 150);
            this.wPlus.Name = "wPlus";
            this.wPlus.Size = new System.Drawing.Size(27, 23);
            this.wPlus.TabIndex = 29;
            this.wPlus.Text = "+";
            this.wPlus.UseVisualStyleBackColor = true;
            this.wPlus.Click += new System.EventHandler(this.wPlus_Click);
            // 
            // ySub
            // 
            this.ySub.Location = new System.Drawing.Point(173, 121);
            this.ySub.Name = "ySub";
            this.ySub.Size = new System.Drawing.Size(27, 23);
            this.ySub.TabIndex = 28;
            this.ySub.Text = "-";
            this.ySub.UseVisualStyleBackColor = true;
            this.ySub.Click += new System.EventHandler(this.ySub_Click);
            // 
            // yPlus
            // 
            this.yPlus.Location = new System.Drawing.Point(206, 121);
            this.yPlus.Name = "yPlus";
            this.yPlus.Size = new System.Drawing.Size(27, 23);
            this.yPlus.TabIndex = 27;
            this.yPlus.Text = "+";
            this.yPlus.UseVisualStyleBackColor = true;
            this.yPlus.Click += new System.EventHandler(this.yPlus_Click);
            // 
            // xSub
            // 
            this.xSub.Location = new System.Drawing.Point(173, 90);
            this.xSub.Name = "xSub";
            this.xSub.Size = new System.Drawing.Size(27, 23);
            this.xSub.TabIndex = 26;
            this.xSub.Text = "-";
            this.xSub.UseVisualStyleBackColor = true;
            this.xSub.Click += new System.EventHandler(this.xSub_Click);
            // 
            // xPlus
            // 
            this.xPlus.Location = new System.Drawing.Point(206, 90);
            this.xPlus.Name = "xPlus";
            this.xPlus.Size = new System.Drawing.Size(27, 23);
            this.xPlus.TabIndex = 25;
            this.xPlus.Text = "+";
            this.xPlus.UseVisualStyleBackColor = true;
            this.xPlus.Click += new System.EventHandler(this.xPlus_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(73, 406);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(177, 21);
            this.txtComment.TabIndex = 24;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            // 
            // chkComment
            // 
            this.chkComment.AutoSize = true;
            this.chkComment.Location = new System.Drawing.Point(19, 410);
            this.chkComment.Name = "chkComment";
            this.chkComment.Size = new System.Drawing.Size(48, 16);
            this.chkComment.TabIndex = 23;
            this.chkComment.Text = "注释";
            this.chkComment.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(239, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 23);
            this.button3.TabIndex = 22;
            this.button3.Text = "复制";
            this.toolTip1.SetToolTip(this.button3, "复制皮肤名到剪切板");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 268);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(258, 117);
            this.txtName.TabIndex = 21;
            this.txtName.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lstNode);
            this.groupBox4.Location = new System.Drawing.Point(246, 386);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(539, 123);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "预览";
            // 
            // lstNode
            // 
            this.lstNode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nodeName,
            this.nodeValue});
            this.lstNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNode.FullRowSelect = true;
            this.lstNode.GridLines = true;
            this.lstNode.HideSelection = false;
            this.lstNode.Location = new System.Drawing.Point(3, 17);
            this.lstNode.MultiSelect = false;
            this.lstNode.Name = "lstNode";
            this.lstNode.Size = new System.Drawing.Size(533, 103);
            this.lstNode.TabIndex = 0;
            this.lstNode.UseCompatibleStateImageBehavior = false;
            this.lstNode.View = System.Windows.Forms.View.Details;
            this.lstNode.SelectedIndexChanged += new System.EventHandler(this.lstNode_SelectedIndexChanged);
            // 
            // nodeName
            // 
            this.nodeName.Text = "Name";
            this.nodeName.Width = 172;
            // 
            // nodeValue
            // 
            this.nodeValue.Text = "Value";
            this.nodeValue.Width = 249;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imgPanel
            // 
            this.imgPanel.BackColor = System.Drawing.Color.White;
            this.imgPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgPanel.GridHeight = 0;
            this.imgPanel.GridWidth = 0;
            this.imgPanel.GridX = 0;
            this.imgPanel.GridY = 0;
            this.imgPanel.ImagePath = "";
            this.imgPanel.Location = new System.Drawing.Point(3, 17);
            this.imgPanel.Name = "imgPanel";
            this.imgPanel.Size = new System.Drawing.Size(533, 348);
            this.imgPanel.TabIndex = 0;
            // 
            // SkinEditorForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 521);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.gp);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SkinEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkinEditor";
            this.Load += new System.EventHandler(this.EditSkinForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.SkinEditorForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.SkinEditorForm_DragEnter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditSkinForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.gp.ResumeLayout(false);
            this.btnCopy.ResumeLayout(false);
            this.btnCopy.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gp;
        private System.Windows.Forms.GroupBox btnCopy;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView lstSkin;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ListView lstNode;
        private System.Windows.Forms.ColumnHeader nodeName;
        private System.Windows.Forms.ColumnHeader nodeValue;
        private System.Windows.Forms.TextBox skinName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNodeName;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.CheckBox chkX;
        private System.Windows.Forms.CheckBox chkY;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.CheckBox chkHeight;
        private System.Windows.Forms.CheckBox chkWidth;
        private System.Windows.Forms.CheckBox chkLink;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.CheckBox chkName;
        private System.Windows.Forms.Button btnSelectName;
        private System.Windows.Forms.RichTextBox txtName;
        private ImagePanel imgPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.CheckBox chkComment;
        private System.Windows.Forms.Button xPlus;
        private System.Windows.Forms.Button xSub;
        private System.Windows.Forms.Button hSub;
        private System.Windows.Forms.Button hPlus;
        private System.Windows.Forms.Button wSub;
        private System.Windows.Forms.Button wPlus;
        private System.Windows.Forms.Button ySub;
        private System.Windows.Forms.Button yPlus;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}