using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    //Template for any ranged under Enemy class, ranged attacks handled in FireProjectile of building script
    void Awake()
    {
        isRanged = true;
        attackReadyRanged = true;
        Begin();
        StartCoroutine(TaggingDelay());
    }
    void FixedUpdate()
    {
        Move();
        BuildingUpdate();
    }
    new IEnumerator TaggingDelay()
    {
        yield return new WaitForSeconds(.1f);
        rangeFinderScript.validTargetTags.Add("Building");
        rangeFinderScript.validTargetTags.Add("Player");
        rangeFinderScript.validTargetTags.Add("Ally");
    }
}

