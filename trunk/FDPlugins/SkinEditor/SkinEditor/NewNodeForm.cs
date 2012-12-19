using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SkinEditor
{
    public partial class NewNodeForm : Form
    {
        /// <summary>
        /// 创建节点事件
        /// </summary>
        public event CreatEventHandler Creat;

        public PluginMain pluginMain;//

        public Settings setting;

        public NewNodeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OK 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("节点名不可为空", "提示");
                return;
            }
            int type = -1;
            ComSkin skin = null;
            if (tabControl1.SelectedIndex == 0)
            {
                if (radButton.Checked == true)
                {
                    type = (int)NodeTypeEnum.Button;
                }
                else if (radF9BitMap.Checked == true)
                {
                    type = (int)NodeTypeEnum.F9BitMap;
                }
                else if (radSelectButton.Checked == true)
                {
                    type = (int)NodeTypeEnum.SelectButton;
                }
                else if (radPanel.Checked == true)
                {
                    type = (int)NodeTypeEnum.Panel;
                }

                else if (radlist.Checked == true)
                {
                    type = (int)NodeTypeEnum.List;
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                skin = setting.SkinList[cmbComType.SelectedIndex];
            }


            CreatNodeEventArgs ce = new CreatNodeEventArgs(type, txtName.Text, skin);
            OnCreat(ce);
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 创建事件
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCreat(CreatNodeEventArgs e)
        {
            if (Creat != null)
            {
                Creat(this, e);
            }
        }

        /// <summary>
        /// 窗体显示完毕之后刷新Combox的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewNodeForm_Shown(object sender, EventArgs e)
        {
            if (pluginMain != null)
            {
                setting = (Settings)pluginMain.Settings;
                cmbComType.Items.Clear();

                foreach (ComSkin skin in setting.SkinList)
                {
                    cmbComType.Items.Add(skin.Name);
                }
                //默认选中第一个
                if (cmbComType.Items.Count > 0)
                {
                    cmbComType.SelectedIndex = 0;
                    setSkinLayer(setting.SkinList[0]);
                }
            }
        }


        /// <summary>
        /// 设置皮肤的图层显示
        /// </summary>
        /// <param name="skin"></param>
        private void setSkinLayer(ComSkin skin)
        {
            lbLayer.Text = "";

            foreach (ComLayer layer in skin.SkinLayer)
            {
                lbLayer.Text += (SkinNodeName.getNameByType((int)layer.Layer) + Environment.NewLine);
            }
        }

        private void cmbComType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComSkin skin = setting.SkinList[cmbComType.SelectedIndex];
            setSkinLayer(skin);
        }
    }
}
