using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject projectile;
    public GameObject target;
    public GameObject rangeFinder;
    private bool attackReady = true;
    public float attackCooldown = 3f;
    private List<GameObject> targets;
    public Projectile projectileScript;
    void Start()
    {
        targets = new List<GameObject>();
    }
    void Update()
    {
        if (attackReady && targets.Count != 0 && target != null)
        {
            FireProjectile();
        }
    }
    void FireProjectile()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        GameObject projectileFired = Instantiate(projectile, spawnPoint, projectile.transform.rotation) as GameObject;
        projectileScript = projectileFired.GetComponent<Projectile>();
        projectileScript.target = target;
        attackReady = false;
        StartCoroutine(AttackCooldown());
    }
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        attackReady = true;
    }
    public void AddTarget(GameObject newTarget)
    {
        targets.Add(newTarget);
        if (targets.Count == 1)
        {
            target = targets[0];
        }
    }
    //both removes the current target and finds the next closest available target if there is one.
    public void RemoveTarget(GameObject targetToRemove)
    {
        float closestDistance = 9999f;
        targets.Remove(targetToRemove);
        GameObject closestEnemy = null;
        if (targets.Count == 0)
        {
            target = null;
        }
        else foreach (GameObject enemy in targets)
        {
                float distanceVector = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceVector < closestDistance)
                {
                    closestDistance = distanceVector;
                    closestEnemy = enemy;
                }
            }
        if (closestEnemy != null)
        {
            target = closestEnemy;
        }
    }
    public void RemoveTarget()
    {
        float closestDistance = 9999f;
        GameObject closestEnemy = null;
        if (targets.Count == 0)
        {
            target = null;
        }
        foreach (GameObject enemy in targets)
            {
                float distanceVector = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceVector < closestDistance)
                {
                    closestDistance = distanceVector;
                    closestEnemy = enemy;
                }
            }
        if (closestEnemy != null)
        {
            target = closestEnemy;
        }
    }
    public void CountTargets()
    {
        Debug.Log(targets.Count);
    }
}
