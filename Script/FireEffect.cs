using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    public GameObject FireBoomEffect;
    public GameObject intanFire;
    GameObject player;
    PlayerMove playerMove;
    void Start()
    { 
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor" || other.tag == "Player")
        {
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[43]);
            Instantiate(FireBoomEffect, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
