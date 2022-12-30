using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPReward : MonoBehaviour
{
    public GameObject player;
    private Player playerScript;
    public int xP;
    void Start()
    {
        player = GameObject.Find("Character");
        playerScript = player.GetComponent<Player>();
        int xPDivisor = Random.Range(2, 7);
        xP += xP / xPDivisor;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            playerScript.GainXP(xP);
        }
    }
}
