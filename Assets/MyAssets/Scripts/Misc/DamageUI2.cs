using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageUI2 : MonoBehaviour
{
    //Handles the incoming damage text mesh, check HealthAndDamageCanvas script for more
    public GameObject gameManager;
    private GameManager gameManagerScript;
    public static Camera mainCam;
    public TextMeshPro textMesh;
    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        textMesh = GetComponent<TMPro.TextMeshPro>();
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

