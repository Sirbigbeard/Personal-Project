using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool hit;
    private bool targetChecked = false;
    public GameObject target;
    public DamageableObject targetScript;
    public int damage = 10;
    private float missileSpeed = 5f;
    public GameObject building;
    private Vector3 targetPosition;
    public Building buildingScript;
    void Start()
    {
        buildingScript = building.GetComponent<Building>();
    }
    void Awake()
    {
        StartCoroutine(TargetCheck());
    }
    void Update()
    {
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, missileSpeed * Time.deltaTime);
            targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            transform.LookAt(targetPosition);
        }
        
        if (targetChecked)
        {
            if (target == null)
            {
                Destroy(gameObject);
            }
        }

    }
    void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.GetInstanceID() == target.GetInstanceID())//== target
        {
            targetScript.TakeDamage(damage);
            if (targetScript.currentHP <= 0)
            {
                buildingScript.RemoveTarget(other.gameObject);
            }
            Destroy(gameObject);
        }
    }
    IEnumerator TargetCheck()
    {
        yield return new WaitForSeconds(.001f);

        targetChecked = true;
    }
}
