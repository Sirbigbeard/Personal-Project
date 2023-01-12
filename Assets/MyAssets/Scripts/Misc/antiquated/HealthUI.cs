using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public Vector3 offset = new Vector3(0f, 1.6f, 0f);
    public Vector3 location;
    public Transform host;
    private Camera cam;
    public int health;
    public TextMeshProUGUI textMesh;

    void Start()
    {
        cam = Camera.main;
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();
        //textMesh.text = "";
    }
    void Update()
    {
        if (host != null)
        {
            location = cam.WorldToScreenPoint(host.position + offset);
            if (transform.position != location)
            {
                transform.position = location;
            }
        }
    }
}
