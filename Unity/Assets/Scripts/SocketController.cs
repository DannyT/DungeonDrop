using UnityEngine;
using System.Collections;
using SignalR.Client._20;
using SignalR.Client._20.Hubs;

public class SocketController : MonoBehaviour {

    public HubConnection connection;
    public IHubProxy proxy;
    public string ServerURL;

    public GameObject enemy;
    MapDrop enemyDto;

    // Use this for initialization
    void Start () {
        connection = new HubConnection(ServerURL);
        proxy = connection.CreateProxy("DungeonHub");

        // subscribe to event
        proxy.Subscribe("placeEnemy").Data += data =>
        {
            Debug.Log("new enemy drop");
            enemyDto = JsonUtility.FromJson<MapDrop>(data[0].ToString());
        };

        proxy.Subscribe("sayHello").Data += data =>
        {
            Debug.Log("Hello!");
        };

        connection.Start();
    }
	
	// Update is called once per frame
	void Update () {
	    if(enemyDto != null)
        {
            Debug.Log("dropping Enemy");
            Instantiate(enemy, new Vector3(enemyDto.x, 2, enemyDto.y), Quaternion.identity);
            enemyDto = null;
        }
	}
}
