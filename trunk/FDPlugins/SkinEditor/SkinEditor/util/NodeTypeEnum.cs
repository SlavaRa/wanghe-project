using System;
using System.Collections.Generic;
using System.Text;

namespace SkinEditor
{
    /// <summary>
    /// 皮肤类型的枚举
    /// </summary>
    public enum NodeTypeEnum : int
    {
        Button = 0,
        SelectButton = 1,
        F9BitMap = 2,
        Panel = 3,
        List = 4
    }

    /// <summary>
    /// 皮肤 状态层的命名枚举
    /// </summary>
    public enum SkinLayerEnum : int
    {
        upImage = 0,
        overImage = 1,
        downImage = 2,
        backgroundImage = 3,
        selectImage = 4,
        tileImage = 5,
        title = 6,
        canvas = 7,
        closeButton = 8,
        track = 9,
        upButton = 10,
        slipButton = 11,
        bottomButton = 12,
        unSelectImage = 13,
        openIcon = 14,
        closeIcon = 15
    }
}
