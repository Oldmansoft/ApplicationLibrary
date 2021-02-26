namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Supporter
{
    /// <summary>
    /// 语音参数
    /// </summary>
    public class VoiceParameter : MediaParameter
    {
        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 开通语音识别后，为语音识别结果，使用UTF8编码。
        /// </summary>
        public string Recognition { get; set; }
    }
}
