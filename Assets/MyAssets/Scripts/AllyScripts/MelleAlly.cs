using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleAlly : Ally
{
    //Template for any Melle under Ally class
    void Awake()
    {
        range = 40;
        attackRange = 3;
        rangedAttackRange = -1;
        speed = 5;
        attackDamage = 1;
        attackCooldownFloat = 2.3f;
        currentHP = 16;
        maxHP = 16;
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
