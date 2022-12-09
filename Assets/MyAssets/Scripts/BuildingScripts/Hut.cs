using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hut : Building
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        Begin();
        maxHP = 25;
        currentHP = 25;
        //projectile = 
    }
    // Update is called once per frame
    void Update()
    {
        BuildingUpdate();
    }
}
