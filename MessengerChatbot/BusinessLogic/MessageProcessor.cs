using MessengerChatbot.BusinessLogic.Contracts;
using MessengerChatbot.Models;
using MessengerChatbot.Models.Messages;
using MessengerChatbot.Services.Contracts;

namespace MessengerChatbot.BusinessLogic
{
    public class MessageProcessor : IMessageProcessor
    {
        IApiSender apiSender;

        public MessageProcessor(IApiSender sender)
        {
            apiSender = sender;
        }

        public void processTextMessage(string sender_psid, string textMessage)
        {
            IApiMessage message = new TextMessage("Escribiste " + textMessage);
            ApiResponse response = new ApiResponse("RESPONSE", sender_psid, message);
            apiSender.Send(response);
        }
    }
}
