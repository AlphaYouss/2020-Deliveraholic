using System.Collections.Generic;

namespace deliveraholic_backend.Tools.MessageHandler.Interface
{
    public interface IMessage
    {
        // Message methods:

        List<string> GetUserConnections(string userID);
        void KeepUserConnection(string userID, string connectionID);
        void RemoveUserConnection(string connectionID);
    }
}