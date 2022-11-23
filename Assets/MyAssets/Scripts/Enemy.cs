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
        attackRange = 3;
        speed = 3;
        currentHP = 25;
        maxHP = 25;
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
    IEnumerator TaggingDelay()
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
            Debug.Log("icewave hit");
            currentHP -= 5;
            speed /= 2;
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
        speed *= 2;
        //add visual effect to model here
    }
}
