using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class BuildingButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject statBackground;
    public GameObject statTextObject;
    public GameObject building;
    private Building buildingScript;
    private TextMeshProUGUI statText;
    public GameObject nameTextObject;
    private TextMeshProUGUI nameText;
    private Image statBackgroundImage;
    void Start()
    {
        buildingScript = building.GetScript() as Building;
        statText = statTextObject.GetComponent<TextMeshProUGUI>();
        nameText = nameTextObject.GetComponent<TextMeshProUGUI>();
        statBackgroundImage = statBackground.GetComponent<Image>();
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        statBackground.SetActive(true);
        nameText.text = buildingScript.trueName;
        if(building.name == "Spikes")
        {
            statText.text = "Health: " + buildingScript.maxHP + "              Cost: " + buildingScript.cost + "\n\nDamage: " + buildingScript.attackDamage + "\n\nSpike Damage Interval: " + buildingScript.spikeDamageInterval;
        }
        else if (buildingScript.isRanged)
        {
            statText.text = "Health: " + buildingScript.maxHP + "              Cost: " + buildingScript.cost + "\n\nDamage: " + buildingScript.attackDamage + "\n\nAttack Cooldown: " + buildingScript.attackCooldownRanged;
            if(buildingScript.sightRange != buildingScript.rangedAttackRange && buildingScript.sightRange != 0)
            {
                statText.text = statText.text + "\n\nSight Range: " + buildingScript.sightRange;
            }
            statText.text = statText.text + "\n\nAttack Range: " + buildingScript.rangedAttackRange;
        }
        else
        {
            statText.text = "Health: " + buildingScript.maxHP + "              Cost: " + buildingScript.cost + "\n\nDamage: " + buildingScript.attackDamage + "\n\nAttack Cooldown: " + buildingScript.attackCooldownFloat + "\n\nSight Range: " + buildingScript.sightRange + "\n\nAttack Range: "
            + buildingScript.attackRange;
        }
        if(building.tag != "Building")
        {
            statText.text = statText.text + "\n\nMovement Speed: " + buildingScript.speed;
        }
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        statBackground.SetActive(false);
    }
}
