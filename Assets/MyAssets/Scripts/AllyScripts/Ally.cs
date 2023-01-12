using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Building
{
    //this class is parent to RangedAlly and MelleAlly
    //private bool following = false;
    protected void Move()
    {
        //if (following)
        //{
        //   targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        //   transform.position = Vector3.MoveTowards(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), targetPosition, speed * Time.deltaTime);
        //}//else
        if (target != null)
        {
            distanceToTarget = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(target.transform.position.x, 0, target.transform.position.z));
            if (isRanged)
            {
                if (distanceToTarget > rangedAttackRange)
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
                else if (!attackCooldownActive && !cleavingAttackBool)
                {
                    MelleAttack();
                }
                else if (!attackCooldownActive && cleavingAttackBool)
                {
                    //CleavingAttack();
                }
            }
            transform.LookAt(targetPosition);
        }
        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(parentObject.transform.position.x, 0, parentObject.transform.position.z)) > 0.1)
        {
            transform.position = parentObject.transform.position;
        }
        //if (Input.GetKeyDown("g"))
        //{
        //    if (!following)
         //   {
        //        following = true;
        //        target = player;
         //       targets.Add(targets[0]);
        //        targets[0] = player;
         //   }
         //   else
        //    {
         //       following = false;
         //       RemoveTarget(player);
         //   }   
        //}
    }
}
