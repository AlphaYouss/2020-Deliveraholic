using deliveraholic_backend.Tools.MessageHandler.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Primitives;
using System;
using System.Threading.Tasks;

namespace deliveraholic_backend.Tools.MessageHandler.Hubs
{
    public class UserMessageHub : Hub
    {
        private readonly IMessage message;


        public UserMessageHub(IMessage iMessage)
        {
            message = iMessage;
        }


        public string GetConnectionID()
        {
            // Get connectionID based on userID:

            HttpContext httpContext = Context.GetHttpContext();
            StringValues userID = httpContext.Request.Query["userID"];

            message.KeepUserConnection(userID, Context.ConnectionId);
            return Context.ConnectionId;
        }


        public async override Task OnDisconnectedAsync(Exception exception)
        {
            // Remove connection when disconnected:

            string connectionID = Context.ConnectionId;
            message.RemoveUserConnection(connectionID);

            await Task.FromResult(0);
        }
    }
}