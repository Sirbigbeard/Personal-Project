using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpScript : MelleAlly
{
    void Awake()
    {
        sightRange = 30;
        attackRange = 3;
        rangedAttackRange = -1;
        speed = 5;
        attackDamage = 2;
        attackCooldownFloat = 2.6f;
        currentHP = 6;
        maxHP = 6;
        Begin();
        StartCoroutine(TaggingDelay());
    }
    void FixedUpdate()
    {
        Move();
        BuildingUpdate();
        if (!gameManagerScript.roundBegun)
        {
            StartCoroutine(DestroyDelay());
        }
    }
    new IEnumerator TaggingDelay()
    {
        yield return new WaitForSeconds(.1f);
        rangeFinderScript.validTargetTags.Add("Enemy");
    }
}
