using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerChatbot.BusinessLogic.Contracts
{
    public interface IMessageProcessor
    {
        void processTextMessage(string sender_psid, string textMessage);
    }
}
