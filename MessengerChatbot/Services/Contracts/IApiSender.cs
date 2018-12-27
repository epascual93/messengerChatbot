using MessengerChatbot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerChatbot.Services.Contracts
{
    public interface IApiSender
    {
        Task Send(ApiResponse apiResponse);
    }
}
