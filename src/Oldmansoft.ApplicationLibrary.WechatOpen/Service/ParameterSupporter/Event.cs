using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Oldmansoft.ApplicationLibrary.WechatOpen.Provider;
using Oldmansoft.ApplicationLibrary.WechatOpen.Provider.Data;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.ParameterSupporter
{
    class Event : MessageParameterSupporter
    {
        private IPositionStore PositionStore { get; set; }

        public Event(IPositionStore positionStore)
        {
            PositionStore = positionStore;
        }

        override internal MessageType DealType
        {
            get
            {
                return MessageType.Event;
            }
        }

        internal override DealParameter Init(XmlElement element)
        {
            var e = element.GetText("Event");
            switch (e)
            {
                case "LOCATION":
                    var position = new Position();
                    position.Latitude = double.Parse(element.GetText("Latitude"));
                    position.Longitude = double.Parse(element.GetText("Longitude"));
                    position.Precision = double.Parse(element.GetText("Precision"));
                    PositionStore.Set(element.GetText("FromUserName"), position);
                    return Result(MessageType.Position, position);
                case "subscribe":
                    var key = element.GetText("EventKey");
                    var ticket = element.GetText("Ticket");
                    ScanParameter subscribeParameter = null;
                    if (!string.IsNullOrEmpty(key) || !string.IsNullOrEmpty(ticket))
                    {
                        subscribeParameter = new ScanParameter();
                        if (!string.IsNullOrEmpty(key))
                        {
                            subscribeParameter.Scene = key.Replace("qrscene_", string.Empty);
                        }
                        if (!string.IsNullOrEmpty(ticket))
                        {
                            subscribeParameter.Ticket = ticket;
                        }
                    }
                    return Result(MessageType.Subscribe, subscribeParameter);
                case "unsubscribe":
                    return Result(MessageType.Unsubscribe, null);
                case "SCAN":
                    ScanParameter scanParameter = new ScanParameter();
                    scanParameter.Scene = element.GetText("EventKey");
                    scanParameter.Ticket = element.GetText("Ticket");
                    return Result(MessageType.Scan, scanParameter);
                case "CLICK":
                    return Result(MessageType.Click, element.GetText("EventKey"));
                case "VIEW":
                    return Result(MessageType.View, element.GetText("EventKey"));
                case "MASSSENDJOBFINISH":
                    var massSendJobFinish = new MassSendJobFinish();
                    massSendJobFinish.MsgId = long.Parse(element.GetText("MsgID"));
                    massSendJobFinish.Status = element.GetText("Status");
                    massSendJobFinish.TotalCount = int.Parse(element.GetText("TotalCount"));
                    massSendJobFinish.FilterCount = int.Parse(element.GetText("FilterCount"));
                    massSendJobFinish.SentCount = int.Parse(element.GetText("SentCount"));
                    massSendJobFinish.ErrorCount = int.Parse(element.GetText("ErrorCount"));
                    return Result(MessageType.MassSendJobFinish, massSendJobFinish);
                case "TEMPLATESENDJOBFINISH":
                    var templateSendJobFinish = new TemplateSendJobFinish();
                    templateSendJobFinish.MsgId = long.Parse(element.GetText("MsgID"));
                    templateSendJobFinish.Status = element.GetText("Status");
                    return Result(MessageType.TemplateSendJobFinish, templateSendJobFinish);
                default:
                    throw new NotImplementedException(string.Format("不支持微信事件类型 {0}", e));
            }
        }
    }
}
