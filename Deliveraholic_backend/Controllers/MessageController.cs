using deliveraholic_backend.Models.Custom;
using deliveraholic_backend.Tools.MessageHandler.Hubs;
using deliveraholic_backend.Tools.MessageHandler.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliveraholic_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : Controller
    {

        private readonly IHubContext<UserMessageHub> hub;
        private readonly IMessage message;


        public MessageController(IHubContext<UserMessageHub> iHub, IMessage iMessage)
        {
            // Set Hub and Message.

            hub = iHub;
            message = iMessage;
        }


        //// [USER] ////


        [Route("user")]
        [HttpPost]
        public async Task<ActionResult> MessageSpecificUser([FromBody] Message userMessage)
        {
            List<string> connections = message.GetUserConnections(userMessage.userID);

            if (connections != null && connections.Count > 0)
            {
                foreach (string connectionID in connections)
                {
                    await hub.Clients.Client(connectionID).SendAsync("sendToUser", userMessage.heading, userMessage.content);
                }
                return Ok("Message sent!");
            }
            return NotFound("User not found!");
        }
    }
}