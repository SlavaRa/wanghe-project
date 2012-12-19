using System;
using System.Collections.Generic;
using System.Text;
using PluginCore;
using System.ComponentModel;
using PluginCore.Managers;
using PluginCore.Helpers;
using System.IO;
using PluginCore.Utilities;
using System.Windows.Forms;
using PluginCore.Localization;
using ASCompletion.Context;

namespace PreviousEdit
{

    public class PluginMain : IPlugin
    {

        private String pluginName = "PreviousEdit";
        private String pluginGuid = "55E1998E-9929-4470-805E-2DB339C29116";
        private String pluginHelp = "www.flashdevelop.org/community/";
        private String pluginDesc = "Previous Edit Place.";
        private String pluginAuth = "He Wang";
        private String settingFilename;
        private Settings settingObject;

        private Stack<MyPoint> _list = new Stack<MyPoint>();//锚点栈
        private List<ToolStripItem> menuItems;

        private MyPoint lastPoint=new MyPoint("",0,0);

        #region IPlugin 成员

        public void Dispose()
        {
            this.SaveSettings();
        }

        public void Initialize()
        {
            this.InitBasics();
            this.LoadSettings();
            this.CreatMenuItem();
            this.AddEventHandlers();
        }

        public int Api
        {
            get { return 1; }
        }

        public string Name
        {
            get { return this.pluginName; }
        }

        public string Guid
        {
            get { return this.pluginGuid; }
        }

        public string Help
        {
            get { return  this.pluginHelp; }
        }

        public string Author
        {
            get { return this.pluginAuth; }
        }

        public string Description
        {
            get { return this.pluginDesc; }
        }

        [Browsable(false)]
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
                case EventType.FileSwitch:
                    if (PluginBase.MainForm.CurrentDocument.IsEditable)
                    {
                        //PluginBase.MainForm.CurrentDocument.SciControl.DoubleClick += new ScintillaNet.DoubleClickHandler(SciControl_DoubleClick);
                        PluginBase.MainForm.CurrentDocument.SciControl.Modified -= new ScintillaNet.ModifiedHandler(SciControl_Modified);
                        PluginBase.MainForm.CurrentDocument.SciControl.Modified += new ScintillaNet.ModifiedHandler(SciControl_Modified);
                    }
                    break;
                default:
                    break;
            };
        }

        public void AddEventHandlers()
        {
            EventManager.AddEventHandler(this, EventType.FileSwitch);
        }

        #endregion


        /// <summary>
        /// Initializes important variables
        /// </summary>
        public void InitBasics()
        {
            String dataPath = Path.Combine(PathHelper.DataDir, "PreviousEdit");
            if (!Directory.Exists(dataPath)) Directory.CreateDirectory(dataPath);
            this.settingFilename = Path.Combine(dataPath, "Settings.fdb");
        }

        /// <summary>
        /// Loads the plugin settings
        /// </summary>
        public void LoadSettings()
        {
            this.settingObject = new Settings();
            if (!File.Exists(this.settingFilename)) this.SaveSettings();
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

        /// <summary>
        /// Modified Handler
        /// </summary>
        public void SciControl_Modified(ScintillaNet.ScintillaControl sender, int position, int modificationType, string text, int length, int linesAdded, int line, int intfoldLevelNow, int foldLevelPrev)
        {
           int l = sender.LineFromPosition(position);
            if(lastPoint.fileName==sender.FileName&&lastPoint.line==l)
            {
                lastPoint.line = sender.LineFromPosition(position);
                lastPoint.position = position - sender.PositionFromLine(lastPoint.line);
                return;
            }

            MyPoint p = new MyPoint(sender.FileName, position - sender.PositionFromLine(l), l);
            _list.Push(p);
            lastPoint = p;

            Console.WriteLine(sender.FileName + " " + lastPoint.line.ToString() + " " + lastPoint.position.ToString()+" "+_list.Count.ToString());
            
            //AS3Context.PluginMain.Settings.InstalledSDKs
            //InstalledSDKs
        }

        public void CreatMenuItem()
        {
            IMainForm mainForm = PluginBase.MainForm;
            menuItems=new List<ToolStripItem>();
            ToolStripMenuItem item;
            System.Drawing.Image image;
            ToolStripMenuItem menu = (ToolStripMenuItem)mainForm.FindMenuItem("SearchMenu");
            if (menu != null)
            {
                menu.DropDownItems.Add(new ToolStripSeparator());
                image = image = mainForm.FindImage("99|9|3|-3");
                item = new ToolStripMenuItem("PreviousEdit", image, new EventHandler(GotoPreviousEdit), Keys.Control|Keys.E);
                PluginBase.MainForm.RegisterShortcutItem("PreviousEdit", item);
                menu.DropDownItems.Add(item);
            }
        }

        public void GotoPreviousEdit(Object sender,EventArgs e)
        {
            if (_list.Count == 0)
                return;

            MyPoint p = _list.Pop();
            if (p == null||p.fileName=="") return;



            PluginBase.MainForm.OpenEditableDocument(p.fileName , false);

            ScintillaNet.ScintillaControl sci = ASContext.CurSciControl;
            if (sci != null)
            {
                int position = sci.PositionFromLine(p.line) + p.position;
                sci.SetSel(position, position);
                int line = sci.LineFromPosition(sci.CurrentPos);
                sci.EnsureVisible(line);
                int top = sci.FirstVisibleLine;
                int middle = top + sci.LinesOnScreen / 2;
                sci.LineScroll(0, line - middle);
            }

            lastPoint.fileName = "";
            lastPoint.line = 0;
            lastPoint.position = 0;

        }
    }

    public class MyPoint
    {
        public string fileName;
        public int position;
        public int line;
        public MyPoint(string f,int p,int l)
        {
            fileName = f;
            position = p;
            line = l;
        }
    }
}
