using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public Transform target;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target 
        transform.LookAt(target);
    }
}
