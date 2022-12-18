using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAlly : Ally
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
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
    // Update is called once per frame
    void Update()
    {
        HealthCheck();
        Move();
        BuildingUpdate();
    }
    new IEnumerator TaggingDelay()
    {
        yield return new WaitForSeconds(.1f);
        rangeFinderScript.validTargetTags.Add("Enemy");
    }
}