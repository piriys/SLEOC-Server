﻿using System;
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

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
             _cardConnections.Remove(Context.ConnectionId);

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
            Clients.Others.log(Context.ConnectionId + " connected to group " + key);
            return Groups.Add(Context.ConnectionId, key);
        }
    }
}