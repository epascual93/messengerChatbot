using MessengerChatbot.Models;
using MessengerChatbot.Services.Contracts;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MessengerChatbot.Services
{
    public class ApiSender : IApiSender
    {
        //TODO: Read ACCESS_TOKEN from configuration
        private static readonly string ACCESS_TOKEN = "<PAGE_ACCESS_TOKEN>";
        private readonly ILogger<ApiSender> logger;

        public ApiSender(ILogger<ApiSender> _logger)
        {
            logger = _logger;
        } 

        public async Task Send(ApiResponse response)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.PostAsJsonAsync("https://graph.facebook.com/v2.6/me/messages" +
                                                    "&access_token=" + ACCESS_TOKEN, 
                                                    response);

            var msg = await stringTask;
            logger.LogDebug(msg.Content.ToString());
        }
    }
}
