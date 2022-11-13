using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBookButton : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerScript;
    private Button button;
    //public ParticleSystem glow;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        if(gameManager == null)
        {
            Debug.Log("win");
        }
        gameManagerScript = gameManager.GetComponent<GameManager>();
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(AddSpell);
    }
    void Update()
    {
        
    }
    void AddSpell()
    {
        if (gameManagerScript.activeSpells.Contains(gameObject))
        {
            gameManagerScript.activeSpells.Remove(gameObject);
            //remove glow effect from card
        }
        else if (gameManagerScript.activeSpells.Count < gameManagerScript.maxActiveSpells)
        {
            gameManagerScript.activeSpells.Add(gameObject);
            //add glow effect to card
        }
        else
        {
            Debug.Log("max spells");
        }
    }
}
