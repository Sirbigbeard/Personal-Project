using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageableObject : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    protected float speed;
    public GameObject healthAndDamageCanvas;
    protected float attackCooldownFloat;
    public HealthAndDamageCanvas healthAndDamageCanvasScript;
    public List<string> validTargetTags;
    public GameObject attackHitbox;
    public AttackHitbox attackHitboxScript;
    public TextMeshProUGUI healthDisplay;
    public int experienceReward;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public int TakeDamage(float damageDealt)
    {
        currentHP -= damageDealt;
        if(tag == "Player")
        {
            healthDisplay.text = "Health: " + currentHP + "/" + maxHP;
        }
        healthAndDamageCanvasScript.DamageIncoming(damageDealt);
        if (currentHP < 1)
        {
            if(experienceReward > 0)
            {
                return experienceReward;
            }
        }
        return 0;
    }
    public void Heal(float health)
    {
        currentHP += health;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
            healthAndDamageCanvasScript.GainHealth(maxHP - currentHP);
        }
        else
        {
            healthAndDamageCanvasScript.GainHealth(health);
        }
    }
    public void FullHeal()
    {
        currentHP = maxHP;
        healthAndDamageCanvasScript.GainHealth(maxHP - currentHP);
    }
}
