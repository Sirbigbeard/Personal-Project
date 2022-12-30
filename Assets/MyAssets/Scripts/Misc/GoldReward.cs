using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldReward : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerScript;
    public int goldReward;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        int goldDivisor = Random.Range(2, 7);
        goldReward += goldReward / goldDivisor;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            gameManagerScript.gold += goldReward;
        }
    }
}
