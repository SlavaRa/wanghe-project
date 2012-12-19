using System;
using System.Collections.Generic;
using System.Text;

namespace SkinEditor
{
    public class SkinNodeName
    {
        /// <summary>
        /// 
        /// </summary>
        public static string upImage = "upImage";
        /// <summary>
        /// 
        /// </summary>
        public static string overImage = "overImage";
        /// <summary>
        /// 
        /// </summary>
        public static string downImage = "downImage";

        /// <summary>
        /// 
        /// </summary>
        public static string backgroundImage = "backgroundImage";

        /// <summary>
        /// 
        /// </summary>
        public static string selectImage = "selectImage";

        /// <summary>
        /// 
        /// </summary>
        public static string tileImage = "tileImage";

        /// <summary>
        /// 
        /// </summary>
        public static string title = "title";
        /// <summary>
        /// 
        /// </summary>
        public static string canvas = "canvas";
        /// <summary>
        /// 
        /// </summary>
        public static string closeButton = "closeButton";
        /// <summary>
        /// 
        /// </summary>
        public static string track = "track";
        /// <summary>
        /// 
        /// </summary>
        public static string upButton = "upButton";
        /// <summary>
        /// 
        /// </summary>
        public static string slipButton = "slipButton";
        /// <summary>
        /// 
        /// </summary>
        public static string bottomButton = "bottomButton";
        /// <summary>
        /// 
        /// </summary>
        public static string unSelectImage = "unSelectImage";
        /// <summary>
        /// 
        /// </summary>
        public static string openIcon = "openIcon";
        /// <summary>
        /// 
        /// </summary>
        public static string closeIcon = "closeIcon";


        private static string[] typeArray = { upImage,
                                        overImage,
                                        downImage,
                                        backgroundImage,
                                        selectImage,
                                        tileImage,
                                        title,
                                        canvas,
                                        closeButton,
                                        track,
                                        upButton,
                                        slipButton,
                                        bottomButton,
                                        unSelectImage,
                                        openIcon,
                                        closeIcon
                                        };

       /// <summary>
       /// 通过类型取得名字
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
        public static string getNameByType(int type)
        {
            return typeArray[type].ToString();
        }

    }
}
