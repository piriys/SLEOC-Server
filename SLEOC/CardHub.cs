using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;

namespace SLEOC
{
    [HubName("cardHub")]
    public class CardHub : Hub
    {
        private cdashdbEntities db = new cdashdbEntities();

        private readonly static Dictionary<string, string> _cardConnections =
               new Dictionary<string, string>();
        private readonly static Dictionary<string, string> _teamConnections =
               new Dictionary<string, string>();

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            _cardConnections.Remove(Context.ConnectionId);
            _teamConnections.Remove(Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }

        [HubMethodName("joinHub")]
        public Task JoinHub(string key)
        {
            _cardConnections.Add(Context.ConnectionId, key);
            Clients.Caller.log("Hub Connected, key = " + key);
            Clients.Caller.log("Current Card Connection Count: " + _cardConnections.Count);
            Clients.Others.log(Context.ConnectionId + " connected with key " + key);
            return Clients.Caller.log("Card sent");
        }

        [HubMethodName("sendCard")]
        public Task SendCard(string encrypted, string team)
        {
            var connections = _teamConnections.Where(x => x.Value == team).Select(x => x.Key).ToList();

            encrypted = Helpers.XOR.Decrypt(encrypted, Helpers.Constants.XORAppKey);
            string data = HttpUtility.UrlDecode(encrypted);

            foreach (string connection in connections)
            {
                if (connection != Context.ConnectionId)
                {
                    Clients.Client(connection).receiveCard(data);
                    Clients.Client(connection).log("Card recieved from " + Context.ConnectionId);
                }
            }

            return Clients.Caller.log("Card sent");
        }

        [HubMethodName("joinTeam")]
        public Task JoinTeam(string team)
        {
            if (_teamConnections.ContainsKey(Context.ConnectionId))
            {
                string previousTeam = _teamConnections[Context.ConnectionId];
                Groups.Remove(Context.ConnectionId, previousTeam);
                _teamConnections.Remove(Context.ConnectionId);
            }

            _teamConnections.Add(Context.ConnectionId, team);

            Clients.Caller.log("Team Connected, team = " + team);
            Clients.Caller.log("Current Team Connection Count: " + _teamConnections.Where(x => x.Value == team).Select(x => x.Key).ToList().Count);
            Clients.Others.log(Context.ConnectionId + " connected to team " + team);
            return Groups.Add(Context.ConnectionId, team.ToString());
        }
    }
}