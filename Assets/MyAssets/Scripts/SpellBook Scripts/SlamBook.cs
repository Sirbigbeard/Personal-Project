using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamBook : MonoBehaviour
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
                if (!gameManagerScript.gatheredSpells.Contains(gameManagerScript.slamButtonObject))
                {
                    gameManagerScript.gatheredSpells.Add(gameManagerScript.slamButtonObject);
                    gameManagerScript.itemDropText.color = new Color(.5009f, .2980f, .0471f, 1);
                    gameManagerScript.itemDropText.text = "Spell Learned: Slam";
                    gameManagerScript.DropTextResetShell(4);
                    used = true;
                }
            }
            else
            {
                gameManagerScript.itemDropText.color = new Color(.5009f, .2980f, .0471f, 1);
                gameManagerScript.itemDropText.text = "+10 Gold (Spell Known)";
                gameManagerScript.goldDisplay.text = "Gold: " + gameManagerScript.gold;
                gameManagerScript.DropTextResetShell(2.1f);
            }
        }
    }
}
