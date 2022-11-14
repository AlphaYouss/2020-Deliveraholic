using System.Collections.Generic;
using SignalRDemo.Tools.SignalHandler.Interface;

namespace SignalRDemo.Tools.SignalHandler
{
    public class NotificationHandler : INotification
    {
        private static Dictionary<string, List<string>> userConnectionMap { get; set; }
        private static string userConnectionMapLocker { get; set; } 

        public NotificationHandler()
        {
            userConnectionMap = new Dictionary<string, List<string>>();
            userConnectionMapLocker = string.Empty;
        }


        public List<string> GetUserConnections(string userID)
        {
            List<string> conn = new List<string>();
            lock (userConnectionMapLocker)
            {
                conn = userConnectionMap[userID];
            }
            return conn;
        }


        public void KeepUserConnection(string userID, string connectionID)
        {
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