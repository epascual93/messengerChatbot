using MessengerChatbot.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerChatbot.Models
{
    public class ApiResponse
    {
        public ApiResponse(string type, string id, IApiMessage _message)
        {
            messaging_type = type;
            recipient = new Recipient(id);
            message = _message;
        }

        public string messaging_type { get; set; }
        public Recipient recipient { get; set; }
        public IApiMessage message { get; set; }
    }

    public class Recipient
    {
        public Recipient(string _id)
        {
            id = _id;
        }
        public string id { get; set; }
    }
}
