using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFinder : MonoBehaviour
{
    public GameObject building;
    public Building buildingScript;
    void Start()
    {
        buildingScript = building.GetComponent<Building>();
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other == null)
        {
            Debug.Log("bad collision");
        }
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Enemy")
        {
            buildingScript.AddTarget(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            buildingScript.RemoveTarget(other.gameObject);
        }
    }
}
