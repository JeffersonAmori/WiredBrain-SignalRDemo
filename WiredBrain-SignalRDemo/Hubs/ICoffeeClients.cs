using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WiredBrain_SignalRDemo.Models;

namespace WiredBrain_SignalRDemo.Hubs
{
    public interface ICoffeeClients
    {
        Task NewOrder(Order order);
        Task ReceiveOrderUpdate(UpdateInfo info);
        Task Finished(Order order);
    }
}