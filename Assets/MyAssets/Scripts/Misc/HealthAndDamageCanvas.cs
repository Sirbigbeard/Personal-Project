using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class HealthAndDamageCanvas : MonoBehaviour
{
    public float maxHP;
    public float currentHealth;
    public int incomingDamageCount = 0;
    public GameObject healthUI;
    public GameObject damageUI;
    public HealthUI2 healthScript;
    public DamageUI2 damageScript;
    private StringBuilder healthBuilder;

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
    //damage ui
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
    //health ui
    public void GainHealth(float healthGained)
    {
        healthBuilder = new StringBuilder((int)maxHP);
        currentHealth += healthGained;
        for (int i = 0; i < currentHealth; i++)
        {
            healthBuilder.Append("_");
            //healthScript.textMesh.text += "_";
        }
        for (float i = currentHealth; i < maxHP; i++)
        {
            healthBuilder.Append("*");
            //healthScript.textMesh.text += "*";
        }
        healthScript.textMesh.text = healthBuilder.ToString();
    }
    public void LoseHealth(float damage)
    {
        GainHealth(-damage);
    }
}
