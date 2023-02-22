using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class HealthAndDamageCanvas : MonoBehaviour
{
    public float maxHP;
    public float currentHealth;
    private float maxHealthXScale;
    public int incomingDamageCount = 0;
    public GameObject healthBar;
    //private Sprite healthBarImage;
    public GameObject damageUI;
    //public HealthUI2 healthScript;
    public DamageUI2 damageScript;
    private StringBuilder healthBuilder;

    void Awake()
    {
        //healthScript = healthUI.GetComponent<HealthUI2>();
        damageScript = damageUI.GetComponent<DamageUI2>();
        StartCoroutine(HostPassDelay());
        //healthBarImage = healthBar.GetComponent<Sprite>();
    }
    IEnumerator HostPassDelay()
    {
        yield return new WaitForSeconds(.1f);
        maxHealthXScale = healthBar.transform.localScale.x;
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
        currentHealth += healthGained;
        float healthPercent = (currentHealth / maxHP);
        if(healthPercent > 0)
        {
            healthBar.transform.localScale = new Vector3(maxHealthXScale * healthPercent, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }
        else
        {
            healthBar.transform.localScale = new Vector3(0, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }
            //new Vector3(healthPercent * maxHealthXScale, healthBarImage.rectTransform.y);
        if (currentHealth / maxHP > .9)
        {

        }


        /*healthBuilder = new StringBuilder((int)maxHP);
        for (int i = 0; i < currentHealth; i++)
        {
            healthBuilder.Append("_");
        }
        for (float i = currentHealth; i < maxHP; i++)
        {
            healthBuilder.Append("*");
        }
        healthScript.textMesh.text = healthBuilder.ToString();*/
    }
    public void LoseHealth(float damage)
    {
        GainHealth(-damage);
    }
}
