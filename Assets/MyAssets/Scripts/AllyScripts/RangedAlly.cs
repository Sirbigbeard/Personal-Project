using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAlly : Ally
{
    //Template for any ranged under Ally class, ranged attacks handled in FireProjectile of building script
    void Awake()
    {
        isRanged = true;
        attackReadyRanged = true;
        Begin();
        StartCoroutine(TaggingDelay());
    }
    void Update()
    {
        Move();
        BuildingUpdate();
    }
    new IEnumerator TaggingDelay()
    {
        yield return new WaitForSeconds(.1f);
        rangeFinderScript.validTargetTags.Add("Enemy");
    }
}
