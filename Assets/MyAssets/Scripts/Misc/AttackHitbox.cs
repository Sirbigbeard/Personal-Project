using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public GameObject host;
    private DamageableObject hostScript;
    public List<string> validTargetTags;
    public List<GameObject> targets;
    void Awake()
    {
        validTargetTags = new List<string>();
        targets = new List<GameObject>();
        hostScript = host.GetScript() as DamageableObject;
    }
    void OnTriggerEnter(Collider other)
    {
        foreach (string validTarget in validTargetTags)
        {
            if (other.gameObject.tag == validTarget)
            {
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
