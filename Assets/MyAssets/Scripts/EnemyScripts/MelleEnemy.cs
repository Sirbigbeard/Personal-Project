using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleEnemy : Enemy
{
    void Awake()
    {
        range = 30;
        attackRange = 3;
        rangedAttackRange = -1;
        speed = 3;
        attackDamage = 1;
        attackCooldownFloat = 2;
        currentHP = 25;
        maxHP = 25;
        Begin();
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

