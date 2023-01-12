using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamageCanvas : MonoBehaviour
{
    public GameObject healthUI;
    public GameObject damageUI;
    public float maxHP;
    public HealthUI2 healthScript;
    public DamageUI2 damageScript;
    public int incomingDamageCount = 0;
    public float currentHealth;

    void Awake()
    {
        healthScript = healthUI.GetComponent<HealthUI2>();
        damageScript = damageUI.GetComponent<DamageUI2>();
        StartCoroutine(HostPassDelay());
    }
    IEnumerator HostPassDelay()
    {
        yield return new WaitForSeconds(.1f);
        GainHealth(maxHP);
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
    public void GainHealth(float healthGained)
    {
        healthScript.textMesh.text = "";
        currentHealth += healthGained;
        for (int i = 0; i < currentHealth; i++)
        {
            healthScript.textMesh.text += "_";
        }
        for (float i = currentHealth; i < maxHP; i++)
        {
            healthScript.textMesh.text += "*";
        }
    }
    public void LoseHealth(float damage)
    {
        GainHealth(-damage);
    }
}
