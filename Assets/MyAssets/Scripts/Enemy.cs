using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject building;
    public int health = 25;
    public int speed = 2;
    private Vector3 spawnPoint = new Vector3(15f, 2.4f, 15f);
    void Start()
    {

    }
    void Update()
    {
        if(health < 1)
        {
            transform.Translate(100000, 100000, 100000);
        }
        if(building != null)
        {
            Move();
        }
    }
    public void ModifyHealth(int change)
    {
        health += change;
    }
    public int GetHealth()
    {
        return health;
    }
    void Move()
    {
        transform.Translate((building.transform.position - transform.position).normalized * Time.deltaTime * speed);
    }
}
