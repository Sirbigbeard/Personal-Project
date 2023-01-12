using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chieftan : MelleEnemy
{
    void Awake()
    {
        range = 30;
        attackRange = 3;
        rangedAttackRange = -1;
        speed = 7.5f;
        attackDamage = 2;
        attackCooldownFloat = 2.5f;
        currentHP = 25;
        maxHP = 25;
        experienceReward = 8;
        Begin();
        itemDrops.Add(fireBallBook);
        itemDrops.Add(blinkBook);
        itemDrops.Add(iceWaveBook);
        itemDrops.Add(summonImpBook);
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