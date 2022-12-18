using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBookButton : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerScript;
    private Button button;
    private Image image;
    //public ParticleSystem glow;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(AddSpell);
        image = GetComponent<Image>();
    }
    void Update()
    {
        
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
            Debug.Log("max spells");
        }
    }
}
