using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
namespace SkinEditor
{
    public partial class SkinEditorForm : Form
    {
        private string xmlpath;
        private XmlDocument xmlDoc;           // 
        private XmlNode root;
        private XmlNodeList nodeList;        //nodelist

        private XmlNode curNode;        //当前皮肤节点
        private string curSkinNodeName = string.Empty;     //当前皮肤的子节点的名字 是SkinNodeName
        private XmlComment curComment;  //当前皮肤的注释

        private PluginMain _pluginMain;

        private NewNodeForm creatNodeFrom; //创建节点的窗口

        private string rootPath = "";

        /// <summary>
        /// PluginMain
        /// </summary>
        public PluginMain PluginMain
        {
            get
            {
                return _pluginMain;
            }
            set
            {
                _pluginMain = value;

            }
        }

        public SkinEditorForm()
        {
            InitializeComponent();
        }

        private void EditSkinForm_Load(object sender, EventArgs e)
        {
            xmlpath = ((Settings)PluginMain.Settings).ResPath + "\\ui\\skin\\skin.xml";
            rootPath = ((Settings)PluginMain.Settings).ResPath + "\\ui\\panel";
            if (File.Exists(xmlpath))
                loadXML();

            imgPanel.MouseWheel += new MouseEventHandler(imgPanel_MouseWheel);
        }

        //面板滚轮滚动事件
        void imgPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            //如果是0或1 就return
            if (lstNode.Items.Count <= 1)
                return;

            int index = lstNode.SelectedIndices.Count == 0 ? 0 : lstNode.SelectedIndices[0];

            if (e.Delta > 0)//向上滚动
            {
                index--;
                index = index < 0 ? 0 : index;
                
            }
            else//向下滚动
            {
                index++;
                index = index >= lstNode.Items.Count ? (lstNode.Items.Count - 1) : index;
            }

            lstNode.Items[index].Selected = true;
            
        }

