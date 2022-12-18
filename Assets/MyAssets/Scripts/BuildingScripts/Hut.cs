using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hut : Ally
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        range = 10;
        attackRange = 10;
        currentHP = 25;
        maxHP = 25;
        Begin();
        StartCoroutine(TaggingDelay());
        //projectile = 
    }
    // Update is called once per frame
    void Update()
    {
        BuildingUpdate();
    }
    new protected IEnumerator TaggingDelay()
    {
        yield return new WaitForSeconds(.1f);
        rangeFinderScript.validTargetTags.Add("Enemy");
    }
}