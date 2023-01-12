using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFinder : MonoBehaviour
{
    //This class is used by the range finder object to add or remove targets on the list of its associated "building" game object
    public GameObject building;
    private Building buildingScript;
    public List<string> validTargetTags;
    void Awake()
    {
        validTargetTags = new List<string>();
        buildingScript = building.GetScript() as Building;
    }
    void OnTriggerEnter(Collider other)
    {
        if (validTargetTags.Count != 0)
        {
            foreach (string validTarget in validTargetTags)
            {
                if (other.gameObject.tag == validTarget)
                {
                    buildingScript.AddTarget(other.gameObject);
                    StartCoroutine(SpikeDamageDelay());
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (validTargetTags.Count != 0)
        {
            foreach (string validTarget in validTargetTags)
            {
                if (other.gameObject.tag == validTarget)
                {
                    buildingScript.RemoveTarget(other.gameObject);
                }
            }
        }
    }
    public IEnumerator SpikeDamageDelay()
    {
        yield return new WaitForSeconds(.1f);
        if (building.name == "Spikes(Clone)")
        {
            buildingScript.SpikeDamageLoop(buildingScript.targetScript);
        }
    }
}
