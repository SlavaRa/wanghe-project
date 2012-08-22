using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace PreviousEdit
{
    [Serializable]
    public class Settings
    {
        public Boolean _enable;

        [DisplayName("test")]
        [Description("test")]
        [DefaultValue(true)]
        public Boolean Enable
        {
            get { return this._enable; }
            set { this._enable = value; }
        }
    }
}
