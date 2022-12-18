using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Building
{
    private bool following = false;
    void Start()
    {

    }
    void Awake()
    {
        range = 30;
        attackRange = 3;
        speed = 3;
        currentHP = 25;
        maxHP = 25;
        Begin();
        
    }
    void Update()
    {
        
    }
    new IEnumerator TaggingDelay()
    {
        yield return new WaitForSeconds(.1f);
        rangeFinderScript.validTargetTags.Add("Enemy");
    }
    protected void Move()
    {
        if (target != null)
        {
            distanceToTarget = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(target.transform.position.x, 0, target.transform.position.z));
            if (distanceToTarget > attackRange && distanceToTarget > rangedAttackRange)
            {
                targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            else if (!attackCooldownActive && !cleavingAttackBool && !isRanged)
            {
                Attack();
            }
            else if (!attackCooldownActive && cleavingAttackBool)
            {
                //CleavingAttack();
            }
            transform.LookAt(targetPosition);
        }
        //if (following)
        //{
        //   targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        //   transform.position = Vector3.MoveTowards(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), targetPosition, speed * Time.deltaTime);
        //}
        //if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(parentObject.transform.position.x, 0, parentObject.transform.position.z)) > 0.1)
        //{
         //   transform.position = parentObject.transform.position;
        //}
        if (Input.GetKeyDown("g"))
        {
            if (!following)
            {
                following = true;
                target = player;
                targets.Add(targets[0]);
                targets[0] = player;
            }
            else
            {
                following = false;
                RemoveTarget(player);
            }   
            
        }
    }
}
