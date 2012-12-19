using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace SkinEditor
{
    [Serializable]
    public class ComSkin
    {
        private String _name;
        private List<ComLayer> _skinLayer = new List<ComLayer>();

        [Description("皮肤层")]
        public List<ComLayer> SkinLayer
        {
            get { return _skinLayer; }
            set { _skinLayer = value; }
        }

        [Description("皮肤名称")]
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
       


    }
}
