using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulwarkBook : MonoBehaviour
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
                if (!gameManagerScript.gatheredSpells.Contains(gameManagerScript.bulwarkButtonObject))
                {
                    gameManagerScript.gatheredSpells.Add(gameManagerScript.bulwarkButtonObject);
                    gameManagerScript.itemDropText.color = new Color(.7176f, .7529f, .9647f, 1);
                    gameManagerScript.itemDropText.text = "Spell Learned: Bulwark";
                    gameManagerScript.DropTextResetShell(4);
                    used = true;
                }
            }
            else
            {
                gameManagerScript.itemDropText.color = new Color(.7176f, .7529f, .9647f, 1);
                gameManagerScript.itemDropText.text = "+10 Gold (Spell Known)";
                gameManagerScript.goldDisplay.text = "Gold: " + gameManagerScript.gold;
                gameManagerScript.DropTextResetShell(2.1f);
            }
        }
    }
}
