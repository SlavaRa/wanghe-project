namespace SkinEditor
{
    partial class NewNodeForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radlist = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radSelectButton = new System.Windows.Forms.RadioButton();
            this.radPanel = new System.Windows.Forms.RadioButton();
            this.radF9BitMap = new System.Windows.Forms.RadioButton();
            this.radButton = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.fastPage = new System.Windows.Forms.TabPage();
            this.advancePage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbComType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbLayer = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.fastPage.SuspendLayout();
            this.advancePage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 362);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(344, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(162, 322);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(151, 281);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(322, 21);
            this.txtName.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "皮肤名称：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(415, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 36);
            this.label5.TabIndex = 9;
            this.label5.Text = "title\r\ncanvas\r\ncloseButton";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 36);
            this.label4.TabIndex = 8;
            this.label4.Text = "tileImage\r\noverImage\r\nselectImage";
            // 
            // radlist
            // 
            this.radlist.AutoSize = true;
            this.radlist.Location = new System.Drawing.Point(38, 103);
            this.radlist.Name = "radlist";
            this.radlist.Size = new System.Drawing.Size(47, 16);
            this.radlist.TabIndex = 7;
            this.radlist.Tag = "4";
            this.radlist.Text = "list";
            this.radlist.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 48);
            this.label3.TabIndex = 6;
            this.label3.Text = "upImage\r\noverImage\r\ndownImage\r\nselectImage\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "backgroundImage";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "upImage\r\noverImage\r\ndownImage";
            // 
            // radSelectButton
            // 
            this.radSelectButton.AutoSize = true;
            this.radSelectButton.Location = new System.Drawing.Point(140, 28);
            this.radSelectButton.Name = "radSelectButton";
            this.radSelectButton.Size = new System.Drawing.Size(95, 16);
            this.radSelectButton.TabIndex = 3;
            this.radSelectButton.Tag = "1";
            this.radSelectButton.Text = "selectButton";
            this.radSelectButton.UseVisualStyleBackColor = true;
            // 
            // radPanel
            // 
            this.radPanel.AutoSize = true;
            this.radPanel.Location = new System.Drawing.Point(398, 28);
            this.radPanel.Name = "radPanel";
            this.radPanel.Size = new System.Drawing.Size(53, 16);
            this.radPanel.TabIndex = 2;
            this.radPanel.Tag = "3";
            this.radPanel.Text = "Panel";
            this.radPanel.UseVisualStyleBackColor = true;
            // 
            // radF9BitMap
            // 
            this.radF9BitMap.AutoSize = true;
            this.radF9BitMap.Location = new System.Drawing.Point(270, 29);
            this.radF9BitMap.Name = "radF9BitMap";
            this.radF9BitMap.Size = new System.Drawing.Size(71, 16);
            this.radF9BitMap.TabIndex = 1;
            this.radF9BitMap.Tag = "2";
            this.radF9BitMap.Text = "F9Bitmap";
            this.radF9BitMap.UseVisualStyleBackColor = true;
            // 
            // radButton
            // 
            this.radButton.AutoSize = true;
            this.radButton.Checked = true;
            this.radButton.Location = new System.Drawing.Point(36, 29);
            this.radButton.Name = "radButton";
            this.radButton.Size = new System.Drawing.Size(59, 16);
            this.radButton.TabIndex = 0;
            this.radButton.TabStop = true;
            this.radButton.Tag = "0";
            this.radButton.Text = "Button";
            this.radButton.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.fastPage);
            this.tabControl1.Controls.Add(this.advancePage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(569, 241);
            this.tabControl1.TabIndex = 14;
            // 
            // fastPage
            // 
            this.fastPage.Controls.Add(this.groupBox2);
            this.fastPage.Location = new System.Drawing.Point(4, 22);
            this.fastPage.Name = "fastPage";
            this.fastPage.Padding = new System.Windows.Forms.Padding(3);
            this.fastPage.Size = new System.Drawing.Size(561, 215);
            this.fastPage.TabIndex = 0;
            this.fastPage.Text = "快速⁮创建";
            this.fastPage.UseVisualStyleBackColor = true;
            // 
            // advancePage
            // 
            this.advancePage.Controls.Add(this.lbLayer);
            this.advancePage.Controls.Add(this.label8);
            this.advancePage.Controls.Add(this.cmbComType);
            this.advancePage.Controls.Add(this.label7);
            this.advancePage.Location = new System.Drawing.Point(4, 22);
            this.advancePage.Name = "advancePage";
            this.advancePage.Padding = new System.Windows.Forms.Padding(3);
            this.advancePage.Size = new System.Drawing.Size(561, 215);
            this.advancePage.TabIndex = 1;
            this.advancePage.Text = "高级创建";
            this.advancePage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radButton);
            this.groupBox2.Controls.Add(this.radF9BitMap);
            this.groupBox2.Controls.Add(this.radPanel);
            this.groupBox2.Controls.Add(this.radSelectButton);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.radlist);
            this.groupBox2.Location = new System.Drawing.Point(18, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 187);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选项";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "选择组件类型：";
            // 
            // cmbComType
            // 
            this.cmbComType.FormattingEnabled = true;
            this.cmbComType.Location = new System.Drawing.Point(126, 21);
            this.cmbComType.Name = "cmbComType";
            this.cmbComType.Size = new System.Drawing.Size(198, 20);
            this.cmbComType.TabIndex = 1;
            this.cmbComType.SelectedIndexChanged += new System.EventHandler(this.cmbComType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(353, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "组件类型在插件设置里自定义";
            // 
            // lbLayer
            // 
            this.lbLayer.AutoSize = true;
            this.lbLayer.Location = new System.Drawing.Point(33, 52);
            this.lbLayer.Name = "lbLayer";
            this.lbLayer.Size = new System.Drawing.Size(0, 12);
            this.lbLayer.TabIndex = 3;
            // 
            // NewNodeForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 362);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewNodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建皮肤";
            this.Shown += new System.EventHandler(this.NewNodeForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.fastPage.ResumeLayout(false);
            this.advancePage.ResumeLayout(false);
            this.advancePage.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radSelectButton;
        private System.Windows.Forms.RadioButton radPanel;
        private System.Windows.Forms.RadioButton radF9BitMap;
        private System.Windows.Forms.RadioButton radButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radlist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage fastPage;
        private System.Windows.Forms.TabPage advancePage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbComType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbLayer;
    }
}