using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AojianModule
{
    public partial class AojianModuleWinzard : Form
    {
        public AojianModuleWinzard()
        {
            InitializeComponent();
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
        }

        private void btn_creat_Click(object sender, EventArgs e)
        {
            if(txtModuleName.Text==""||txtFolderName.Text=="")
            {
                MessageBox.Show("命名不能为空！");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtFolderName_TextChanged(object sender, EventArgs e)
        {
            txtModuleName.Text = txtFolderName.Text;
            label3.Text = txtFolderName.Text;
            changeLbName(txtFolderName.Text);
        }

        private void txtModuleName_TextChanged(object sender, EventArgs e)
        {
            changeLbName(txtModuleName.Text);
        }

        private void changeLbName(String head)
        {
            label4.Text = head + "_send_Processor.as";
            label5.Text = head + "_receive_Processor.as";
            label6.Text = head + "_Processor.as";
            label7.Text = head + "_Module.as";
        }

        /// <summary>
        /// 文件夹命名
        /// </summary>
        public string Folder
        {
            get { return txtFolderName.Text; }
        }
           
        /// <summary>
        /// 模块命名
        /// </summary>
        public string ModuleName
        {
            get { return txtModuleName.Text; }
        }

        public string showPath
        {
            get { return lbPath.Text; }
            set { lbPath.Text=value;}
        }


        
    }
}
