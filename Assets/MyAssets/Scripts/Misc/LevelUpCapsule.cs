using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpCapsule : MonoBehaviour
{
    public GameObject player;
    public Player playerScript;
    void Start()
    {
        player = GameObject.Find("Character");
        playerScript = player.GetComponent<Player>();
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            playerScript.GainXP(10);
        }
    }
}
