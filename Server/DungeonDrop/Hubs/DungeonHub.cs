using DungeonDrop.Dtos;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;

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

        public void MovePlayer(PlayerMovement playerMovement)
        {
            Clients.Others.movePlayer(playerMovement);
        }
    }
}