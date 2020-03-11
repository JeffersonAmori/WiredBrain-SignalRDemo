using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WiredBrain.Helpers;
using WiredBrain_SignalRDemo.Models;

namespace WiredBrain_SignalRDemo.Hubs
{
    public class CoffeeHub : Hub<ICoffeeClients>
    {
        private readonly OrderChecker _orderChecker = new OrderChecker(new Random());

        public async Task GetUpdateForOrder(Order order)
        {
            await Clients.Others.NewOrder(order);
            UpdateInfo result;
            do
            {
                result = _orderChecker.GetUpdate(order);
                await Task.Delay(700);
                if (!result.New) continue;

                await Clients.Caller.ReceiveOrderUpdate(result);
                await Clients.Group("allUpdateReceivers").ReceiveOrderUpdate(result);
            } while (!result.Finished);
            await Clients.Caller.Finished(order);
        }

        public override Task OnConnected()
        {
            if (Context.QueryString["group"] == "allUpdates")
                Groups.Add(Context.ConnectionId, "allUpdateReceivers");
            
            return base.OnConnected();
        }
    }
}