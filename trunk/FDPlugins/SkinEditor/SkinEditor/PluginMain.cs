using System;
using System.Collections.Generic;
using System.IO;
using PluginCore;
using PluginCore.Helpers;
using PluginCore.Utilities;
using System.Windows.Forms;
using System.Xml;
namespace SkinEditor
{
    public class PluginMain : IPlugin
    {
        private String pluginName = "SkinEditor";
        private String pluginGuid = "0019F398-B3CF-4f61-A3B0-3153FDC401B5";
        private String pluginHelp = "www.flashdevelop.org/community/";
        private String pluginDesc = "Aojian2 Skin Editor Wanghe";
        private String pluginAuth = "He Wang";
        private String settingFilename;
        private Settings settingObject;
        private ToolStripMenuItem skinMenuItem;

        private SkinEditorForm editForm;

        #region IPlugin 成员

        public void Dispose()
        {
            this.SaveSettings();
        }

        public void Initialize()
        {
            this.InitBasics();
            this.LoadSettings();
            this.CreateMainMenuItems();

        }

        public int Api
        {
            get { return 1; }
        }

        public string Name
        {
            get { return pluginName; }
        }

        public string Guid
        {
            get { return pluginGuid; }
        }

        public string Help
        {
            get { return pluginHelp; }
        }

        public string Author
        {
            get { return pluginAuth; }
        }

        public string Description
        {
            get { return pluginDesc; }
        }

        public object Settings
        {
            get { return settingObject; }
        }

        #endregion

        #region IEventHandler 成员

        public void HandleEvent(object sender, NotifyEvent e, HandlingPriority priority)
        {
            switch (e.Type)
            {
                default:
                    break;
            };
        }

        #endregion

        /// <summary>
        /// Initializes important variables
        /// </summary>
        public void InitBasics()
        {
            String dataPath = Path.Combine(PathHelper.DataDir, "SkinEditor");
            if (!Directory.Exists(dataPath)) Directory.CreateDirectory(dataPath);
            this.settingFilename = Path.Combine(dataPath, "Settings.fdb");
        }

        /// <summary>
        /// Loads the plugin settings
        /// </summary>
        public void LoadSettings()
        {
            this.settingObject = new Settings();
            if (!File.Exists(this.settingFilename)) 
                this.SaveSettings();
            else
            {
                Object obj = ObjectSerializer.Deserialize(this.settingFilename, this.settingObject);
                this.settingObject = (Settings)obj;
            }
        }

        /// <summary>
        /// Saves the plugin settings
        /// </summary>
        public void SaveSettings()
        {
            ObjectSerializer.Serialize(this.settingFilename, this.settingObject);
        }

