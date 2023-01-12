using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    void Awake()
    {
        isRanged = true;
        range = 60;
        rangedAttackRange = 18f;
        attackRange = 3;
        speed = 3;
        attackCooldownRanged = 2f;
        currentHP = 25;
        maxHP = 25;
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
        rangeFinderScript.validTargetTags.Add("Building");
        rangeFinderScript.validTargetTags.Add("Player");
        rangeFinderScript.validTargetTags.Add("Ally");
    }
}

