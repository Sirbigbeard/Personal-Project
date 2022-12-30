using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonImpBook : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerScript;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            gameManagerScript.gatheredSpells.Add(gameManagerScript.summonImpButtonObject);
        }
    }
}
