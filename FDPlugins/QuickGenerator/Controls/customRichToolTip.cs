using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using QuickGenerator.CustomCompletionList;

namespace UI
{
	/// <summary>
	/// RichTextBox-based tooltip
	/// </summary>
	public class customRichToolTip :IDisposable 
	{
		// controls
		protected Panel toolTip;
        protected RichTextBox toolTipRTB;
        protected string rawText;
        private CustomCompletionBase cust;

		#region Public Properties
		
		public bool Visible 
		{
			get { return toolTip.Visible; }
		}

        public Size Size
        {
            get { return toolTip.Size; }
            set { toolTip.Size = value; }
        }

		public Point Location
		{
			get { return toolTip.Location;  }
			set { toolTip.Location = value; }
		}

		public string Text 
		{
			get { return toolTipRTB.Text; }
			set 
			{
				rawText = value ?? "";
				SetRichText();
				AutoSize();
			}
		}
				
		#endregion
		
		#region Control creation
		
		public customRichToolTip(CustomCompletionBase customBase)
		{
            this.cust = customBase;
			// panel
			toolTip = new System.Windows.Forms.Panel();
			toolTip.Location = new System.Drawing.Point(0,0);
			toolTip.BackColor = Color.LightGoldenrodYellow;
			toolTip.BorderStyle = BorderStyle.FixedSingle;
			toolTip.Visible = false;

            cust.formDisplay.Controls.Add(toolTip);
			// text
			toolTipRTB = new System.Windows.Forms.RichTextBox();
			toolTipRTB.Location = new System.Drawing.Point(2,1);
			toolTipRTB.BackColor = Color.LightGoldenrodYellow;
			toolTipRTB.BorderStyle = BorderStyle.None;
			toolTipRTB.ScrollBars = RichTextBoxScrollBars.None;
			toolTipRTB.ReadOnly = true;
			toolTipRTB.WordWrap = false;
			toolTipRTB.Visible = true;
			toolTipRTB.Text = "";
			toolTip.Controls.Add(toolTipRTB);


		}
		
		#endregion
		
		#region Tip Methods

        public bool AutoSize()
        {
            return AutoSize(0);
        }
		
		public bool AutoSize(int availableRightSize)
		{
            Graphics g = cust.formDisplay.CreateGraphics();
			SizeF textSize = g.MeasureString(toolTipRTB.Text, toolTipRTB.Font);
			int w = (int)textSize.Width+4;
            bool tooSmall = false;
			
			// tooltip larger than the window: wrap
            if (w > cust.formDisplay.ClientRectangle.Right - 20 - toolTip.Left)
			{
				toolTipRTB.WordWrap = true;
                w = cust.formDisplay.Width - 20 - toolTip.Left;
                if (w < 300)
                {
                    tooSmall = true;
                    w = Math.Max(200, availableRightSize - 20);
                }
                textSize = g.MeasureString(toolTipRTB.Text, toolTipRTB.Font, new Size(w, cust.formDisplay.Height));
				w = (int)textSize.Width+4;
			}
			
			if (toolTipRTB.SelectionLength > 0) w += toolTipRTB.SelectionLength/2;
            int h = (int)textSize.Height + 2;
            int dh = 1;
            int dw = 1;
            if (h > 200)
            {
                h = 200; dh = 4; dw = 5;
                toolTipRTB.ScrollBars = RichTextBoxScrollBars.Vertical;
            }
			toolTipRTB.Size = new Size(w, h);
            toolTip.Size = new Size(w + dw, h + dh);
            return !tooSmall;
		}
		
		public void ShowAtMouseLocation(string text)
		{
            if (text != Text)
            {
                toolTip.Visible = false;
                Text = text;
                AutoSize();
            }
			ShowAtMouseLocation();
		}
		
		public void ShowAtMouseLocation()
		{
            //ITabbedDocument doc = PluginBase.MainForm.CurrentDocument;
            Point mousePos = cust.formDisplay.PointToClient(Control.MousePosition);
            toolTip.Left = mousePos.X;// +sci.Left;
            if (toolTip.Right > cust.formDisplay.ClientRectangle.Right)
            {
                toolTip.Left -= (toolTip.Right - cust.formDisplay.ClientRectangle.Right);
            }
            toolTip.Top = mousePos.Y - toolTip.Height - 10;// +sci.Top;
			toolTip.Show();
			toolTip.BringToFront();
		}
		
		public virtual void Hide()
		{
			if (toolTip.Visible)
			{
				toolTip.Visible = false;
				toolTipRTB.Select(0, toolTipRTB.Text.Length);
				toolTipRTB.SelectionFont = new Font(toolTipRTB.Font.FontFamily, toolTipRTB.Font.Size, FontStyle.Regular);
			}
		}

        public virtual void Show()
		{
			toolTip.Visible = true;
			toolTip.BringToFront();
		}


		protected void SetRichText()
		{

            
			toolTipRTB.Text = "";
			toolTipRTB.WordWrap = false;
            toolTipRTB.ScrollBars = RichTextBoxScrollBars.None;

			ArrayList startBold = new ArrayList();
			ArrayList lenBold = new ArrayList();
			int pos = 0;
			// first
			int index = rawText.IndexOf("[B]");
			while (index >= 0)
			{
				toolTipRTB.Text += rawText.Substring(pos, index-pos);
				pos = index+3;
				index = rawText.IndexOf("[/B]", pos);
				if (index < 0) break;
				startBold.Add(toolTipRTB.Text.Length);
				lenBold.Add(index-pos);
				toolTipRTB.Text += rawText.Substring(pos, index-pos);
				pos = index+4;
				// next
				index = rawText.IndexOf("[B]", pos);
			}
			toolTipRTB.Text += rawText.Substring(pos);
			// style
			Font bold = new Font(toolTipRTB.Font.FontFamily, toolTipRTB.Font.Size, FontStyle.Bold);
			for(int i=0; i<startBold.Count; i++)
			{
				toolTipRTB.Select((int)startBold[i], (int)lenBold[i]);
				toolTipRTB.SelectionFont = bold;
			}

            if (toolTipRTB == null) return;
			toolTipRTB.Select(0,0);
		}
		
		#endregion

        #region IDisposable Membri di

        public virtual void Dispose()
        {
            toolTip.Dispose();
            toolTipRTB.Dispose();

            cust = null;

        }

        #endregion
    }
}
