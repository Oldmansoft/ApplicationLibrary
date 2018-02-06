using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Keyword
{
    class InputDealer : Message.Dealers.MessageDealer
    {
        private Server Server { get; set; }

        public InputDealer(Server server)
        {
            Server = server;
        }

        protected override MessageType Type
        {
            get
            {
                return MessageType.Text;
            }
        }
        
        protected override ReplyMessage Deal(DealParameter parameter)
        {
            return CreateMessage(parameter.Head, parameter.DealType, parameter.Paramenter as string);
        }

        private ReplyMessage CreateMessage(InputHead head, MessageType msgType, string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                return null;
            }
            else
            {
                command = command.Trim();
            }

            KeywordDealer dealer;
            if (!Server.Dealers.TryGetValue(command, out dealer))
            {
                if (Server.NoMatchDealer != null)
                {
                    return Server.NoMatchDealer.DealMessage(head, command);
                }
                return Server.DefaultMessage;
            }
            return dealer.DealMessage(head, command);
        }
    }
}
