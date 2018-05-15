using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ProgressBarTest.Hubs
{
    public class MyNewHub : Hub
    {
        public static void Send()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyNewHub>();
            context.Clients.All.displayStatus();
        }
    }
}