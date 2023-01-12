using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    public GameObject gameStartButtonObject;
    private Button gameStartButton;
    void Start()
    {
        gameStartButton = gameStartButtonObject.GetComponent<Button>();
        gameStartButton.onClick.AddListener(BeginGame);
    }
    public void BeginGame()
    {
        SceneManager.LoadScene(0);
    }
}
