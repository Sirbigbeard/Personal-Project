using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldReward : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerScript;
    public int goldReward;
    //private Rigidbody goldRb;
    //soft randomizes gold gained and gives it to the player and relevant text meshes
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        int goldDivisor = Random.Range(2, 7);
        goldReward += goldReward / goldDivisor;
        //goldRb = gameObject.GetComponent<Rigidbody>();
    }
    //void LateUpdate()
    //{
    //    if(transform.position.y < transform.localScale.z)
    //    {
    //        goldRb.useGravity = false;
    //    }
    //}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            gameManagerScript.GainGold(goldReward);
        }
    }
}
