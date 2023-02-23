using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    public GameObject gameManager;
    public GameManager gameManagerScript;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }
    void OnMouseEnter()
    {
        if (gameManagerScript.constructing)
        {
            gameManagerScript.currentBuilding.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        }
    }
}
