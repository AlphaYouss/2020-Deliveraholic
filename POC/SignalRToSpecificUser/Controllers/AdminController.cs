using SignalRDemo.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Tools.SignalHandler.Hubs;
using SignalRDemo.Tools.SignalHandler.Interface;

namespace SignalRDemo.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHubContext<NotificationUserHub> notificationHubContext;
        private readonly INotification notification;

        public AdminController(IHubContext<NotificationUserHub> iNotificationHubContext, INotification iNotification)
        {
            notificationHubContext = iNotificationHubContext;
            notification = iNotification;
        }


        public IActionResult SendToSpecificUser()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> SendToSpecificUser(Article article)
        {
            List<string> connections = notification.GetUserConnections(article.userID);

            if (connections != null && connections.Count > 0)
            {
                foreach (string connectionID in connections)
                {
                    await notificationHubContext.Clients.Client(connectionID).SendAsync("sendToUser", article.articleHeading, article.articleContent);
                }
            }
            return View();
        }
    }
}