using System;
using System.Collections.Generic;
using System.Text;
using PluginCore;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using PluginCore.Managers;
using System.Windows.Forms;
namespace NumToColor
{
    public class PluginMain:IPlugin
    {
        private String pluginName = "NumToColor";
        private String pluginGuid = "BB3EAA88-2925-4e30-9A0E-72902DF5FAC0";
        private String pluginHelp = "www.flashdevelop.org/community/";
        private String pluginDesc = "NumToColor";
        private String pluginAuth = "He Wang";

        private ColorCube cb;
        private int startPosition;
		private bool isActive = false;
        #region IPlugin 成员

        public void Dispose()
        {
            return;
        }

        public void Initialize()
        {
            initUI();
            AddEventHandlers();
        }

        private void initUI()
        {
            cb = new ColorCube();
            PluginBase.MainForm.Controls.Add(cb);
            cb.Visible = false;
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

        [Browsable(false)]
        public object Settings
        {
            get { return null; }
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
                        PluginBase.MainForm.CurrentDocument.SciControl.DoubleClick -= new ScintillaNet.DoubleClickHandler(SciControl_DoubleClick);
                        PluginBase.MainForm.CurrentDocument.SciControl.Modified -= new ScintillaNet.ModifiedHandler(SciControl_Modified);
                        PluginBase.MainForm.CurrentDocument.SciControl.UpdateUI -= new ScintillaNet.UpdateUIHandler(SciControl_UpdateUI);
                        PluginBase.MainForm.CurrentDocument.SciControl.DoubleClick += new ScintillaNet.DoubleClickHandler(SciControl_DoubleClick);
                        PluginBase.MainForm.CurrentDocument.SciControl.Modified += new ScintillaNet.ModifiedHandler(SciControl_Modified);
                        PluginBase.MainForm.CurrentDocument.SciControl.UpdateUI += new ScintillaNet.UpdateUIHandler(SciControl_UpdateUI);
                    }
                    break;
                case EventType.FileModify:
                    cb.Visible = false;
					isActive = false;
                    break;
                default:
                    break;
            };
        }
		
		void SciControl_UpdateUI(ScintillaNet.ScintillaControl sci)
        {
            if(sci!=null&&sci.IsFocus)
            {
                if (isActive && checkPosition(sci.CurrentPos))
                    return;
                else
                {
                    cb.Visible = false;
                    isActive = false;
                }
            }
        }
		
		private bool checkPosition(Int32 position)
        {
            if (startPosition == position) return true;
            else return false;
        }

        /// <summary>
        /// DoubleClick handler
        /// </summary>
        public void SciControl_DoubleClick(ScintillaNet.ScintillaControl sender)
        {
            string color = getColorByString(sender.SelText.Trim());
            if (color != "")
            {
                startPosition = sender.SelectionEnd;
                cb.Visible = true;
                cb.ShowColor(color);
				isActive = true;
                Point coord = new Point(sender.PointXFromPosition(startPosition), sender.PointYFromPosition(startPosition));
                coord = sender.PointToScreen(coord);
                coord = ((Form)PluginBase.MainForm).PointToClient(coord);
                cb.Left = coord.X - 20 + sender.Left;
                cb.Top = coord.Y + cb.Height;
                cb.BringToFront();
            }
            else
            {
                cb.Visible = false;
				isActive = false;
            }
        }

        /// <summary>
        /// Modified Handler
        /// </summary>
        public void SciControl_Modified(ScintillaNet.ScintillaControl sender, int position, int modificationType, string text, int length, int linesAdded, int line, int intfoldLevelNow, int foldLevelPrev)
        {
            cb.Visible = false;
			isActive = false;
        }


        private void AddEventHandlers()
        {
            EventManager.AddEventHandler(this, EventType.FileSwitch);
        }

        public string getColorByString(string text)
        {
            // 0xFFF000
            // #FFFF00
            // FFF000
            // "^#[0-9a-fA-F]{6}{1}$" 
            string color="";
            string reg = "^(#|0x|0X)?[0-9a-fA-F]{6}$";
            if (Regex.IsMatch(text, reg))
            {
                color = text.Substring(text.Length - 6, 6);
                color = "#" + color;
            }
            return color;
        }

        #endregion
    }
}