        private void CreateMainMenuItems()
        {
            IMainForm mainForm = PluginBase.MainForm;
            MenuStrip mainMenu = PluginBase.MainForm.MenuStrip;
            this.skinMenuItem = new ToolStripMenuItem("SkinEditor");

            //SKIN编辑面板
            ToolStripMenuItem editSkinItem = new ToolStripMenuItem();
            editSkinItem.Click += new EventHandler(this.EditSkinItemClick);
            editSkinItem.Text = "EditSkin";
            editSkinItem.ToolTipText = "EditSkin";
            this.skinMenuItem.DropDownItems.Add(editSkinItem);

            //打开Skin.xml
            ToolStripMenuItem openSkinItem = new ToolStripMenuItem();
            openSkinItem.Click += new EventHandler(this.OpenSkinItemClick);
            openSkinItem.Text = "Open Skin.xml";
            openSkinItem.ToolTipText = "Open Skin.xml";
            this.skinMenuItem.DropDownItems.Add(openSkinItem);

            //打开原始资源目录
            ToolStripMenuItem openOriginalResItem = new ToolStripMenuItem();
            openOriginalResItem.Click += new EventHandler(this.openOriginalResItem);
            openOriginalResItem.Text = "Open Original UI folder";
            openOriginalResItem.ToolTipText = "Open Original UI folder";
            this.skinMenuItem.DropDownItems.Add(openOriginalResItem);

            //打开PanelUI资源目录
            ToolStripMenuItem openPanelUIItem = new ToolStripMenuItem();
            openPanelUIItem.Click += new EventHandler(this.openPanelUIResItem);
            openPanelUIItem.Text = "Open Panel UI";
            openPanelUIItem.ToolTipText = "Open Panel UI";
            this.skinMenuItem.DropDownItems.Add(openPanelUIItem);


            //打开Panel Skin资源目录
            ToolStripMenuItem openPanelSkinItem = new ToolStripMenuItem();
            openPanelSkinItem.Click += new EventHandler(this.openPanelSkinResItem);
            openPanelSkinItem.Text = "Open Panel Skin";
            openPanelSkinItem.ToolTipText = "Open Panel Skin";
            this.skinMenuItem.DropDownItems.Add(openPanelSkinItem);


            mainMenu.Items.Insert(mainMenu.Items.Count - 2, this.skinMenuItem);

            editForm = new SkinEditorForm();
            editForm.PluginMain = this;


            ToolStrip toolStrip = mainForm.ToolStrip;

            if (toolStrip != null)
            {
                toolStrip.Items.Add(new ToolStripSeparator());
                //打开EditSkin 主界面
                ToolStripButton editSkinBtn = new ToolStripButton(PluginBase.MainForm.FindImage("129"));
                editSkinBtn.Name = "EditSkin";
                editSkinBtn.ToolTipText = "EditSkin";
                editSkinBtn.Click += new EventHandler(this.EditSkinItemClick);
                toolStrip.Items.Add(editSkinBtn);

                //打开Skin.xml
                ToolStripButton openSkinBtn = new ToolStripButton(PluginBase.MainForm.FindImage("277"));
                openSkinBtn.Name = "OpenSkinXML";
                openSkinBtn.ToolTipText = "Open Skin.xml";
                openSkinBtn.Click += new EventHandler(this.OpenSkinItemClick);
                toolStrip.Items.Add(openSkinBtn);

                //打开原始资源目录
                ToolStripButton openOriginalResBtn = new ToolStripButton(PluginBase.MainForm.FindImage("214"));
                openOriginalResBtn.Name = "Open OriginalRes";
                openOriginalResBtn.ToolTipText = "Open 原始资源目录";
                openOriginalResBtn.Click += new EventHandler(this.openOriginalResItem);
                toolStrip.Items.Add(openOriginalResBtn);

                //打开PanelUI资源目录
                ToolStripButton openPanelUIResBtn = new ToolStripButton(PluginBase.MainForm.FindImage("211"));
                openPanelUIResBtn.Name = "Open Panel UI";
                openPanelUIResBtn.ToolTipText = "Open PanelUI资源目录";
                openPanelUIResBtn.Click += new EventHandler(this.openPanelUIResItem);
                toolStrip.Items.Add(openPanelUIResBtn);

                //打开PanelSkin资源目录
                ToolStripButton openPanelSkinResBtn = new ToolStripButton(PluginBase.MainForm.FindImage("215"));
                openPanelSkinResBtn.Name = "Open Panel UI";
                openPanelSkinResBtn.ToolTipText = "Open PanelSkin资源目录";
                openPanelSkinResBtn.Click += new EventHandler(this.openPanelSkinResItem);
                toolStrip.Items.Add(openPanelSkinResBtn);


            }
        }

        /// <summary>
        /// 打开皮肤编辑界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditSkinItemClick(Object sender, EventArgs e)
        {
            editForm.Show();
            editForm.Activate();
        }

        /// <summary>
        /// 打开SkinXML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSkinItemClick(Object sender, EventArgs e)
        {
            if (settingObject.XMLEditorPath != null && settingObject.XMLEditorPath != "")
                System.Diagnostics.Process.Start(settingObject.XMLEditorPath, settingObject.ResPath + "\\ui\\skin\\skin.xml");
        }

        /// <summary>
        /// 打开原始资源目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openOriginalResItem(Object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", settingObject.OriginalResPath);
        }

        /// <summary>
        /// 打开panel/ui目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openPanelUIResItem(Object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", settingObject.ResPath + "\\ui\\panel\\ui");
        }

        /// <summary>
        /// 打开panel/skin目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openPanelSkinResItem(Object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", settingObject.ResPath + "\\ui\\panel\\skin");
        }

        /// <summary>
        /// 根据node获取它的类型
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public string getSkinTypeByNode(XmlNode node)
        {
            if (node.ChildNodes.Count == 0)
            {
                return "空";
            }

            List<string> layerNames = new List<string>();

            foreach (XmlNode xmlnode in node.ChildNodes)
            {
                if (xmlnode.NodeType == XmlNodeType.Element)
                {
                    layerNames.Add(xmlnode.Name);
                }
            }

            //遍历所有的皮肤
            foreach (ComSkin skin in settingObject.SkinList)
            {
                if (skin.SkinLayer.Count != layerNames.Count)
                {
                    continue;
                }

                //遍历皮肤的图层列表
                bool isInlayers = false;
                bool isInSkin = true;
                foreach (string layerName in layerNames)//当前的皮肤图层名
                {
                    foreach (ComLayer comlay in skin.SkinLayer)
                    {
                        if (SkinNodeName.getNameByType((int)comlay.Layer) == layerName)
                            isInlayers = true;
                    }
                    if (isInlayers)
                    {   //如果有则继续
                        isInlayers=false;
                        continue;
                    }
                    else
                    {//没有就跳出
                        isInSkin = false;
                        break;
                    }
                }

                if (isInSkin)
                {
                    return skin.Name;
                }
            }

            return "未知";
        }
    }
}
