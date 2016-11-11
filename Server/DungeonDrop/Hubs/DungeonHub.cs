using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace DungeonDrop.Hubs
{
    public class DungeonHub : Hub
    {
        public void DropEnemy(string type, int x, int y)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("type: {0} x: {1} y:{2}", type, x, y));
            Clients.Others.dropEnemy(type, x, y);
        }
    }
}