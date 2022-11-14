using deliveraholic_backend.Tools.MessageHandler.Interface;
using System.Collections.Generic;

namespace deliveraholic_backend.Tools.MessageHandler
{
    public class MessageHandler : IMessage
    {
        private static Dictionary<string, List<string>> userConnectionMap { get; set; }
        private static string userConnectionMapLocker { get; set; }


        public MessageHandler()
        {
            userConnectionMap = new Dictionary<string, List<string>>();
            userConnectionMapLocker = string.Empty;
        }


        public List<string> GetUserConnections(string userID)
        {
            // Get userconnections based on ID:

            List<string> conn = new List<string>();
            lock (userConnectionMapLocker)
            {
                conn = userConnectionMap[userID];
            }
            return conn;
        }


        public void KeepUserConnection(string userID, string connectionID)
        {
            // Keep userconnection based on userID and connectionID:

            lock (userConnectionMapLocker)
            {
                if (!userConnectionMap.ContainsKey(userID))
                {
                    userConnectionMap[userID] = new List<string>();
                }
                userConnectionMap[userID].Add(connectionID);
            }
        }


        public void RemoveUserConnection(string connectionID)
        {
            // Remove userconnection based on connectionID:

            lock (userConnectionMapLocker)
            {
                foreach (string userID in userConnectionMap.Keys)
                {
                    if (userConnectionMap.ContainsKey(userID))
                    {
                        if (userConnectionMap[userID].Contains(connectionID))
                        {
                            userConnectionMap[userID].Remove(connectionID);
                            break;
                        }
                    }
                }
            }
        }
    }
}