using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellBookButton : MonoBehaviour
{
    public TextMeshProUGUI spellTooltip;
    public GameObject gameManager;
    private GameManager gameManagerScript;
    private Button button;
    private Image image;
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(AddSpell);
        image = GetComponent<Image>();
    }
    void AddSpell()
    {
        if (gameManagerScript.activeSpells.Contains(gameObject))
        {
            gameManagerScript.activeSpells.Remove(gameObject);
            image.color = Color.white;
        }
        else if (gameManagerScript.activeSpells.Count < gameManagerScript.maxActiveSpells)
        {
            gameManagerScript.activeSpells.Add(gameObject);
            image.color = Color.red;
        }
        else
        {
            spellTooltip.text = "Maximum active spells, level up to increase.";
        }
    }
    public void DisplayTooltip()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(gameManagerScript.mainCanvas.transform as RectTransform, transform.position, gameManagerScript.mainCanvas.worldCamera, out pos);
        spellTooltip.transform.position = new Vector2(gameManagerScript.mainCanvas.transform.TransformPoint(pos).x, gameManagerScript.mainCanvas.transform.TransformPoint(pos).y - 40);
        if (name == "Fire Ball")
        {
            spellTooltip.text = "Send a fireball careening forth to plunder an enemy's bung for 6 damage.";
        }
        if(name == "Ice Wave")
        {
            spellTooltip.text = "Spew a wave of ice which deals 5 damage and slows the enemies before you.";
        }
        if(name == "Blink")
        {
            spellTooltip.text = "Slip through the fourth dimension to appear 10 meters in your look direction.";
        }
        if(name == "Bulwark")
        {
            spellTooltip.text = "Harden your skin, reducing the damage you take by 1.";
        }
        if(name == "Summon Imp")
        {
            spellTooltip.text = "Summon an Imp to fight for you. Imp deals minor melle damage.";
        }
        if(name == "Slam")
        {
            spellTooltip.text = "Attack, dealing double damage (does not set attack on cooldown).";
        }
    }
    public void HideTooltip()
    {
        spellTooltip.text = "";
        spellTooltip.transform.position = new Vector2(0, 0);
    }
}
