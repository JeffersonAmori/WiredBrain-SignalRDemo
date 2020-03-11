using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WiredBrain_SignalRDemo.Hubs;
using WiredBrain_SignalRDemo.Models;

namespace WiredBrain_SignalRDemo.Controllers
{
    public class CoffeeController : ApiController
    {
        private static int OrderId;

        [HttpPost]
        public int OrderCoffee(Order order)
        {
            //var hubContext = GlobalHost.ConnectionManager.GetHubContext<CoffeeHub>();
            //hubContext.Clients.All.NewOrder(order);
            OrderId++;
            return OrderId;
        }
    }
}