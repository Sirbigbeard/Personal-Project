using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkBook : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerScript;
    private static bool used = false;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            if (!used)
            {
                if (!gameManagerScript.gatheredSpells.Contains(gameManagerScript.blinkButtonObject))
                {
                    gameManagerScript.gatheredSpells.Add(gameManagerScript.blinkButtonObject);
                    gameManagerScript.itemDropText.color = new Color(.1333f, .8275f, .9176f, 1);
                    gameManagerScript.itemDropText.text = "Spell Learned: Blink";
                    gameManagerScript.DropTextResetShell(4);
                    used = true;
                }
            }
            else
            {
                gameManagerScript.itemDropText.color = new Color(.1333f, .8275f, .9176f, 1);
                gameManagerScript.itemDropText.text = "+10 Gold (Spell Known)";
                gameManagerScript.goldDisplay.text = "Gold: " + gameManagerScript.gold;
                gameManagerScript.DropTextResetShell(2.1f);
            }
        }
    }
}
