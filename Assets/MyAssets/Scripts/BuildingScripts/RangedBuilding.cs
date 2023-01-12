using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBuilding : Ally
{
    void Awake()
    {
        range = 10;
        attackRange = 10;
        currentHP = 18;
        maxHP = 18;
        attackCooldownRanged = 3.3f;
        Begin();
        StartCoroutine(TaggingDelay());
    }
    void Update()
    {
        BuildingUpdate();
    }
    new protected IEnumerator TaggingDelay()
    {
        yield return new WaitForSeconds(.1f);
        rangeFinderScript.validTargetTags.Add("Enemy");
    }
}
