using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Enemy : Building
{
    private bool iceWaveInternalBool = false;
    private bool onCastle = false;
    //handles Ice Wave spell damage and effect.
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
    }
    protected void Move()
    {
        if (target != null && !lootPositionChecked && !targetScript.died && !died)
        {
            distanceToTarget = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(target.transform.position.x, 0, target.transform.position.z));
            Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            //if in range to hit castle, hits castle until victory or death.
            if (target == castle && (distanceToTarget < 8 || distanceToTarget <= attackRange) && !onCastle)
            {
                if (attackRange < 7.5f)
                {
                    attackRange = 7.5f;
                }
                rangeFinder.SetActive(false);
                targetScript = castle.GetScript() as DamageableObject;
                onCastle = true;
            }
            //Moves the gameObject towards its target if outside of attack range, otherwise attacks the target
            if (isRanged)
            {
                if (distanceToTarget > rangedAttackRange)
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
                else if (!attackCooldownActive && !cleavingAttackBool)
                {
                    StartCoroutine(AttackDelay());
                    characterAnimation.Play("Attack");
                }
                else if (!attackCooldownActive && cleavingAttackBool)
                {
                    CleavingAttack();
                }
            }
            transform.LookAt(targetPosition);
        }
        if (target == null)
        {
            target = castle;
            targetScript = castle.GetScript() as DamageableObject;
        }
    }
}
