using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace SimpleChat
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void SendMessage(string message)
        {
            //Clients.Caller.newMessage(message);
            //Clients.Client(Context.ConnectionId).newMessage(message); // Same as above. 

            //Clients.All.newMessage(message); // Everyone
            //Clients.Others.newMessages(message); // Everyone other than me.
            //Clients.AllExcept(Context.ConnectionId).newMessage(message); // Everyone other than specific clients.

            var msg = String.Format("{0}: {1}", Context.ConnectionId, message);

            Clients.All.newMessage(message);
        }

        public void JoinRoom(string room)
        {
            Groups.Add(Context.ConnectionId, room);
        }

        public void SendMessageToRoom(string room, string message)
        {
            var msg = String.Format("{0}: {1}", Context.ConnectionId, message);

            Clients.Group(room).newMessage(msg);
        }

        public void SendMessageData(SendData data)
        {
            // process incoming data..
            // transform data...
            // craft new data..

            Clients.All.newData(data);
        }

        //public Task<int> SendDataAsync()
        //{
        //    //async work...
        //}

        public override Task OnConnected()
        {
            SendMonitoringData("Connected", Context.ConnectionId);
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            SendMonitoringData("Disconnected", Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            SendMonitoringData("Reconnected", Context.ConnectionId);
            return base.OnReconnected();
        }



        private void SendMonitoringData(string eventType, string connectionId)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MonitorHub>();
            context.Clients.All.newEvent(eventType, connectionId);
        }
    }

    public class SendData
    {
        public int Id { get; set; }
        public string Data { get; set; }
    }
}