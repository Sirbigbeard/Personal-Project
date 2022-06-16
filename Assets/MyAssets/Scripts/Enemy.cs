using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Enemy : Building
{
    private Vector3 spawnPoint = new Vector3(15f, 2.4f, 15f);
    void Start()
    {
        
    }
    void Awake()
    {
        range = 15;
        Begin();
        speed = 3;
        health = 25;
        StartCoroutine(TaggingDelay());
    }
    void Update()
    {
        if (health < 1)
        {
            transform.Translate(100000, 100000, 100000);
        }
        Move();
    }
    public void ModifyHealth(int change)
    {
        health += change;
    }
    public int GetHealth()
    {
        return health;
    }
    IEnumerator TaggingDelay()
    {
        yield return new WaitForSeconds(.1f);
        rangeFinderScript.validTargetTags.Add("Building");
    }
}
