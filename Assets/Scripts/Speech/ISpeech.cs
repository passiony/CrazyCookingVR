using System;

namespace GT.Hotfix
{
    /// <summary>
    /// 朗读者接口
    /// </summary>
    public interface ISpeech
    {
        /// <summary>
        /// 朗读语音
        /// </summary>
        /// <param name="content">语音内容</param>
        /// <param name="callback">朗读完毕回调</param>
        void Play(string content, Action callback);

        /// <summary>
        /// 停止朗读
        /// </summary>
        /// <param name="auto"></param>
        void Stop(bool auto = false);

        /// <summary>
        /// 每帧更新
        /// </summary>
        void Update();
    }
}