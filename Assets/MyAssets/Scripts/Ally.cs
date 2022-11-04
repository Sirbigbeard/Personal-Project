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
        range = 15;
        speed = 3;
        health = 25;
        Begin();
        StartCoroutine(TaggingDelay());
    }
    void Update()
    {
        if (health < 1)
        {
            transform.Translate(100000, 100000, 100000);
            StartCoroutine(DestroyDelay());
        }
        Move();
    }
    IEnumerator TaggingDelay()
    {
        yield return new WaitForSeconds(.1f);
        rangeFinderScript.validTargetTags.Add("Enemy");
    }
}
