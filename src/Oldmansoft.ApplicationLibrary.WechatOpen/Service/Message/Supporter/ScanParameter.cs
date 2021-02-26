namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Supporter
{
    /// <summary>
    /// 扫描参数
    /// </summary>
    public class ScanParameter
    {
        /// <summary>
        /// 创建二维码时的二维码 scene_id 或 scene_str
        /// </summary>
        public string Scene { get; set; }

        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket { get; set; }
    }
}
