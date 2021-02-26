using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Supporter
{
    /// <summary>
    /// 图片消息
    /// </summary>
    class Image : ParameterSupporter
    {
        override internal MessageType DealType
        {
            get
            {
                return MessageType.Image;
            }
        }

        internal override DealParameter Init(System.Xml.XmlElement element)
        {
            var result = new ImageParameter
            {
                PicUrl = element.GetText("PicUrl"),
                MediaId = element.GetText("MediaId")
            };
            return Result(result);
        }
    }
}
