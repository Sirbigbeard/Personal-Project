using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamageCanvas : MonoBehaviour
{
    public GameObject healthUI;
    public GameObject damageUI;
    public Vector3 offset;
    public int health;
    public HealthUI healthScript;
    public DamageUI damageScript;
    public GameObject host;
    public int incomingDamageCount = 0;
    public float currentHealth;

    void Start()
    {
        
    }
    void Awake()
    {
        healthScript = healthUI.GetComponent<HealthUI>();
        damageScript = damageUI.GetComponent<DamageUI>();
        StartCoroutine(HostPassDelay());
    }
    void Update()
    {

    }
    IEnumerator HostPassDelay()
    {
        yield return new WaitForSeconds(.1f);
        healthScript.offset = offset;
        damageScript.offset = new Vector3(offset.x, offset.y + .4f, offset.z);
        healthScript.host = host.transform;
        damageScript.host = host.transform;
        if(host.tag == "Ally")
        {
            //change color to light green
        }
        if (host.tag == "Building")
        {
            //change color to dark green
        }
        if (host.tag == "Player")
        {
            //change color to blue
        }
        if (host.tag == "Enemy")
        {
            //change color to red
        }
        GainHealth(health);
    }
    public void DamageIncoming(float damage)
    {
        damageScript.textMesh.text = "-" + damage;
        incomingDamageCount++;
        LoseHealth(damage);
        StartCoroutine(DamageFade());
    }
    IEnumerator DamageFade()
    {
        yield return new WaitForSeconds(1);
        incomingDamageCount--;
        if (incomingDamageCount == 0)
        {
            damageScript.textMesh.text = "";
        }
    }
    public void GainHealth(float health)
    {
        for (int i = 0; i < health; i++)
        {
            //Debug.Log(healthScript.textMesh.text);
            healthScript.textMesh.text += "_";
        }
        currentHealth += health;
    }
    public void LoseHealth(float damage)
    {
        currentHealth -= damage;
        healthScript.textMesh.text = "";
        for (int i = 0; i < currentHealth; i++)
        {
            healthScript.textMesh.text += "_";
        }
    }
}
