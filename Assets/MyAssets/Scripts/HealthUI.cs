using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI goldDisplay;
    public Vector3 offset = new Vector3(0f, 1.6f, 0f);
    public Vector3 location;
    public Transform host;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        GetComponent<TMPro.TextMeshProUGUI>().text = "----------";
    }

    // Update is called once per frame
    void Update()
    {
        location = cam.WorldToScreenPoint(host.position + offset);
        if (transform.position != location)
        {
            transform.position = location;
        }
    }
}
