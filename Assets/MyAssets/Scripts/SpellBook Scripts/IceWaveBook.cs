using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWaveBook : MonoBehaviour
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
                if (!gameManagerScript.gatheredSpells.Contains(gameManagerScript.iceWaveButtonObject))
                {
                    gameManagerScript.gatheredSpells.Add(gameManagerScript.iceWaveButtonObject);
                    gameManagerScript.itemDropText.color = new Color(0, .3608f, .7843f, 1);
                    gameManagerScript.itemDropText.text = "Spell Learned: IceWave";
                    gameManagerScript.DropTextResetShell(4);
                    used = true;
                }
            }
            else
            {
                gameManagerScript.itemDropText.color = new Color(0, .3608f, .7843f, 1);
                gameManagerScript.itemDropText.text = "+10 Gold (Spell Known)";
                gameManagerScript.goldDisplay.text = "Gold: " + gameManagerScript.gold;
                gameManagerScript.DropTextResetShell(2.1f);
            }
        }
    }
}
