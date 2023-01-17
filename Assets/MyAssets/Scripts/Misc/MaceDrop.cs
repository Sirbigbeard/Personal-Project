using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceDrop : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerScript;
    private Player playerScript;
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
            playerScript = other.gameObject.GetComponent<Player>();
            if (!used)
            {
                gameManagerScript.itemDropText.color = new Color(.3f, .8275f, .9176f, 1);
                gameManagerScript.itemDropText.text = "Weapon Equipped: Mace";
                gameManagerScript.DropTextResetShell(4);
                playerScript.GainMace();
                used = true;
            }
            else
            {
                gameManagerScript.itemDropText.color = new Color(.1333f, .8275f, .9176f, 1);
                gameManagerScript.itemDropText.text = "+10 Gold (Item Owned)";
                gameManagerScript.goldDisplay.text = "Gold: " + gameManagerScript.gold;
                gameManagerScript.DropTextResetShell(2.1f);
            }
        }
    }
}
