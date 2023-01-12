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
            playerScript.gameManagerScript.itemDropText.color = new Color(.0706f, .3176f, .898f, 1);
            playerScript.gameManagerScript.itemDropText.text = "+" + xP + " Experience";
            playerScript.gameManagerScript.DropTextResetShell(2.1f);
        }
    }
}
