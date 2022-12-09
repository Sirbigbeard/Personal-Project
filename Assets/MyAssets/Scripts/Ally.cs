using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Building
{
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
        //StartCoroutine(TaggingDelay());
    }
    void Update()
    {
        //if (currentHP < 1)
        //{
        //    transform.Translate(100000, 100000, 100000);
        //    StartCoroutine(DestroyDelay());
        //}
        Move();
    }
    //IEnumerator TaggingDelay()
    //{
    //    yield return new WaitForSeconds(.1f);
    //    rangeFinderScript.validTargetTags.Add("Enemy");
    //}
    new protected void Move()
    {

        if (target != null)
        {
            distanceToTarget = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(target.transform.position.x, 0, target.transform.position.z));
            if (distanceToTarget > attackRange)
            {
                targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
            else if (!attackCooldownActive)
            {
                Attack();
            }
            transform.LookAt(targetPosition);
        }
        if (target == null)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); //default target should be home base when the z value is below whatever value the lanes begin converging
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
