using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Building
{
    //this class is parent to RangedAlly and MelleAlly
    protected void Move()
    {
        if (target != null && !targetScript.died && !died)
        {
            distanceToTarget = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(target.transform.position.x, 0, target.transform.position.z));
            targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            //Moves the gameObject towards its target if outside of attack range, otherwise attacks the target
            if (isRanged)
            {
                //ranged attacks handled in BuildingUpdate>FireProjectile in Building
                if (following)
                {
                    if(distanceToTarget > 2)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                        if (!characterAnimation.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                        {
                            characterAnimation.Play("Walk");
                        }
                    }
                    else
                    {
                        characterAnimation.Play("Idle");
                    }
                }
                else if (distanceToTarget > rangedAttackRange)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                    if (!characterAnimation.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    {
                        characterAnimation.Play("Walk");
                    }
                }
            }
            else
            {
                if (distanceToTarget > attackRange)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                    if (!characterAnimation.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    {
                        characterAnimation.Play("Walk");
                    }
                }
                else if (!attackCooldownActive && !cleavingAttackBool && !following)
                {
                    StartCoroutine(AttackDelay());
                    characterAnimation.Play("Attack");
                }
                else if (!attackCooldownActive && cleavingAttackBool && !following)
                {
                    //CleavingAttack()
                }
                else if(!characterAnimation.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    characterAnimation.Play("Idle");
                }
            }
            transform.LookAt(targetPosition);
        }
        if (playerScript.died && target == null)
        {
            if (!following && target == null)
            {
                following = true;
                target = castle;
                targetScript = castle.GetScript() as DamageableObject;
            }
            else if (targets.Count == 0 && following)
            {
                target = null;
                following = false;
            }
        }
        if(target == null)
        {
            characterAnimation.Play("Idle");
        }
    }
    public void FollowFix()
    {
        if (Input.GetKeyDown("g"))
        {
            Debug.Log("g");
            if (!following && target == null)
            {
                following = true;
                target = player;
                targetScript = playerScript;
            }
            else if (targets.Count == 0 && following)
            {
                target = null;
                following = false;
                targetScript = null;
                characterAnimation.Play("Idle");
            }
            else if (following)
            {
                following = false;
            }
        }
        if (Input.GetKeyDown("h"))
        {
            Debug.Log("h");
            if (!following && target == null)
            {
                following = true;
                target = castle;
                targetScript = playerScript;
            }
            else if (targets.Count == 0 && following)
            {
                target = null;
                targetScript = null;
                following = false;
                characterAnimation.Play("Idle");
            }
        }
    }   
}
