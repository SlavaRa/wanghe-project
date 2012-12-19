using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using PluginCore.Localization;

namespace SkinEditor
{
    [Serializable]
    public class Settings
    {

        private String _resPath;            //游戏资源目录
        private String _originalResPath;    //美术提供的原始资源目录
        private String _xmlEditor;
        private List<ComSkin> skinlist = new List<ComSkin>();



        [DisplayName("傲剑2资源目录")]
        [Category("目录")]
        [Description("傲剑的资源目录,指向version.version的那层")]
        [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public String ResPath
        {
            get { return this._resPath; }
            set { this._resPath = value; }
        }


        [DisplayName("美术原始资源目录")]
        [Category("目录")]
        [Description("美术提供的原始资源目录")]
        [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public String OriginalResPath
        {
            get { return this._originalResPath; }
            set { this._originalResPath = value; }
        }

        [DisplayName("XML编辑器")]
        [Category("目录")]
        [Description("XML的文本编辑器")]
        [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
        public String XMLEditorPath
        {
            get { return this._xmlEditor; }
            set { this._xmlEditor = value; }
        }


        [DisplayName("组件类型列表")]
        [Category("Skin组件")]
        [Description("组件类型列表,可以自定义皮肤")]
        public List<ComSkin> SkinList
        {
            get { return skinlist; }
            set { skinlist = value; }
        }

    }
}
