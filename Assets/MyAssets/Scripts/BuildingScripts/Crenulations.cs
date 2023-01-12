using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crenulations : Building
{
    void Awake()
    {
        currentHP = 25;
        maxHP = 25;
        Begin();
    }
    void Update()
    {
        BuildingUpdate();
    }
}
