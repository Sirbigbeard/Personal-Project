using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    //this class controls building functionality, and is also parent class to all ally and enemy classes to reuse targeting code.
    public GameObject projectile;
    public GameObject target;
    public GameObject rangeFinder;
    private Projectile projectileScript;
    protected RangeFinder rangeFinderScript;
    private bool attackReady = true;
    public float attackCooldown = 3f;
    protected List<GameObject> targets;
    protected float range = 8;
    private Vector3 targetPosition;
    public bool hitsFlying = false;
    //variable declarations specifically for child classes
    protected float speed;
    protected int health;
    protected float distanceToTarget;

    void Start()
    {
        
    }
    void Update()
    {
        if (attackReady && targets.Count != 0 && target != null)
        {
            FireProjectile();
        }
        if (health < 1)
        {
            transform.Translate(100000, 100000, 100000);
        }
    }
    void Awake()
    {
        Begin();
        health = 25;
        StartCoroutine(TaggingDelay());
    }
    protected void Begin()
    {
        targets = new List<GameObject>();
        rangeFinderScript = rangeFinder.GetComponent<RangeFinder>();
        /*if (!hitsFlying)
        {
            rangeFinder.transform.scale = new Vector3(range, .25f, range);
        }
        else
        {
            rangeFinder.transform.scale = new Vector3(range, 2, range);
        }*/
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
    IEnumerator TaggingDelay()
    {
        yield return new WaitForSeconds(.1f);
        rangeFinderScript.validTargetTags.Add("Enemy");
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
    public void ChangeRange(int change)
    {
        range += change;
    }
    public void SetRange(int newRange)
    {
        range = newRange;
    }

    //methods specifically for children classes
    protected void Move()
    {
        
        if(target != null)
        {
            distanceToTarget = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(target.transform.position.x, 0, target.transform.position.z));
            if(distanceToTarget > 4.5)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                transform.LookAt(targetPosition);
            }
        }
        if(target == null)
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
        }
    }
}
