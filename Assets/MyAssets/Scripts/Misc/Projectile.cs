using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool active;
    private bool targetChecked = false;
    public float damage = 10;
    public float missileSpeed = 20f;
    private Vector3 targetPosition;
    public Vector3 startPosition;
    public GameObject target;
    public GameObject building;
    public DamageableObject targetScript;
    public Building buildingScript;

    void Awake()
    {
        StartCoroutine(TargetCheck());
    }
    //travels towards the given target until the target is destroyed
    void Update()
    {
        if (active)
        {
            if (target != null)
            {
                targetPosition = new Vector3(target.transform.position.x, target.transform.position.y + 3, target.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, missileSpeed * Time.deltaTime);
                transform.LookAt(targetPosition);
            }
            if (targetChecked && target == null)
            {
                Reset();
            }
        }
        if(building == null)
        {
            StartCoroutine(DestroyDelay());
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
    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    IEnumerator TargetCheck()
    {
        yield return new WaitForSeconds(.01f);
        buildingScript = building.GetComponent<Building>();
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
