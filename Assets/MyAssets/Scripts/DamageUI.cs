using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageUI : MonoBehaviour
{
    public TextMeshProUGUI goldDisplay;
    public Vector3 offset = new Vector3(0, 2, 0);
    public Vector3 location;
    public Transform host;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        GetComponent<TMPro.TextMeshProUGUI>().text = "-5";
    }
    void Update()
    {
        location = cam.WorldToScreenPoint(host.position + offset);
        if (transform.position != location)
        {
            transform.position = location;
        }
    }
    IEnumerator DamageFade()
    {
        yield return new WaitForSeconds(2);
        GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }
}
