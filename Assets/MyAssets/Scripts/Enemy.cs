using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Enemy : Building
{
    private bool iceWaveInternalBool = false;
    void Start()
    {
        
    }
    void Awake()
    {
        range = 30;
        attackDamage = 2;
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
        if (currentHP < 1)
        {
            transform.Translate(100000, 100000, 100000);
            StartCoroutine(DestroyDelay());
        }
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
    new protected void Move()
    {
        if (target != null)
        {
            distanceToTarget = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(target.transform.position.x, 0, target.transform.position.z));
            if (target == castle && (distanceToTarget < 8 || distanceToTarget < attackRange))
            {
                if (attackRange < 7.1f)
                {
                    attackRange = 7.1f;
                }
                rangeFinder.SetActive(false);
                targets.Clear();
            }
            if (distanceToTarget > attackRange)
            {
                targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
            else if (!attackCooldownActive && !cleavingAttackBool)
            {
                Attack();
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
