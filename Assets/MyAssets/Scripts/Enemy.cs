using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Enemy : Building
{
    void Start()
    {
        
    }
    void Awake()
    {
        range = 15;      
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
    }
    
}
