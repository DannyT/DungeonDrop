using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    Animator anim;


    void Start ()
	{
	    Player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        
    }
		
	void Update () {
        transform.LookAt(Player.transform);
        anim.Play("idle");
	}
}
