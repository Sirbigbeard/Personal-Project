using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageableObject : MonoBehaviour
{
    //this class is the King Daddy of all damageable objects (splits into building and player)
    public int experienceReward;
    protected int bulwarkDefense;
    public float maxHP;
    public float currentHP;
    public float speed;
    public float attackCooldownFloat;
    protected bool bulwarkActive = false;
    public GameObject healthAndDamageCanvas;
    public GameObject attackHitbox;
    public TextMeshProUGUI healthDisplay;
    //public List<string> validTargetTags;
    public HealthAndDamageCanvas healthAndDamageCanvasScript;
    public AttackHitbox attackHitboxScript;

    public int TakeDamage(float damageDealt)
    {
        if (tag == "Player" && bulwarkActive)
        {
            damageDealt -= bulwarkDefense;
            if(damageDealt < 0)
            {
                damageDealt = 0;
            }
        }
        currentHP -= damageDealt;
        if(tag == "Player")
        {
            healthDisplay.text = "Health: " + currentHP + "/" + maxHP;
        }
        healthAndDamageCanvasScript.DamageIncoming(damageDealt);
        if (currentHP <= 0 && experienceReward > 0)
        {
            return experienceReward;
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
        if (tag == "Player")
        {
            healthDisplay.text = "Health: " + currentHP + "/" + maxHP;
        }
    }
    public void FullHeal()
    {
        healthAndDamageCanvasScript.GainHealth(maxHP - currentHP);
        currentHP = maxHP;
        if (tag == "Player")
        {
            healthDisplay.text = "Health: " + currentHP + "/" + maxHP;
        }
    }
}
