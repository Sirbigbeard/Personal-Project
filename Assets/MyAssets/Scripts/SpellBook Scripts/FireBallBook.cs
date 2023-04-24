using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBook : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerScript;
    private static bool used = false;
    public GameObject fireBallButton;
    public SpellBookButton fireBallButtonScript;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        fireBallButton = GameObject.Find("Fire Ball");
        fireBallButtonScript = fireBallButton.GetComponent<SpellBookButton>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            if (!used)
            {
                if (!gameManagerScript.gatheredSpells.Contains(gameManagerScript.fireBallButtonObject))
                {
                    gameManagerScript.gatheredSpells.Add(gameManagerScript.fireBallButtonObject);
                    gameManagerScript.itemDropText.color = new Color(.8784f, .0745f, .0471f, 1);
                    gameManagerScript.itemDropText.text = "Spell Learned: Fireball";
                    gameManagerScript.DropTextResetShell(4);
                    used = true;
                    if(gameManagerScript.activeSpells.Count < gameManagerScript.maxActiveSpells)
                    {
                        fireBallButtonScript.AddSpell();
                    }
                }
            }
            else
            {
                gameManagerScript.itemDropText.color = new Color(.8784f, .0745f, .0471f, 1);
                gameManagerScript.itemDropText.text = "+10 Gold (Spell Known)";
                gameManagerScript.goldDisplay.text = "Gold: " + gameManagerScript.gold;
                gameManagerScript.DropTextResetShell(2.1f);
            }
        }
    }
}
