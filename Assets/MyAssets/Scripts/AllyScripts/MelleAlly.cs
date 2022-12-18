using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleAlly : Ally
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        range = 30;
        attackRange = 3;
        rangedAttackRange = 2;
        speed = 3;
        attackDamage = 1;
        attackCooldownFloat = 2;
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
    }
    new IEnumerator TaggingDelay()
    {
        yield return new WaitForSeconds(.1f);
        rangeFinderScript.validTargetTags.Add("Enemy");
    }
}
