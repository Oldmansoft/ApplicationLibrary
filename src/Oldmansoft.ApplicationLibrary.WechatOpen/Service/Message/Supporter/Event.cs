using Oldmansoft.ApplicationLibrary.WechatOpen.Provider;
using Oldmansoft.ApplicationLibrary.WechatOpen.Provider.Data;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data;
using System.Xml;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Supporter
{
    class Event : ParameterSupporter
    {
        private readonly IPositionStore PositionStore;

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
                    var position = new Position
                    {
                        Latitude = double.Parse(element.GetText("Latitude")),
                        Longitude = double.Parse(element.GetText("Longitude")),
                        Precision = double.Parse(element.GetText("Precision"))
                    };
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
                    ScanParameter scanParameter = new ScanParameter
                    {
                        Scene = element.GetText("EventKey"),
                        Ticket = element.GetText("Ticket")
                    };
                    return Result(MessageType.Scan, scanParameter);
                case "CLICK":
                    return Result(MessageType.Click, element.GetText("EventKey"));
                case "VIEW":
                    return Result(MessageType.View, element.GetText("EventKey"));
                case "MASSSENDJOBFINISH":
                    var massSendJobFinish = new MassSendJobFinish
                    {
                        MsgId = long.Parse(element.GetText("MsgID")),
                        Status = element.GetText("Status"),
                        TotalCount = int.Parse(element.GetText("TotalCount")),
                        FilterCount = int.Parse(element.GetText("FilterCount")),
                        SentCount = int.Parse(element.GetText("SentCount")),
                        ErrorCount = int.Parse(element.GetText("ErrorCount"))
                    };
                    return Result(MessageType.MassSendJobFinish, massSendJobFinish);
                case "TEMPLATESENDJOBFINISH":
                    var templateSendJobFinish = new TemplateSendJobFinish
                    {
                        MsgId = long.Parse(element.GetText("MsgID")),
                        Status = element.GetText("Status")
                    };
                    return Result(MessageType.TemplateSendJobFinish, templateSendJobFinish);
                default:
                    return Result(MessageType.UnknowEvent, element);
            }
        }
    }
}
