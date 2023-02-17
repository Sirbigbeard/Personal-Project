using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Building
{
    //this class is parent to RangedAlly and MelleAlly
    protected void Move()
    {
        if (target != null)
        {
            distanceToTarget = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(target.transform.position.x, 0, target.transform.position.z));
            //Moves the gameObject towards its target if outside of attack range, otherwise attacks the target
            if (isRanged)
            {
                //ranged attacks handled in BuildingUpdate>FireProjectile in Building
                if (following && distanceToTarget > 2)
                {
                    targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                }
                else if (distanceToTarget > rangedAttackRange)
                {
                    targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                }
            }
            else
            {
                if (distanceToTarget > attackRange)
                {
                    targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                }
                else if (!attackCooldownActive && !cleavingAttackBool && !following)
                {
                    MelleAttack();
                }
                else if (!attackCooldownActive && cleavingAttackBool && !following)
                {
                    //CleavingAttack()
                }
            }
            transform.LookAt(targetPosition);
        }
        if (Input.GetKeyDown("g"))
        {
            if (!following && target == null)
            {
                following = true;
                target = player;
            }
            else if(targets.Count == 0 && following)
            {
                target = null;
                following = false;
            }   
        }
        if (Input.GetKeyDown("h"))
        {
            if (!following && target == null)
            {
                following = true;
                target = castle;
            }
            else if (targets.Count == 0 && following)
            {
                target = null;
                following = false;
            }
        }
        if (playerScript.died && target == null)
        {
            if (!following && target == null)
            {
                following = true;
                target = castle;
            }
            else if (targets.Count == 0 && following)
            {
                target = null;
                following = false;
            }
        }
    }
}
