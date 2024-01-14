using System;

namespace GT.Hotfix
{
    /// <summary>
    /// 朗读特殊符号过滤器
    /// </summary>
    public class SpeechFilter
    {
        [Serializable]
        public class SoundReplace
        {
            //原关键字
            public string origin;
            //替换关键字
            public string replace;
            public SoundReplace(string origin, string replace)
            {
                this.origin = origin;
                this.replace = replace;
            }
        }
        
        /// <summary>
        /// 忽略过滤组
        /// </summary>
        public static readonly SoundReplace[] Ignores =
        {
            new SoundReplace("VR", "δ"),
        };

        /// <summary>
        /// 过滤组
        /// </summary>
        public static readonly SoundReplace[] Replaces =
        {
            new SoundReplace(@"kW.h", "千瓦时"),
            new SoundReplace(@"mm²", "平方毫米"),
            new SoundReplace(@"mm", "毫米"),
            new SoundReplace(@"Ⅲ", "三"),
            new SoundReplace(@"Ⅱ", "二"),
            new SoundReplace(@"Ⅰ", "一"),
            new SoundReplace(@"#", "号"),
            new SoundReplace(@"KM", "千米"),
            new SoundReplace(@"MA", "毫安"),
            new SoundReplace(@"KV", "千伏"),
            new SoundReplace(@"MΩ", "兆欧"),
            new SoundReplace(@"KΩ", "千欧"),
            new SoundReplace(@"M", "米"),
            new SoundReplace(@"V", "伏"),
            new SoundReplace(@"Ω", "欧姆"),
            new SoundReplace(@"\\n", "。"),
            new SoundReplace(@"\n", "。"),
        };
        

    }
}