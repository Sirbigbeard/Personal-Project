using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Ally
{
    void Awake()
    {
        attackReadyRanged = false;
        currentHP = 20;
        maxHP = 20;
        range = 9.5f;
        attackDamage = 4;
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
