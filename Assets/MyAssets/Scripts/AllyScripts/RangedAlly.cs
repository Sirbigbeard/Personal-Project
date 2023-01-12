using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAlly : Ally
{
    void Awake()
    {
        isRanged = true;
        range = 50;
        rangedAttackRange = 18f;
        attackRange = -3;
        speed = 4;
        attackCooldownRanged = 2f;
        currentHP = 11;
        maxHP = 11;
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
