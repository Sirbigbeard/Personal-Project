using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpScript : Ally
{
    void Awake()
    {
        range = 30;
        attackRange = 3;
        rangedAttackRange = -1;
        speed = 5;
        attackDamage = 1;
        attackCooldownFloat = 2;
        currentHP = 8;
        maxHP = 8;
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
