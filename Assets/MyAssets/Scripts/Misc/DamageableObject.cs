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
    protected int experienceReward;

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
        healthAndDamageCanvasScript.damageScript.DamageIncoming(damageDealt);
        if (currentHP < 1)
        {
            if(experienceReward > 0)
            {
                return experienceReward;
            }
        }
        return 0;
    }
}
