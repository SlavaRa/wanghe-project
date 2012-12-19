using System;
using System.Collections.Generic;
using System.Text;

namespace SkinEditor
{
    public class CreatNodeEventArgs:EventArgs
    {
        public int Type;
        public string NodeName;
        public ComSkin Skin;
        /// <summary>
        /// 创建节点事件参数类
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="skin"></param>
        public CreatNodeEventArgs(int type,string name,ComSkin skin)
        {
            Type = type;
            NodeName = name;
            Skin = skin;
        }
    }
}
