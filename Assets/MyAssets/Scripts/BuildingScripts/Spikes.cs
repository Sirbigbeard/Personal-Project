using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Ally
{
    //Base script for Spike buildings, spike damage handled in building under spikedamageloop
    void Awake()
    {
        Begin();
        StartCoroutine(TaggingDelay());
    }
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
