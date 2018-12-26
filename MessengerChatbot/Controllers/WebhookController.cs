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
                    // Responds with the challenge token from the request
                    logger.LogDebug("Webhook verified");
                    return Ok(challenge);
                } else
                {
                    // Responds with '403 Forbidden' if verify tokens do not match
                    logger.LogDebug("Verify tokens do not match --> Responds with '403 Forbidden'");
                    return Forbid();
                }
            }
            return BadRequest();
        }

        // POST '/webhook'
        [HttpPost]
        public ActionResult Post([FromBody] dynamic body)
        {
            var bodyObject = body["object"];
            if (bodyObject != null && bodyObject == "page")
            {
                var bodyEntry = body["entry"];

                foreach (var entry in bodyEntry)
                {
                    var webhook_event = entry["messaging"][0];
                    var sender_psid = webhook_event["sender"]["id"];

                    if (webhook_event["message"] != null)
                    {
                        logger.LogDebug("RECEIVED MESSAGE");
                    } else if (webhook_event["postback"] != null)
                    {
                        logger.LogDebug("RECEIVED POSTBACK");
                    }
                }

                return Ok("EVENT_RECEIVED");
            }
            return NotFound();
        }
    }
}
