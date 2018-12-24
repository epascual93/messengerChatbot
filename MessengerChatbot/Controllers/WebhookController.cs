using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MessengerChatbot.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        ILogger<WebhookController> logger;

        public WebhookController(ILogger<WebhookController> _logger)
        {
            logger = _logger;
        }

        // GET '/webhook'
        [HttpGet]
        public ActionResult Get([FromQuery] string mode, [FromQuery] string token, [FromQuery] string challenge)
        {
            logger.LogDebug("Receiving GET request. ("+mode+","+token+","+challenge+")");

            // Your verify token. Should be a random string.
            string VERIFY_TOKEN = "<VERIFY_TOKEN>"; //TODO: Get token from configuration

            // Checks if a token and mode is in the query string of the request
            if (mode != null && token != null){
                if (mode == "subscribe" && token == VERIFY_TOKEN)
                {
                    logger.LogDebug("Webhook verified");
                    return Ok();
                } else
                {
                    return Forbid();
                }
            }

            return BadRequest();
        }

        // POST '/webhook'
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
