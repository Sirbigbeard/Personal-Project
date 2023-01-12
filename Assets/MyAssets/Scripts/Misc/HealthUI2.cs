using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI2 : MonoBehaviour
{
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
        if (gameManagerScript.roundBegun)
        {
            //transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position);
            transform.rotation = mainCam.transform.rotation;
        }
    }
}
