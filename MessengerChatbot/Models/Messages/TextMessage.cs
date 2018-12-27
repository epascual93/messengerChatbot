using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerChatbot.Models.Messages
{
    public class TextMessage : IApiMessage
    {
        public TextMessage(string _text)
        {
            text = _text;
        }
        public string text { get; set; }
    }
}
