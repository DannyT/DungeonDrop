using DungeonDrop.Dtos;
using Microsoft.AspNet.SignalR;

namespace DungeonDrop.Hubs
{
    public class DungeonHub : Hub
    {
        public void DropEnemy(MapDrop mapDrop)
        {
            Clients.Others.placeEnemy(mapDrop);
        }

        public void Hello()
        {
            Clients.Others.sayHello();
        }
    }
}