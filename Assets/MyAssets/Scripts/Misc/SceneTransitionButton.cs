using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransitionButton : MonoBehaviour
{
    private Button button;
    public int sceneNumber;
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ChangeScene);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
