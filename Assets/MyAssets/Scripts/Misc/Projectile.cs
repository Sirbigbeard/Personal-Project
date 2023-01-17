using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool active;
    private bool targetChecked = false;
    public int damage = 10;
    private float missileSpeed = 20f;
    private Vector3 targetPosition;
    public Vector3 startPosition;
    public GameObject target;
    public GameObject building;
    public DamageableObject targetScript;
    public Building buildingScript;

    void Awake()
    {
        buildingScript = building.GetComponent<Building>();
        StartCoroutine(TargetCheck());
    }
    //travels towards the given target until the target is destroyed
    void Update()
    {
        if (active)
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, missileSpeed * Time.deltaTime);
                targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                transform.LookAt(targetPosition);
            }
            if (targetChecked && target == null)
            {
                Reset();
            }
        }
    }
    //passes building the xp (replace with building.dealDamage?)
    void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.gameObject.GetInstanceID() == target.GetInstanceID())
            {
                int potentialXP = targetScript.TakeDamage(damage);
                if (targetScript.currentHP <= 0)
                {
                    buildingScript.GainXP(potentialXP);
                    buildingScript.RemoveTarget(other.gameObject);
                }
                Reset();
            }
        }
        catch
        {
            //collision detection in unity can lag, this is to prevent exceptions being thrown when it does so.
        }
    }
    IEnumerator TargetCheck()
    {
        yield return new WaitForSeconds(.001f);
        targetChecked = true;
    }
    private void Reset()
    {
        active = false;
        target = null;
        targetScript = null;
        transform.position = startPosition;
    }
}
