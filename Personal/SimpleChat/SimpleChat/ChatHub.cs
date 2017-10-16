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
            Clients.All.newMessage(message);
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
    }

    public class SendData
    {
        public int Id { get; set; }
        public string Data { get; set; }
    }
}