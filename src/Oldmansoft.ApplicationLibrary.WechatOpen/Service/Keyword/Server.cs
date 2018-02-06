using Oldmansoft.ApplicationLibrary.WechatOpen.Provider;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Keyword;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Dealers;
using System.Reflection;
using System.Xml;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Keyword
{
    /// <summary>
    /// 关键字响应服务
    /// </summary>
    public class Server : Message.IResponse
    {
        private Message.IResponse Origin { get; set; }

        internal ConcurrentDictionary<string, KeywordDealer> Dealers { get; private set; }
        
        internal KeywordDealer NoMatchDealer { get; private set; }
        
        public ReplyMessage DefaultMessage { get; set; }

        public IPositionStore PositionStore { get { return Origin.PositionStore; } }

        IPlatform Message.IResponse.Platform
        {
            get
            {
                return Origin.Platform;
            }
        }

        public Server(Message.IResponse server, KeywordType type = KeywordType.ClickAndInput)
        {
            DefaultMessage = ReplyMessage.Null;
            Dealers = new ConcurrentDictionary<string, KeywordDealer>();
            if ((type & KeywordType.Click) == KeywordType.Click)
            {
                server.AddMessageDealer(new ClickDealer(this));
            }
            if ((type & KeywordType.Input) == KeywordType.Input)
            {
                server.AddMessageDealer(new InputDealer(this));
            }
            Origin = server;
        }
        /// <summary>
        /// 添加关键字处理类
        /// </summary>
        /// <param name="dealer"></param>
        public void AddKeywordDealer(KeywordDealer dealer)
        {
            if (dealer == null) throw new ArgumentNullException("dealer");
            dealer.SetPlatform(Origin.Platform);
            if (dealer is NotMatchDealer)
            {
                NoMatchDealer = dealer;
                return;
            }
            var keywords = dealer.GetKeywords();
            if (keywords == null)
            {
                return;
            }
            foreach (var item in keywords)
            {
                if (string.IsNullOrEmpty(item)) continue;
                if (!Dealers.TryAdd(item, dealer))
                {
                    throw new ArgumentException(string.Format("重复关键字处理: {0}", item));
                }
            }
        }

        /// <summary>
        /// 从程序集中注册所有的 KeywordDealer 对象
        /// </summary>
        /// <param name="assembly"></param>
        public void AddKeywordFromAssembly(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(KeywordDealer)) && !type.IsAbstract)
                {
                    AddKeywordDealer(Activator.CreateInstance(type) as KeywordDealer);
                }
            }
        }

        /// <summary>
        /// 注册消息处理对象
        /// </summary>
        /// <param name="dealer"></param>
        public void AddMessageDealer(MessageDealer dealer)
        {
            Origin.AddMessageDealer(dealer);
        }

        /// <summary>
        /// 从程序集中注册所有的 MessageDealer 对象
        /// </summary>
        /// <param name="assembly"></param>
        public void AddMessageDealerFromAssembly(Assembly assembly)
        {
            Origin.AddMessageDealerFromAssembly(assembly);
        }

        /// <summary>
        /// 处理 Xml 消息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public XmlDocument Deal(XmlDocument input)
        {
            return Origin.Deal(input);
        }
    }
}
