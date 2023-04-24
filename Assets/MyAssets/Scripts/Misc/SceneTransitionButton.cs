using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneTransitionButton : MonoBehaviour
{
    public int preClicks;
    private Button button;
    public int sceneNumber;
    public GameObject textObject;
    private TextMeshProUGUI buttonText;
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ChangeScene);
        buttonText = textObject.GetComponent<TextMeshProUGUI>();
        buttonText.text = "Each round, enemies will spawn randomly along the four walls. The round will not end until all enemies are dead.\n. . .";
    }
    public void ChangeScene()
    {
        if(preClicks <= 0)
        {
            SceneManager.LoadScene(sceneNumber);
        }
        else if(preClicks <= 7 && preClicks > 5)
        {
            buttonText.text = "Every third round is a boss round. They will spawn from the portals, so ensure your defenses are ready.\n. . .";
            preClicks--;
        }
        else if (preClicks <= 5 && preClicks > 3)
        {
            buttonText.text = "Enemies will all march towards your castle until another target makes itself apparent, and if your castle falls, it's game over.\n. . .";
            preClicks--;
        }
        else if (preClicks <= 3)
        {
            buttonText.text = "If you die in a round, the castle will ressurect you when the round ends, provided it has not fallen.\n. . .";
            preClicks--;
        }
    }
}
