using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBuilding : Ally
{
    //Base script for ranged buildings, ranged attacks handled in FireProjectile of building script
    void Awake()
    {
        isRanged = true;
        attackReadyRanged = true;
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