        private void EditSkinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }


        /// <summary>
        /// 加载XML
        /// </summary>
        private void loadXML()
        {
            Settings settings = (Settings)PluginMain.Settings;
            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlpath);

            root = xmlDoc.SelectSingleNode("skin");
            refreshSkinTree();
        }

        /// <summary>
        /// 刷新列表显示
        /// </summary>
        private void refreshSkinTree()
        {
            nodeList = root.ChildNodes;

            lstSkin.Items.Clear();

            foreach (XmlNode node in nodeList)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    if (txtFilter.Text != "")
                    {
                        if (!node.Name.ToLower().Contains(txtFilter.Text.Trim().ToLower()))
                        {
                            continue;
                        }
                    }
                    ListViewItem listItem = new ListViewItem();
                    listItem.Text = node.Name;
                    //分析类型
                    listItem.SubItems.Add(getTypeByNode(node));
                    lstSkin.Items.Add(listItem);

                }
            }
        }

        /// <summary>
        /// 通过NODE 获取类型
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string getTypeByNode(XmlNode node)
        {
            return PluginMain.getSkinTypeByNode(node);
        }



        /// <summary>
        /// 选中某个ITEM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSkin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSkin.SelectedItems.Count == 0)
                return;
            string name = lstSkin.SelectedItems[0].Text;

            lstNode.Items.Clear();
            int index = 0;
            curComment = null;
            curNode = null;

            foreach (XmlNode node in nodeList)
            {
                index = 0;
                if (node.NodeType == XmlNodeType.Element)
                {
                    if (node.Name == name)
                    {
                        curNode = node;
                        XmlNode tempNode = null;
                        foreach (XmlNode node2 in curNode.ChildNodes)
                        {
                            if (node2.NodeType == XmlNodeType.Element)
                            {
                                if (tempNode == null)
                                    tempNode = node2;
                                ListViewItem listItem = new ListViewItem();
                                listItem.Text = node2.Name;//节点名字
                                listItem.SubItems.Add(node2.OuterXml);//节点值
                                lstNode.Items.Add(listItem);
                            }
                            else if (node2.NodeType == XmlNodeType.Comment)
                            {
                                if (index == 0)
                                {
                                    curComment = (XmlComment)node2;
                                }
                            }
                            index++;
                        }
                        lstNode.Items[0].Selected = true;
                        skinName.Text = curNode.Name;
                        if (tempNode != null)
                            setNodeValue(tempNode);

                        if (curComment != null)
                        {
                            chkComment.Checked = true;
                            txtComment.Text = curComment.Value;
                        }
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// 设置面板上NODE的各个属性
        /// </summary>
        /// <param name="node"></param>
        private void setNodeValue(XmlNode node)
        {
            lbNodeName.Text = node.Name;
            clearAllValue();
            foreach (XmlAttribute att in node.Attributes)
            {
                setValueByName(att.Name, att.Value);
            }
        }


        /// <summary>
        /// 通过名字来设置面板上的数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        private void setValueByName(string name, string value)
        {
            unregistTxtHandler();
            switch (name)
            {
                case "x":
                    txtX.Text = value;
                    chkX.Checked = true;
                    imgPanel.GridX = Convert.ToInt32(value);
                    break;
                case "y":
                    txtY.Text = value;
                    chkY.Checked = true;
                    imgPanel.GridY = Convert.ToInt32(value);
                    break;
                case "width":
                    txtWidth.Text = value;
                    chkWidth.Checked = true;
                    imgPanel.GridWidth = Convert.ToInt32(value);
                    break;
                case "height":
                    txtHeight.Text = value;
                    chkHeight.Checked = true;
                    imgPanel.GridHeight = Convert.ToInt32(value);
                    break;
                case "name":
                    txtName.Text = value;
                    chkName.Checked = true;
                    imgPanel.ImagePath = rootPath + "\\" + value;
                    break;
                case "link":
                    txtLink.Text = value;
                    chkLink.Checked = true;
                    break;
                default:
                    break;
            }
            registTxtHandler();
        }

        private void clearAllValue()
        {
            unregistTxtHandler();
            chkX.Checked = false;
            chkY.Checked = false;
            chkHeight.Checked = false;
            chkWidth.Checked = false;
            chkName.Checked = false;
            chkLink.Checked = false;
            chkComment.Checked = false;

            txtX.Text = "0";
            txtY.Text = "0";
            txtWidth.Text = "0";
            txtHeight.Text = "0";
            txtName.Text = "";
            txtLink.Text = "";
            txtComment.Text = "";
            registTxtHandler();
        }



        /// <summary>
        /// 改变皮肤 状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstNode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //默认选中第0个东西
            if (lstNode.SelectedItems.Count == 0)
                return;
            string nodeName = lstNode.SelectedItems[0].Text;
            foreach (XmlNode node in curNode.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    if (nodeName == node.Name)
                    {
                        curSkinNodeName = nodeName;
                        lstNode.SelectedItems[0].SubItems[1].Text = node.OuterXml;
                        setNodeValue(node);
                    }
                }
            }
            reSetImage();
        }


        /// <summary>
        /// 界面编辑的值更改之后  存到curNode里
        /// </summary>
        private void onValueChange()
        {
            if (curNode != null)
            {
                foreach (XmlNode node in curNode.ChildNodes)
                {
                    XmlElement xle = node as XmlElement;
                    if (xle == null)
                        continue;
                    if (xle.NodeType == XmlNodeType.Element)
                    {
                        if (curSkinNodeName == xle.Name)
                        {
                            setElementAttribute(xle, "name", txtName.Text, false);
                            setElementAttribute(xle, "x", txtX.Text, false);
                            setElementAttribute(xle, "y", txtY.Text, false);
                            setElementAttribute(xle, "width", txtWidth.Text, false);
                            setElementAttribute(xle, "height", txtHeight.Text, false);
                            setElementAttribute(xle, "link", txtLink.Text, false);
                            break;
                        }
                    }
                }

                string nodeName = lstNode.SelectedItems[0].Text;
                foreach (XmlNode node in curNode.ChildNodes)
                {
                    if (node.NodeType == XmlNodeType.Element)
                    {
                        if (nodeName == node.Name)
                        {
                            curSkinNodeName = nodeName;
                            lstNode.SelectedItems[0].SubItems[1].Text = node.OuterXml;
                        }
                    }
                }
                reSetImage();
            }
        }

        /// <summary>
        /// 设置的XMLElement的属性
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="name">属性名</param>
        /// <param name="value">属性的值</param>
        /// <param name="append">是否追加，如果否则如果没有这个节点 则不写入</param>
        private void setElementAttribute(XmlElement ele, string name, string value, bool append)
        {
            if (append)//如果追加 则直接写
            {
                ele.SetAttribute(name, value);
            }
            else
            {
                foreach (XmlAttribute attr in ele.Attributes)
                {
                    if (attr.Name == name)
                    {
                        attr.Value = value;
                    }
                }
            }
        }




        /// <summary>
        /// 刷新设置图片预览
        /// </summary>
        private void reSetImage()
        {
            string imagePath = rootPath + "\\" + txtName.Text;

            int gx = Convert.ToInt32(txtX.Text);
            int gy = Convert.ToInt32(txtY.Text);
            int width = Convert.ToInt32(txtWidth.Text);
            int height = Convert.ToInt32(txtHeight.Text);

            imgPanel.ImagePath = imagePath;
            imgPanel.GridX = gx;
            imgPanel.GridY = gy;
            imgPanel.GridWidth = width;
            imgPanel.GridHeight = height;
        }

        //验证字符串
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            int value = 0;
            try
            {
                value = Convert.ToInt32(textbox.Text);

                //刷新图形显示
                reSetImage();
                onValueChange();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "txtValue_TextChanged", "错误");
            }
        }

        //注册文本框事件
        private void registTxtHandler()
        {
            this.txtHeight.TextChanged += new EventHandler(this.txtValue_TextChanged);
            this.txtWidth.TextChanged += new EventHandler(this.txtValue_TextChanged);
            this.txtY.TextChanged += new EventHandler(this.txtValue_TextChanged);
            this.txtX.TextChanged += new EventHandler(this.txtValue_TextChanged);
        }

        //注销文本框事件
        private void unregistTxtHandler()
        {
            this.txtHeight.TextChanged -= new EventHandler(this.txtValue_TextChanged);
            this.txtWidth.TextChanged -= new EventHandler(this.txtValue_TextChanged);
            this.txtY.TextChanged -= new EventHandler(this.txtValue_TextChanged);
            this.txtX.TextChanged -= new EventHandler(this.txtValue_TextChanged);
        }

        private void xSub_Click(object sender, EventArgs e)
        {
            if (!isNumber(txtX.Text))
            {
                txtX.Text = "0";
                return;
            }
            int value = Convert.ToInt32(txtX.Text);
            if (value > 0)
            {
                value--;
                txtX.Text = value.ToString();
            }
        }

        private void ySub_Click(object sender, EventArgs e)
        {
            if (!isNumber(txtY.Text))
            {
                txtY.Text = "0";
                return;
            }

            int value = Convert.ToInt32(txtY.Text);
            if (value > 0)
            {
                value--;
                txtY.Text = value.ToString();
            }
        }

        private void wSub_Click(object sender, EventArgs e)
        {
            if (!isNumber(txtWidth.Text))
            {
                txtWidth.Text = "0";
                return;
            }
            int value = Convert.ToInt32(txtWidth.Text);
            if (value > 0)
            {
                value--;
                txtWidth.Text = value.ToString();
            }

        }

        private void hSub_Click(object sender, EventArgs e)
        {
            if (!isNumber(txtHeight.Text))
            {
                txtHeight.Text = "0";
                return;
            }
            int value = Convert.ToInt32(txtHeight.Text);
            if (value > 0)
            {
                value--;
                txtHeight.Text = value.ToString();
            }
        }

        private void xPlus_Click(object sender, EventArgs e)
        {
            if (!isNumber(txtX.Text))
            {
                txtX.Text = "0";
                return;
            }
            int value = Convert.ToInt32(txtX.Text);
            value++;
            txtX.Text = value.ToString();
        }

        private void yPlus_Click(object sender, EventArgs e)
        {
            if (!isNumber(txtY.Text))
            {
                txtY.Text = "0";
                return;
            }
            int value = Convert.ToInt32(txtY.Text);
            value++;
            txtY.Text = value.ToString();
        }

        private void wPlus_Click(object sender, EventArgs e)
        {
            if (!isNumber(txtWidth.Text))
            {
                txtWidth.Text = "0";
                return;
            }
            int value = Convert.ToInt32(txtWidth.Text);
            value++;
            txtWidth.Text = value.ToString();
        }

        private void hPlus_Click(object sender, EventArgs e)
        {
            if (!isNumber(txtHeight.Text))
            {
                txtHeight.Text = "0";
                return;
            }
            int value = Convert.ToInt32(txtHeight.Text);
            value++;
            txtHeight.Text = value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectName_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                path = path.Replace(rootPath + "\\", "");
                txtName.Text = path;
                //重置Image
                onValueChange();
            }
        }
        /// <summary>
        /// 新建按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (xmlDoc == null)
            {
                MessageBox.Show("请先设置资源路径，并且正确加载XML");
                return;
            }
            creatNodeFrom = new NewNodeForm();
            creatNodeFrom.Creat += new CreatEventHandler(creatNodeFrom_Creat);
            creatNodeFrom.pluginMain = this.PluginMain;
            creatNodeFrom.ShowDialog();
        }

        /// <summary>
        /// 保存按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                xmlDoc.Save(xmlpath);
                MessageBox.Show("保存成功！", "提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败~" + ex.Message, "错误");
            }
        }

        /// <summary>
        /// 创建节点回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void creatNodeFrom_Creat(object sender, CreatNodeEventArgs e)
        {
            string nodeName = e.NodeName;
            int type = e.Type;
            ComSkin skin = e.Skin;
            if (checkNodeExist(nodeName))
            {
                MessageBox.Show("同名节点已存在", "提示");
                return;
            }
            else
            {
                creatNodeFrom.Close();
                if (type != -1)
                {
                    creatNode(type, nodeName);
                }
                else
                {
                    creatNode(skin,nodeName);
                }

                refreshSkinTree();
                selectLstSkinItem(nodeName);
            }
        }


        /// <summary>
        /// 选中皮肤节点
        /// </summary>
        /// <param name="skinName"></param>
        private void selectLstSkinItem(string skinName)
        {
            foreach (ListViewItem item in lstSkin.Items)
            {
                if (item.Text == skinName)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                    break;
                }
            }
        }

        /// <summary>
        /// 检查节点名称是否存在
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        private bool checkNodeExist(string nodeName)
        {
            if (nodeList != null)
            {
                foreach (XmlNode node in nodeList)
                {
                    if (node.Name == nodeName)
                        return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// 创建节点            //TODO 改成动态配置的  擦
        /// </summary>
        /// <param name="type">节点类型</param>
        /// <param name="nodeName">节点名称</param>
        private void creatNode(int type, string nodeName)
        {
            XmlNode newNode = xmlDoc.CreateNode("element", nodeName, null);

            switch ((NodeTypeEnum)type)
            {
                case NodeTypeEnum.Button:
                    creatSubNode(newNode, SkinNodeName.upImage, "", 0, 0, 0, 0);
                    creatSubNode(newNode, SkinNodeName.overImage, "", 0, 0, 0, 0);
                    creatSubNode(newNode, SkinNodeName.downImage, "", 0, 0, 0, 0);
                    root.AppendChild(newNode);
                    break;
                case NodeTypeEnum.SelectButton:
                    creatSubNode(newNode, SkinNodeName.upImage, "", 0, 0, 0, 0);
                    creatSubNode(newNode, SkinNodeName.overImage, "", 0, 0, 0, 0);
                    creatSubNode(newNode, SkinNodeName.downImage, "", 0, 0, 0, 0);
                    creatSubNode(newNode, SkinNodeName.selectImage, "", 0, 0, 0, 0);
                    root.AppendChild(newNode);
                    break;
                case NodeTypeEnum.F9BitMap:
                    creatSubNode(newNode, SkinNodeName.backgroundImage, "", 0, 0, 0, 0);
                    root.AppendChild(newNode);
                    break;
                case NodeTypeEnum.Panel:
                    creatSubNodeLink(newNode, SkinNodeName.title, "");
                    creatSubNodeLink(newNode, SkinNodeName.canvas, "");
                    creatSubNodeLink(newNode, SkinNodeName.closeButton, "");
                    root.AppendChild(newNode);
                    break;
                case NodeTypeEnum.List:

                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// 创建节点
        /// </summary>
        /// <param name="skin"></param>
        /// <param name="nodeName"></param>
        private void creatNode(ComSkin skin,string nodeName)
        {
            XmlNode newNode = xmlDoc.CreateNode("element", nodeName, null);
            foreach (ComLayer layer in skin.SkinLayer)
            {
                if (layer.LayerType == LayerType.name)
                {
                    creatSubNode(newNode, SkinNodeName.getNameByType((int)layer.Layer), "", 0, 0, 0, 0);
                }
                else
                {
                    creatSubNodeLink(newNode, SkinNodeName.getNameByType((int)layer.Layer), "");
                }
            }
            root.AppendChild(newNode);
        }

        /// <summary>
        /// 添加皮肤节点的子节点    name样式的
        /// </summary>
        /// <param name="nodeName">节点的命名</param>
        /// <param name="node">节点</param>
        /// <param name="name">name属性的值</param>
        /// <param name="x">x属性的值</param>
        /// <param name="y">y属性的值</param>
        /// <param name="width">width属性的值</param>
        /// <param name="height">height属性的值</param>
        private void creatSubNode(XmlNode node, string nodeName, string name, int x, int y, int width, int height)
        {
            XmlElement xmlEle = xmlDoc.CreateElement(nodeName);
            xmlEle.SetAttribute("name", name);
            xmlEle.SetAttribute("x", x.ToString());
            xmlEle.SetAttribute("y", y.ToString());
            xmlEle.SetAttribute("width", width.ToString());
            xmlEle.SetAttribute("height", height.ToString());
            node.AppendChild(xmlEle);
        }

        /// <summary>
        /// 添加皮肤节点的子节点 link样式的
        /// </summary>
        /// <param name="node">node</param>
        /// <param name="nodeName">节点命名</param>
        /// <param name="link">link属性的值</param>
        private void creatSubNodeLink(XmlNode node, string nodeName, string link)
        {
            XmlElement xmlEle = xmlDoc.CreateElement(nodeName);
            xmlEle.SetAttribute("link", link);
            node.AppendChild(xmlEle);
        }

        /// <summary>
        /// 图片拖动操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkinEditorForm_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string savePath = string.Empty;

            FileInfo fi = new FileInfo(path);

            if (fi.Extension.ToLower() == ".png" || fi.Extension.ToLower() == ".jpg")
            {
                Image img = Image.FromFile(fi.FullName);
                string tempStr = "-" + img.Width.ToString() + "_" + img.Height.ToString() + fi.Extension;
                string newName = string.Empty;
                if (fi.Name.IndexOf(tempStr) == -1)//如果名字没改
                {
                    newName = fi.Name.Substring(0, fi.Name.IndexOf('.')) + "-" + img.Width.ToString() + "_" + img.Height.ToString() + fi.Extension;
                }
                else
                {
                    newName = fi.Name;//如果名字已经改了
                }

                if (!fi.FullName.StartsWith(rootPath))
                {
                    saveFileDialog1.FileName = newName;
                    saveFileDialog1.Title = "选择皮肤文件保存位置";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(path, saveFileDialog1.FileName, true);
                        savePath = saveFileDialog1.FileName;
                    }
                    else
                        return;
                }
                else
                {
                    savePath = fi.Directory + "\\" + newName;
                }

                txtName.Text = savePath.Replace(rootPath + "\\", "");
                onValueChange();
            }


        }

        private void SkinEditorForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            xmlpath = ((Settings)PluginMain.Settings).ResPath + "\\ui\\skin\\skin.xml";
            rootPath = ((Settings)PluginMain.Settings).ResPath + "\\ui\\panel";
            loadXML();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (skinName.Text != null && skinName.Text != "")
                Clipboard.SetText(skinName.Text);
        }

        /// <summary>
        /// 删除NODE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstSkin.SelectedItems.Count == 0)
                return;
            string nodeName = lstSkin.SelectedItems[0].Text;
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    if (nodeName == node.Name)
                    {
                        root.RemoveChild(node);
                        refreshSkinTree();
                    }
                }
            }
        }

        /// <summary>
        /// 过滤字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            refreshSkinTree();
        }

        /// <summary>
        /// 注释变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            if (chkComment.Checked == false)
                return;
            if (curComment != null)
            {
                curComment.Value = txtComment.Text;
            }
            else
            {
                curComment = xmlDoc.CreateComment(txtComment.Text);
                curNode.InsertBefore(curComment, curNode.FirstChild);
            }
        }

        /// <summary>
        /// 验证是否为数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool isNumber(string str)
        {
            bool result = Regex.IsMatch(str, @"^[0-9]\d*$");
            return result;
        }


        private void txtLink_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                onValueChange();
            }
        }

        private void txtLink_Leave(object sender, EventArgs e)
        {
            onValueChange();
        }
    }
}
