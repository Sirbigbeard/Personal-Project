using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamageCanvas : MonoBehaviour
{
    public GameObject health;
    public GameObject damage;
    public Vector3 offset;
    public HealthUI healthScript;
    public DamageUI damageScript;
    public GameObject host;

    void Start()
    {
        
    }
    void Awake()
    {
        healthScript = health.GetComponent<HealthUI>();
        damageScript = damage.GetComponent<DamageUI>();
        StartCoroutine(HostPassDelay());
    }
    void Update()
    {
        
    }
    IEnumerator HostPassDelay()
    {
        yield return new WaitForSeconds(.1f);
        healthScript.offset = offset;
        damageScript.offset = offset;//plus .4 to y value
        healthScript.host = host.transform;
        damageScript.host = host.transform;
    }
}
