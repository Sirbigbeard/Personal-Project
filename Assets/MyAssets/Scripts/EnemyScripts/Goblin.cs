using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MelleEnemy
{
    void Awake()
    {
        range = 30;
        attackRange = 3;
        rangedAttackRange = -1;
        speed = 4.2f;
        attackDamage = 1;
        attackCooldownFloat = 2.3f;
        currentHP = 10;
        maxHP = 10;
        Begin();
        itemDrops.Add(slamBook);
        itemDrops.Add(summonImpBook);
        itemDrops.Add(bulwarkBook);
        itemDrops.Add(blinkBook);
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
