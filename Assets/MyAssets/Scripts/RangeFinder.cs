using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFinder : MonoBehaviour
{
    //This class is used by the range finder object to add or remove targets on the list of its associated "building" game object
    public GameObject building;
    private Building buildingScript;
    public List<string> validTargetTags;
    void Start()
    {
        

    }
    void Awake()
    {
        validTargetTags = new List<string>();
        buildingScript = building.GetComponent<Building>();
    }
    void Update()
    {
        
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
    public void AddValidTarget(string validTarget)
    {
        validTargetTags.Add(validTarget);
    }
}
