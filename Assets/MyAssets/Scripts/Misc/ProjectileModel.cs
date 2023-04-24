using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileModel : MonoBehaviour
{
    public Projectile projectileScript;
    private Vector3 targetY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (projectileScript.active)
        {
            if (projectileScript.target != null)
            {
                targetY = new Vector3(transform.position.x, projectileScript.target.transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetY, projectileScript.missileSpeed * Time.deltaTime);
                //targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                //transform.LookAt(targetY);
            }
        }
    }
}
