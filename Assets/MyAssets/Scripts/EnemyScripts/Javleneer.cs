using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Javleneer : RangedEnemy
{
    void Awake()
    {
        isRanged = true;
        range = 60;
        rangedAttackRange = 18f;
        attackRange = -3;
        speed = 3;
        attackCooldownRanged = 4.5f;
        currentHP = 8;
        maxHP = 8;
        Begin();
        itemDrops.Add(fireBallBook);
        itemDrops.Add(fireBallBook);
        itemDrops.Add(fireBallBook);
        itemDrops.Add(fireBallBook);
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
        rangeFinderScript.validTargetTags.Add("Building");
        rangeFinderScript.validTargetTags.Add("Player");
        rangeFinderScript.validTargetTags.Add("Ally");
    }
}
