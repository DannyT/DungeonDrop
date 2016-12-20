using UnityEngine;
using System.Collections;
using SignalR.Client._20;
using SignalR.Client._20.Hubs;
using System;

public class SocketController : MonoBehaviour {

    public HubConnection connection;
    public IHubProxy proxy;
    public string ServerURL;

    public GameObject enemy;
    MapDrop enemyDto;
    GameObject player;
    float movePlayerEvery = 0.2f;
    PlayerMovement positionCache;

    // Use this for initialization
    void Start () {
        connection = new HubConnection(ServerURL);
        proxy = connection.CreateProxy("DungeonHub");

        // subscribe to event
        proxy.Subscribe("placeEnemy").Data += data =>
        {
            Debug.Log("new enemy drop");
            enemyDto = MapDrop.CreateFromJSON(data[0].ToString());
        };

        proxy.Subscribe("sayHello").Data += data =>
        {
            Debug.Log("Hello!");
        };

        try {
            connection.Start();
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }

        // store instance of Player
        player = GameObject.Find("Player");
        InvokeRepeating("PlayerMove", movePlayerEvery, movePlayerEvery);
    }
	
	// Update is called once per frame
	void Update () {
	    if(enemyDto != null)
        {
            DropEnemy();
        }
    }

    private void DropEnemy()
    {
        Debug.Log("dropping Enemy");
        Instantiate(enemy, new Vector3(enemyDto.x, 0, enemyDto.y), Quaternion.identity);
        enemyDto = null;
    }

    void PlayerMove()
    {
        var playerMovement = new PlayerMovement()
        {
            x = player.transform.position.x,
            y = player.transform.position.z
        };

        if (positionCache == null 
            || (!Equals(playerMovement.x, positionCache.x) 
            || !Equals(playerMovement.y, positionCache.y)))
        {
            proxy.Invoke("MovePlayer", playerMovement).Finished += (sender, e) =>
            {
                Debug.Log("Sent player position: " + playerMovement);
            };

            positionCache = playerMovement;
        }

    }
}
