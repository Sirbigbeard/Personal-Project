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
        Transform parentTransform = transform.parent;
        while(parentTransform.transform.parent != null)
        {
            parentTransform = parentTransform.transform.parent;
        }
        if(parentTransform.tag == "Enemy")
        {
            validTargetTags.Add("Ally");
            validTargetTags.Add("Building");
            validTargetTags.Add("Player");
        }
        else if(parentTransform.tag == "Player" || parentTransform.tag == "Ally" || parentTransform.tag == "Building")
        {
            validTargetTags.Add("Enemy");
        }
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
