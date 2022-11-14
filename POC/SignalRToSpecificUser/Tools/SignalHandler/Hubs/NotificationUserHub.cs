using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Primitives;
using SignalRDemo.Tools.SignalHandler.Interface;

namespace SignalRDemo.Tools.SignalHandler.Hubs
{
    public class NotificationUserHub : Hub
    {
        private readonly INotification notification;
        public NotificationUserHub(INotification notificationManager)
        {
            notification = notificationManager;
        }


        public string GetConnectionID()
        {
            HttpContext httpContext = Context.GetHttpContext();
            StringValues userID = httpContext.Request.Query["userID"];

            notification.KeepUserConnection(userID, Context.ConnectionId);
            return Context.ConnectionId;
        }


        public async override Task OnDisconnectedAsync(Exception exception)
        {
            string connectionID = Context.ConnectionId;
            notification.RemoveUserConnection(connectionID);

            await Task.FromResult(0);
        }
    }
}