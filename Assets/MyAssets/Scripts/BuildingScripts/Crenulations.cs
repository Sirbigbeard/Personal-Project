using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crenulations : Building
{
    //Base Script for buildings that only absorb damage
    void Awake()
    {
        Begin();
    }
    void Update()
    {
        BuildingUpdate();
    }
}
