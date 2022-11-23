using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public GameObject building;
    //private GameObject attackTarget;
    private Building buildingScript;
    public List<string> validTargetTags;
    public List<GameObject> targets;
    void Start()
    {

    }
    void Awake()
    {
        validTargetTags = new List<string>();
        targets = new List<GameObject>();
        buildingScript = building.GetComponent<Building>();
    }
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("colission");
        foreach (string validTarget in validTargetTags)
        {
            if (other.gameObject.tag == validTarget)
            {
                Debug.Log("nig");
                targets.Add(other.gameObject);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (targets.Contains(other.gameObject))
        {
            targets.Remove(other.gameObject);
        }
    }
}
