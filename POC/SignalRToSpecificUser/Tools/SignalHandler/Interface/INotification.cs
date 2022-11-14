using System.Collections.Generic;

namespace SignalRDemo.Tools.SignalHandler.Interface
{
    public interface INotification
    {
        List<string> GetUserConnections(string userID);
        void KeepUserConnection(string userID, string connectionID);
        void RemoveUserConnection(string connectionID);
    }
}