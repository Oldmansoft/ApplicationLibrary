using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Dealers;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Supporter;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message
{
    /// <summary>
    /// 消息响应服务
    /// </summary>
    public class Server : IResponse
    {
        private readonly ConcurrentDictionary<MessageType, MessageDealer> MessageDealers;

        private readonly Dictionary<string, ParameterSupporter> ParameterSupporters;

        /// <summary>
        /// 平台
        /// </summary>
        public IPlatform Platform { get; private set; }
        
        /// <summary>
        /// 没有处理消息时
        /// </summary>
        public event Func<DealParameter, ReplyMessage> OnNoDealMessage;

        /// <summary>
        /// 没有处理时
        /// </summary>
        public event Func<DealParameter, XmlDocument> OnNoDeal;

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="platform"></param>
        public Server(IPlatform platform)
        {
            Platform = platform ?? throw new ArgumentNullException();
            MessageDealers = new ConcurrentDictionary<MessageType, MessageDealer>();
            ParameterSupporters = new Dictionary<string, ParameterSupporter>(StringComparer.CurrentCultureIgnoreCase);
            AddParameterSupporter(new Event(platform.PositionStore));
            AddParameterSupporter(new Image());
            AddParameterSupporter(new Link());
            AddParameterSupporter(new Location());
            AddParameterSupporter(new ShortVideo());
            AddParameterSupporter(new Text());
            AddParameterSupporter(new Video());
            AddParameterSupporter(new Voice());
        }

        /// <summary>
        /// 添加参数支持者
        /// </summary>
        /// <param name="supporter"></param>
        public void AddParameterSupporter(ParameterSupporter supporter)
        {
            ParameterSupporters.Add(supporter.DealType.ToString(), supporter);
        }

        /// <summary>
        /// 添加消息处理者
        /// </summary>
        /// <param name="dealer"></param>
        public void AddMessageDealer(MessageDealer dealer)
        {
            if (dealer == null) throw new ArgumentNullException();
            dealer.SetPlatform(Platform);
            if (MessageDealers.TryAdd(dealer.GetMessageType(), dealer)) return;
            throw new ArgumentException(string.Format("重复消息类型处理: {0}", dealer.GetMessageType().ToString()));
        }

        /// <summary>
        /// 从程序集添加消息处理者
        /// </summary>
        /// <param name="assembly"></param>
        public void AddMessageDealerFromAssembly(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(MessageDealer)) && !type.IsAbstract)
                {
                    AddMessageDealer(Activator.CreateInstance(type) as MessageDealer);
                }
            }
        }

        /// <summary>
        /// 处理 Xml 消息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public XmlDocument Deal(XmlDocument input)
        {
            return Deal(input, out _);
        }

        /// <summary>
        /// 处理 Xml 消息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        public XmlDocument Deal(XmlDocument input, out InputHead head)
        {
            head = null;
            if (input == null) return null;
            if (input.DocumentElement == null) return null;
            if (!InitInputHead(input.DocumentElement, out head)) return null;

            if (!ParameterSupporters.TryGetValue(head.MsgType, out ParameterSupporter parameterSupporter))
            {
                throw new NotImplementedException(string.Format("{0} 没有实现", head.MsgType));
            }

            var parameter = parameterSupporter.Init(input.DocumentElement);
            parameter.Source = input;
            parameter.Head = head;
            ReplyMessage message;
            if (MessageDealers.TryGetValue(parameter.DealType, out MessageDealer dealer))
            {
                message = dealer.DealMessage(parameter);
            }
            else if (OnNoDealMessage != null)
            {
                message = OnNoDealMessage(parameter);
            }
            else if (OnNoDeal != null)
            {
                return OnNoDeal(parameter);
            }
            else
            {
                return null;
            }

            if (message == null)
            {
                return null;
            }
            return message.CreateDocument(head.FromUserName, head.ToUserName);
        }

        private bool InitInputHead(XmlElement element, out InputHead head)
        {
            head = null;
            var msgType = element.GetText("MsgType");
            var createTime = element.GetText("CreateTime");
            var toUserName = element.GetText("ToUserName");
            var fromUserName = element.GetText("FromUserName");
            var msgId = element.GetText("MsgId");

            if (msgType == null) return false;
            if (createTime == null) return false;
            if (toUserName == null) return false;
            if (fromUserName == null) return false;

            head = new InputHead
            {
                AppId = Platform.Config.AppId,
                MsgType = msgType,
                ToUserName = toUserName,
                FromUserName = fromUserName
            };
            if (msgId != null) head.MsgId = long.Parse(msgId);
            head.CreateTime = int.Parse(createTime).GetLocalTime();
            return true;
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool CheckSignature(string signature, string timestamp, string nonce, string token)
        {
            string[] inputs = { token, timestamp, nonce };
            Array.Sort(inputs);
            var hash = string.Join("", inputs).GetSHA1Hash().ToLower();
            return hash == signature;
        }
    }
}
