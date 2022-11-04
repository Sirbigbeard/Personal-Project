using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBook : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            gameManagerScript.gatheredSpells.Add(gameManagerScript.fireBallButtonObject);
        }
    }
}
