using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //figure out how to properly angle the projectile towards its target
    //figure out enemy spawning and PATHING(big proj)

  
    public bool timer = true;
    private Vector3 spawnPoint = new Vector3(10f, 2.4f, 10f);
    public GameObject enemy;
    public GameObject building;
    void Start()
    {
        GameObject buildingCreated = Instantiate(building, new Vector3(10, 2, -12), building.transform.rotation) as GameObject;
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
        spawnPoint = new Vector3(Random.Range(-30, 30), 2.4f, Random.Range(-30, 30));
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
        spawnPoint = new Vector3(Random.Range(-30, 30), 2.4f, Random.Range(-30, 30));
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
        spawnPoint = new Vector3(Random.Range(-30, 30), 2.4f, Random.Range(-30, 30));
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
        spawnPoint = new Vector3(Random.Range(-30, 30), 2.4f, Random.Range(-30, 30));
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
        spawnPoint = new Vector3(Random.Range(-30, 30), 2.4f, Random.Range(-30, 30));
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
    }
    void Update()
    {

    }
}
