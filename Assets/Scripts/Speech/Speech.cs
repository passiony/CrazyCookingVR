#define Speech
using System;
using UnityEngine;

namespace GT.Hotfix
{
    /// <summary>
    /// 基于微软SAPI TTS朗读者
    /// </summary>
    public class Speech : ISpeech
    {
#if Speech
        private SpeechLib.SpVoice manVoice;
#endif
        private bool speaking;
        private Action complete;

        private Action Complete
        {
            get => complete;
            set { complete = value; }
        }
#if Speech
        public Speech(string vName)
        {
            manVoice = new SpeechLib.SpVoice();
            manVoice.Rate = 3;
            manVoice.Volume = 100;
            InitVoice(manVoice, vName);
        }

        /// <summary>
        /// 初始化朗读者声音
        /// </summary>
        /// <param name="voice">朗读器</param>
        /// <param name="name">朗读者名字</param>
        void InitVoice(SpeechLib.SpVoice voice, string name)
        {
            if (voice != null)
            {
                for (int i = 0; i < manVoice.GetVoices().Count; i++)
                {
                    var item = voice.GetVoices().Item(i);
                    var desc = item.GetDescription();
                    // Debug.Log(desc);
                    if (desc.Contains(name))
                    {
                        voice.Voice = item;
                        break;
                    }
                }
            }
        }
#else
        public Speech(string vName)
        {

        }
#endif

        /// <summary>
        /// 朗读文本内容
        /// </summary>
        /// <param name="content">文本内容</param>
        /// <param name="callback">朗读完毕回调</param>
        public void Play(string content, Action callback)
        {
            Stop(true);
#if Speech
            manVoice.Speak(content, SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync);
#endif
            speaking = true;
            Complete = callback;
        }

        /// <summary>
        /// 停止朗读
        /// </summary>
        /// <param name="auto"></param>
        public void Stop(bool auto = false)
        {
            if (speaking)
            {
                if (!auto)
                    Trigger();
                speaking = false;
#if Speech
                manVoice.Speak(string.Empty, SpeechLib.SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
#endif
            }
        }
        
        public void Update()
        {
            if (speaking)
            {
#if Speech
                if (manVoice.Status.RunningState == SpeechLib.SpeechRunState.SRSEDone)
#endif
                {
                    speaking = false;
                    Trigger();
                }
            }
        }

        void Trigger()
        {
            Complete?.Invoke();
            Complete = null;
        }
    }
}