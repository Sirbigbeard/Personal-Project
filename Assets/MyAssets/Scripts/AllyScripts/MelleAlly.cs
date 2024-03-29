using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleAlly : Ally
{
    //Template for any melle under Ally class
    void Awake()
    {
        Begin();
        StartCoroutine(TaggingDelay());
    }
    void FixedUpdate()
    {
        Move();
        BuildingUpdate();
    }
    void Update()
    {
        FollowFix();
    }
    new IEnumerator TaggingDelay()
    {
        yield return new WaitForSeconds(.1f);
        rangeFinderScript.validTargetTags.Add("Enemy");
    }
}
