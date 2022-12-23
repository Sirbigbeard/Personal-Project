using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Enemy : Building
{
    //this class is parent to RangedAlly and MelleAlly
    private bool iceWaveInternalBool = false;
    void Start()
    {
        
    }
    void Awake()
    {
        experienceReward = 13;
        range = 30;
        attackDamage = 2;
        rangedAttackRange = -1;
        attackRange = 3;
        speed = 5;
        currentHP = 25;
        maxHP = 25;
        attackCooldownFloat = 3.1f;
        Begin();
        StartCoroutine(TaggingDelay());
    }
    void Update()
    {
        BuildingUpdate();
        Move();
    }
    new IEnumerator TaggingDelay()
    {
        yield return new WaitForSeconds(.1f);
        rangeFinderScript.validTargetTags.Add("Building");
        rangeFinderScript.validTargetTags.Add("Player");
        rangeFinderScript.validTargetTags.Add("Ally");
        //attackHitboxScript.validTargetTags.Add("Building");
        //attackHitboxScript.validTargetTags.Add("Player");
        //attackHitboxScript.validTargetTags.Add("Ally");
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "IceWaveHitbox" && iceWaveInternalBool == false)
        {
            TakeDamage(5);
            if(currentHP < 1)
            {
                playerScript.GainXP(experienceReward);
            }
            speed /= 3;
            iceWaveInternalBool = true;
            StartCoroutine(IceWaveInternal());
            StartCoroutine(IceWaveDebuff());
        }
    }
    IEnumerator IceWaveInternal()
    {
        yield return new WaitForSeconds(.02f);
        iceWaveInternalBool = false;
    }
    IEnumerator IceWaveDebuff()
    {
        yield return new WaitForSeconds(5);
        speed *= 3;
        //add visual effect to model here
    }
    protected void Move()
    {
        if (target != null)
        {
            distanceToTarget = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(target.transform.position.x, 0, target.transform.position.z));
            if (target == castle && (distanceToTarget < 8 || distanceToTarget < attackRange))
            {
                if (attackRange < 7.5f)
                {
                    attackRange = 7.5f;
                }
                rangeFinder.SetActive(false);
                targets.Clear();
            }
            if (distanceToTarget > attackRange)
            {
                targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            else if (!attackCooldownActive && !cleavingAttackBool)
            {
                MelleAttack();
            }
            else if (!attackCooldownActive && cleavingAttackBool)
            {
                //CleavingAttack();
            }
            transform.LookAt(targetPosition);
        }
        if (target == null)
        {
            target = castle;
            targetScript = target.GetScript() as DamageableObject;
        }
    }
}
