using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace SkinEditor
{
    [Serializable]
    public class ComLayer
    {
        private string _name;
        private SkinLayerEnum _layer;
        private LayerType _layerType;

      

        [Description("图层名称")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Description("图层类型")]
        public SkinLayerEnum Layer
        {
            get { return _layer; }
            set { _layer = value; }
        }

        [Description("图层样式")]
        [DefaultValue(LayerType.name)]
        public LayerType LayerType
        {
            get { return _layerType; }
            set { _layerType = value; }
        }


    }

    public enum LayerType
    {
        name = 0,//普通的name x y width height
        link = 1//link样式的
    }
}
