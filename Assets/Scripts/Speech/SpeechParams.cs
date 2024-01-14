using System;

namespace GT.Hotfix
{
    public class SpeechParams
    {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public int Sex { get; private set; }
        public Action Complete { get; private set; }


        public SpeechParams(int id, string content, int sex, Action complete)
        {
            Id = id;
            Content = content;
            Sex = sex;
            Complete = complete;
        }

        public void Clear()
        {
            Id = 0;
            Content = string.Empty;
            Sex = 0;
            Complete = null;
        }
    }
}