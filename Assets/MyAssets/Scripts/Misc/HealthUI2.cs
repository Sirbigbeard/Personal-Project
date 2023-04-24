using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI2 : MonoBehaviour
{
    //Handles the health bar text mesh, check HealthAndDamageCanvas script for more
    public GameObject gameManager;
    private GameManager gameManagerScript;
    public static Camera mainCam;
    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }
    void Update()
    {
        mainCam = Camera.main;
        //if (gameManagerScript.roundBegun)
        //{
            transform.rotation = mainCam.transform.rotation;
        //}
    }
}
