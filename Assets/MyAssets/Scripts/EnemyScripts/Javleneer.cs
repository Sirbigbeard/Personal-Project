using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Javleneer : RangedEnemy
{
    void Awake()
    {
        isRanged = true;
        range = 30;
        rangedAttackRange = 18f;
        speed = 5;
        attackCooldownRanged = 4.2f;
        currentHP = 8;
        maxHP = 8;
        experienceReward = 5;
        Begin();
        itemDrops.Add(smallGoldReward);
        itemDrops.Add(mediumGoldReward);
        itemDrops.Add(smallXPReward);
        itemDrops.Add(bulwarkBook);
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
