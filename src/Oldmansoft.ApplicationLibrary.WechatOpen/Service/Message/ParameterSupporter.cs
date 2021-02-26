using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message
{
    /// <summary>
    /// 消息参数提供者
    /// </summary>
    public abstract class ParameterSupporter
    {
        /// <summary>
        /// 处理的消息类型
        /// </summary>
        internal abstract MessageType DealType { get; }

        /// <summary>
        /// 创建结果
        /// </summary>
        /// <param name="dealType"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected DealParameter Result(MessageType dealType, object parameter)
        {
            var result = new DealParameter();
            result.DealType = dealType;
            result.Paramenter = parameter;
            return result;
        }

        /// <summary>
        /// 创建结果
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected DealParameter Result(object parameter)
        {
            return Result(DealType, parameter);
        }

        internal abstract DealParameter Init(System.Xml.XmlElement element);
    }
}
