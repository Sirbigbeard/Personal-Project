using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIButton : MonoBehaviour
{
    public string tooltip;
    public GameObject tooltipObject;
    public TextMeshProUGUI tooltipText;
    void Awake()
    {
        StartCoroutine(Delay());
    }
    public void DisplayTooltip()
    {
        tooltipText.text = tooltip;
    }
    public void HideTooltip()
    {
        tooltipText.text = "";
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(.01f);
        tooltipText = tooltipObject.GetComponent<TextMeshProUGUI>();
    }
}
